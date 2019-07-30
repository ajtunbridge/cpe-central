using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CPECentral.ModernUI.EventArgs;

namespace CPECentral.ModernUI.Views
{
    /// <summary>
    /// Interaction logic for ModuleSelectorView.xaml
    /// </summary>
    public partial class AppModuleSelectorView : UserControl
    {
        public event EventHandler<AppModuleSelectedEventArgs> AppModuleSelected;

        public AppModuleSelectorView()
        {
            InitializeComponent();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // TODO: research a better way of doing this. It seems a wee bit hacky as it is.
            var label = (Label)sender;

            label.Tag = "IsSelected";

            foreach (UIElement element in LinksStackPanel.Children)
            {
                if (element is Label)
                {
                    var child = element as Label;

                    if (ReferenceEquals(child, label))
                    {
                        continue;
                    }

                    child.Tag = null;
                }
            }

            AppModuleSelectedEventArgs args = null;

            switch (label.Name)
            {
                case "StartSectionLabel":
                    args = new AppModuleSelectedEventArgs(AppModule.Start);
                    break;
                case "PartLibrarySectionLabel":
                    args = new AppModuleSelectedEventArgs(AppModule.PartLibrary);
                    break;
                case "InventorySectionLabel":
                    args = new AppModuleSelectedEventArgs(AppModule.Inventory);
                    break;
                case "MaintenanceSectionLabel":
                    args = new AppModuleSelectedEventArgs(AppModule.Maintenance);
                    break;
                case "QualitySectionLabel":
                    args = new AppModuleSelectedEventArgs(AppModule.Quality);
                    break;
            }

            OnAppModuleSelected(args);
        }

        protected virtual void OnAppModuleSelected(AppModuleSelectedEventArgs e)
        {
            var handler = AppModuleSelected;
            if (handler != null) handler(this, e);
        }
    }
}
