#region Using directives

using CPECentral.Data.EF5;
using nGenLibrary;

#endregion

namespace CPECentral
{
    internal static class AppSecurity
    {
        private static readonly IDialogService DialogService = Session.GetInstanceOf<IDialogService>();

        /// <summary>
        ///     Checks if the current user has the specified permission. If they don't, an error message
        ///     is show and false is returned. Otherwise, returns true
        /// </summary>
        /// <param name="permission">The permission to check for</param>
        /// <returns></returns>
        internal static bool Check(AppPermission permission)
        {
            return Check(permission, false);
        }

        /// <summary>
        ///     Checks if the current user has the specified permission. If they don't, an error message
        ///     is show and false is returned. Otherwise, returns true
        /// </summary>
        /// <param name="permission">The permission to check for</param>
        /// <param name="showErrorDialog">Whether or not to show an error dialog if the user doesn't have the permission</param>
        /// <returns></returns>
        internal static bool Check(AppPermission permission, bool showErrorDialog)
        {
            using (BusyCursor.Show()) {
                using (var uow = new UnitOfWork()) {
                    var group = uow.EmployeeGroups.GetById(Session.CurrentEmployee.EmployeeGroupId);

                    if (group.HasPermission(AppPermission.Administrator) || group.HasPermission(permission)) {
                        return true;
                    }

                    if (!showErrorDialog) {
                        return false;
                    }

                    var message = "Access denied!";

                    switch (permission) {
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

                    DialogService.ShowError(message);

                    return false;
                }
            }
        }
    }
}