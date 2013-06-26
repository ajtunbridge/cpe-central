﻿#region Using directives

using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using CPECentral.Data.EF5;
using CPECentral.ViewModels;
using CPECentral.Views;
using nGenLibrary;

#endregion

namespace CPECentral.Presenters
{
    public sealed class PartInformationViewPresenter
    {
        private readonly IPartInformationView _partInformationView;

        public PartInformationViewPresenter(IPartInformationView partInformationView)
        {
            _partInformationView = partInformationView;

            _partInformationView.ReloadData += PartInformationView_ReloadData;
            _partInformationView.SaveChanges += _partInformationView_SaveChanges;
        }

        private void _partInformationView_SaveChanges(object sender, EventArgs e)
        {
            try
            {
                using (BusyCursor.Show())
                {
                    using (var uow = new UnitOfWork())
                    {
                        var part = _partInformationView.Part;

                        part.ModifiedBy = Session.CurrentEmployee.Id;

                        uow.Parts.Update(part);

                        uow.Commit();
                    }
                }

                _partInformationView.SaveCompleted(true);
            }
            catch (Exception ex)
            {
                HandleException(ex);

                _partInformationView.SaveCompleted(false);
            }
        }

        private void PartInformationView_ReloadData(object sender, EventArgs e)
        {
            var getDataWorker = new BackgroundWorker();
            getDataWorker.DoWork += getDataWorker_DoWork;
            getDataWorker.RunWorkerCompleted += getDataWorker_RunWorkerCompleted;

            getDataWorker.RunWorkerAsync(_partInformationView.Part);
        }

        private void getDataWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                HandleException(e.Result as Exception);
                _partInformationView.DisplayModel(null);
                return;
            }

            var model = (PartInformationViewModel) e.Result;

            _partInformationView.DisplayModel(model);
        }

        private void getDataWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var part = (Part) e.Argument;

                using (var uow = new UnitOfWork())
                {
                    var customer = uow.Customers.GetById(part.CustomerId);
                    var versions = uow.PartVersions.GetByPart(part).OrderByDescending(v => v.VersionNumber);

                    var model = new PartInformationViewModel();
                    model.AllVersions = versions;
                    model.Customer = customer.Name;
                    model.DrawingNumber = part.DrawingNumber;
                    model.Name = part.Name;
                    model.ToolingLocation = part.ToolingLocation;

                    e.Result = model;
                }
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        private void HandleException(Exception ex)
        {
            string message;

            if (ex is DataProviderException)
            {
                message = ex.Message;
            }
            else
            {
                message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }

            _partInformationView.DialogService.ShowError(message);
        }
    }
}