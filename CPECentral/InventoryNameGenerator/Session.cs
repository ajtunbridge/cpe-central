#region Using directives

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using InventoryNameGenerator.Properties;

#endregion

namespace InventoryNameGenerator
{
    internal static class Session
    {
        internal static string LocalModuleDir
        {
            get
            {
                var applicationDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                var localModuleDir = string.Format("{0}\\Inventory Name Generator\\Modules\\", applicationDataFolder);
                if (!Directory.Exists(localModuleDir)) {
                    Directory.CreateDirectory(localModuleDir);
                }
                return localModuleDir;
            }
        }
    }
}