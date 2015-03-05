#region Using directives

using System.Windows.Forms;

#endregion

namespace CPECentral.Views
{
    public partial class EngineerToolsView : UserControl
    {
        public EngineerToolsView()
        {
            InitializeComponent();

            optionsComboBox.SelectedIndex = 0;
        }
    }
}