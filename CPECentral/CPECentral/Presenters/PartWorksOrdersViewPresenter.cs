#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CPECentral.CustomEventArgs;
using CPECentral.ViewModels;
using CPECentral.Views;
using Tricorn;

#endregion

namespace CPECentral.Presenters
{
    public class PartWorksOrdersViewPresenter
    {
        private readonly IPartWorksOrdersView _view;

        public PartWorksOrdersViewPresenter(IPartWorksOrdersView view)
        {
            _view = view;

            _view.LoadWorksOrders += View_LoadWorksOrders;
        }

        private void View_LoadWorksOrders(object sender, PartEventArgs e)
        {
            var loadWorker = new BackgroundWorker();

            loadWorker.DoWork += (obj, args) => {
                try {
                    using (var tricorn = new TricornDataProvider()) {
                        // get the 25 most recent works orders
                        IEnumerable<WOrder> worksOrders =
                            tricorn.GetWorksOrdersByDrawingNumber(e.Part.DrawingNumber)
                            .OrderByDescending(wo => wo.Delivery)
                            .Take(25);
                        if (!worksOrders.Any()) {
                            args.Result = null;
                            return;
                        }
                        var modelItems = new List<PartWorksOrdersViewModel>();
                        foreach (WOrder wo in worksOrders) {
                            var model = new PartWorksOrdersViewModel {
                                WorksOrderNumber = wo.User_Reference,
                                DueOn = wo.Delivery,
                                Quantity = Convert.ToInt32(wo.Quantity),
                                BuildQuantity = Convert.ToInt32(wo.Quantity_To_Build),
                                OrderNumber = wo.Customer_Order_Number
                            };
                            modelItems.Add(model);
                        }
                        args.Result = modelItems;
                    }
                }
                catch (Exception ex) {
                    args.Result = ex;
                }
            };

            loadWorker.RunWorkerCompleted += (obj, args) => {
                if (args.Result is Exception) {
                    HandleException(args.Result as Exception);
                    _view.DisplayModel(null);
                    return;
                }
                var modelItems = args.Result as IEnumerable<PartWorksOrdersViewModel>;
                _view.DisplayModel(modelItems);
            };

            loadWorker.RunWorkerAsync();
        }

        private void HandleException(Exception ex)
        {
            string msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

            _view.DialogService.ShowError(msg);
        }
    }
}