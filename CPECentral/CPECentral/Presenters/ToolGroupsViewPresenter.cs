#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.ViewModels;
using CPECentral.Views;
using nGenLibrary;

#endregion

namespace CPECentral.Presenters
{
    public class ToolGroupsViewPresenter
    {
        private const string NewGroupName = "NEW GROUP ";
        private readonly IToolGroupsView _view;

        public ToolGroupsViewPresenter(IToolGroupsView view)
        {
            _view = view;

            _view.RefreshGroups += View_RefreshGroups;
            _view.AddRootGroup += View_AddRootGroup;
            _view.AddChildGroup += View_AddChildGroup;
            _view.ToolGroupRenamed += View_ToolGroupRenamed;
            _view.DeleteGroup += _view_DeleteGroup;
        }

        void _view_DeleteGroup(object sender, ToolGroupEventArgs e)
        {
            try {
                using (BusyCursor.Show()) {
                    using (var cpe = new UnitOfWork()) {
                        cpe.ToolGroups.Delete(e.ToolGroup);
                        cpe.Commit();
                        RefreshGroups();
                    }
                }
            }
            catch (Exception ex) {
                HandleException(ex);
            }
        }

        private bool View_ToolGroupRenamed(ToolGroup entity)
        {
            bool result = true;

            try {
                using (BusyCursor.Show()) {
                    using (var cpe = new UnitOfWork()) {
                        entity.Name = entity.Name.ToUpper().Trim();
                        cpe.ToolGroups.Update(entity);
                        cpe.Commit();
                    }
                }
            }
            catch (Exception ex) {
                result = false;
                HandleException(ex);
            }

            return result;
        }

        private void View_AddChildGroup(object sender, ToolGroupEventArgs e)
        {
            AddGroup(e.ToolGroup);
        }

        private void View_AddRootGroup(object sender, EventArgs e)
        {
            AddGroup(null);
        }

        private void View_RefreshGroups(object sender, EventArgs e)
        {
            RefreshGroups();
        }

        private void AddGroup(ToolGroup parentGroup)
        {
            ToolGroup newGroup = null;

            try {
                using (BusyCursor.Show()) {
                    using (var cpe = new UnitOfWork()) {
                        IEnumerable<ToolGroup> groupsAtSameLevel = (parentGroup == null)
                            ? cpe.ToolGroups.GetRootGroups()
                            : cpe.ToolGroups.GetChildGroups(parentGroup);

                        string newName = NewGroupName + "01";
                        int count = 1;
                        while (groupsAtSameLevel.Any(g => g.Name.Equals(newName, StringComparison.OrdinalIgnoreCase))) {
                            count++;
                            newName = NewGroupName + count.ToString("00");
                        }
                        newGroup = new ToolGroup {Name = newName};
                        if (parentGroup != null) {
                            newGroup.ParentGroupId = parentGroup.Id;
                        }
                        cpe.ToolGroups.Add(newGroup);
                        cpe.Commit();
                        RefreshGroups();
                        _view.SelectToolGroup(newGroup, true);
                    }
                }
            }
            catch (Exception ex) {
                HandleException(ex);
            }
        }

        private void RefreshGroups()
        {
            var model = new ToolGroupsViewModel();

            try {
                using (BusyCursor.Show()) {
                    using (var cpe = new UnitOfWork()) {
                        model.ToolGroups = cpe.ToolGroups.GetAll();
                    }
                }
            }
            catch (Exception ex) {
                HandleException(ex);
            }

            _view.DisplayModel(model);
        }

        private void HandleException(Exception ex)
        {
            string message = null;

            if (ex is DataProviderException) {
                var dataEx = ex as DataProviderException;

                if (dataEx.Error == DataProviderError.UniqueConstraintViolation) {
                    message = "A group with this name already exists at this level!";
                }
                else if (dataEx.Error == DataProviderError.RelationshipViolation) {
                    message = "This group cannot be deleted as it has tools/groups related to it!";
                }
                else {
                    message = ex.Message;
                }
            }
            else {
                message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }

            _view.DialogService.ShowError(message);
        }
    }
}