#region Using directives

using System;

#endregion

namespace CPECentral.Data.EF5
{
    /// <summary>
    ///     Bit flags for setting application permissions for users
    /// </summary>
    [Flags]
    public enum ApplicationPermission
    {
        /// <summary>
        ///     Has full control of the system
        /// </summary>
        Administrator = 1 << 0,

        /// <summary>
        ///     Can create and delete employee accounts
        /// </summary>
        ManageEmployees = 1 << 1,

        /// <summary>
        ///     Can create and delete documents
        /// </summary>
        ManageDocuments = 1 << 2,

        /// <summary>
        ///     Can create, edit and delete customer parts
        /// </summary>
        ManageParts = 1 << 3,

        /// <summary>
        ///     Can create, edit & delete operations and operation tooling
        /// </summary>
        ManageOperations = 1 << 4
    }
}