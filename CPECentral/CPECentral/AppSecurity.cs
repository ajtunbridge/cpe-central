#region Using directives

using CPECentral.Data.EF5;
using nGenLibrary;

#endregion

namespace CPECentral
{
    internal static class AppSecurity
    {
        private static readonly IDialogService _dialogService = Session.GetInstanceOf<IDialogService>();

        internal static bool Check(AppPermission permission)
        {
            using (BusyCursor.Show())
            {
                using (var uow = new UnitOfWork())
                {
                    var group = uow.EmployeeGroups.GetById(Session.CurrentEmployee.EmployeeGroupId);

                    if (group.HasPermission(AppPermission.Administrator) || group.HasPermission(permission))
                        return true;

                    var message = "Access denied!";

                    switch (permission)
                    {
                        case AppPermission.ManageDocuments:
                            message = "You do not have permission to manage documents!";
                            break;
                        case AppPermission.ManageEmployees:
                            message = "You do not have permission to manage employee accounts!";
                            break;
                        case AppPermission.ManageParts:
                            message = "You do not have permission to manage parts!";
                            break;
                        case AppPermission.ManageOperations:
                            message = "You do not have permission to edit operation information!";
                            break;
                    }

                    _dialogService.ShowError(message);

                    return false;
                }
            }
        }
    }
}