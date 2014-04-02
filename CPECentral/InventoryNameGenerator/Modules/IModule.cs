#region Using directives

using System.Data;

#endregion

namespace InventoryNameGenerator.Modules
{
    public interface IModule
    {
        /// <summary>
        ///     The name of this module
        /// </summary>
        string Name { get; }

        DataSet Data { get; }

        /// <summary>
        ///     Create this module's panel
        /// </summary>
        /// <returns></returns>
        ModulePanel CreatePanel();

        /// <summary>
        ///     Generate a default data file for this module in the specified directory
        /// </summary>
        /// <param name="directory">The directory to save the XML file into</param>
        void GenerateDefaultDataFile(string directory);

        /// <summary>
        ///     Save this module's dataset to an XML file in the specified directory
        /// </summary>
        /// <param name="directory">The directory to save the XML file into</param>
        void SaveDataFile(string directory);

        /// <summary>
        ///     Loads this module's dataset from an XML file in the specified directory
        /// </summary>
        /// <param name="directory">The directory the XML file is located in</param>
        void LoadDataFile(string directory);
    }
}