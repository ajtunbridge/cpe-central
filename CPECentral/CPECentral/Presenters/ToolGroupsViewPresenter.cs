using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPECentral.Data.EF5;
using CPECentral.ViewModels;
using CPECentral.Views;
using nGenLibrary;

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
            _view.AddRootGroup += _view_AddRootGroup;
            _view.AddChildGroup += _view_AddChildGroup;
        }

        void _view_AddChildGroup(object sender, CustomEventArgs.ToolGroupEventArgs e)
        {
            AddGroup(e.ToolGroup);
        }

        void _view_AddRootGroup(object sender, EventArgs e)
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

            try
            {
                using (BusyCursor.Show())
                {
                    using (var cpe = new UnitOfWork()) {
                        var groupsAtSameLevel = (parentGroup == null)
                            ? cpe.ToolGroups.GetRootGroups()
                            : cpe.ToolGroups.GetChildGroups(parentGroup);

                        var newName = NewGroupName + "01";
                        int count = 1;
                        while (groupsAtSameLevel.Any(g => g.Name.Equals(newName, StringComparison.OrdinalIgnoreCase)))
                        {
                            count++;
                            newName = NewGroupName + count.ToString("00");
                        }
                        newGroup = new ToolGroup { Name = newName };
                        if (parentGroup != null) {
                            newGroup.ParentGroupId = parentGroup.Id;
                        }
                        cpe.ToolGroups.Add(newGroup);
                        cpe.Commit();
                        RefreshGroups();
                        _view.SelectToolGroup(newGroup);
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void RefreshGroups()
        {
            var model = new ToolGroupsViewModel();

            try
            {
                using (BusyCursor.Show())
                {
                    using (var cpe = new UnitOfWork())
                    {
                        model.ToolGroups = cpe.ToolGroups.GetAll();
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            _view.DisplayModel(model);
        }

        void HandleException(Exception ex)
        {
            
        }
    }
}
