#region Using directives

using System.Drawing;
using System.Windows.Forms;
using CPECentral.Data.EF5;
using CPECentral.Properties;
using nGenLibrary.Messaging;
using nGenLibrary.Security;
using Ninject;

#endregion

namespace CPECentral
{
    internal static class Session
    {
        private static StandardKernel _kernel;
        private static Font _appFont;

        internal static IMessageBus MessageBus
        {
            get { return _kernel.Get<IMessageBus>(); }
        }

        internal static Font AppFont
        {
            get { return _appFont; }
        }

        internal static Employee CurrentEmployee { get; set; }

        internal static DocumentService DocumentService { get; private set; }

        internal static void Initialize()
        {
            _kernel = new StandardKernel();

            _kernel.Bind<IMessageBus>().To<MessageBus>().InSingletonScope();
            _kernel.Bind<IDialogService>().To<StandardDialogService>().InTransientScope();
            _kernel.Bind<IPasswordService>().To<PBKDF2PasswordService>().InTransientScope();

            var resolution = Screen.PrimaryScreen.Bounds;

            _appFont = resolution.Height < 1080 ? new Font(Settings.Default.AppFont.FontFamily.Name, 8f) : Settings.Default.AppFont;

            DocumentService = new DocumentService();
        }

        internal static T GetInstanceOf<T>()
        {
            return _kernel.Get<T>();
        }
    }
}