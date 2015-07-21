namespace CPECentral.ModernUI.EventArgs
{
    public class AppModuleSelectedEventArgs : System.EventArgs
    {
        public AppModuleSelectedEventArgs(AppModule selectedModule)
        {
            SelectedModule = selectedModule;
        }

        public AppModule SelectedModule { get; private set; }
    }
}