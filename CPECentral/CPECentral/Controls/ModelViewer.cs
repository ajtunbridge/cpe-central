#region Using directives

using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using nGenLibrary;

#endregion

namespace CPECentral.Controls
{
    public partial class ModelViewer : UserControl
    {
        public static readonly string[] ValidCadExtensions = {".step", ".stp", ".iges", ".igs"};

        public ModelViewer()
        {
            InitializeComponent();
        }

        public void LoadFile(string fileName)
        {
            string extension = Path.GetExtension(fileName).ToLower();

            if (!ValidCadExtensions.Any(ext => ext.Equals(extension, StringComparison.OrdinalIgnoreCase))) {
                throw new ArgumentException("Unable to load this file as it doesn't have a valid extension!",
                    "fileName");
            }

            if (extension == ".step" || extension == ".stp") {
                using (BusyCursor.Show()) {
                }

                return;
            }

            if (extension == ".igs" || extension == ".iges") {
            }
        }
    }
}