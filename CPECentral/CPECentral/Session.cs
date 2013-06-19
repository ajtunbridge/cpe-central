#region Using directives

using CPECentral.Data.EF5;
using Ninject;
using nGenLibrary.Messaging;
using nGenLibrary.Security;

#endregion

namespace CPECentral
{
    internal static class Session
    {
        private static StandardKernel _kernel;

        internal static IMessageBus MessageBus
        {
            get { return _kernel.Get<IMessageBus>(); }
        }

        internal static Employee CurrentEmployee { get; set; }

        internal static DocumentService DocumentService { get; private set; }

        internal static void Initialize()
        {
            _kernel = new StandardKernel();

            _kernel.Bind<IMessageBus>().To<MessageBus>().InSingletonScope();
            _kernel.Bind<IDialogService>().To<StandardDialogService>().InTransientScope();
            _kernel.Bind<IPasswordService>().To<PBKDF2PasswordService>().InTransientScope();

            DocumentService = new DocumentService();
        }

        internal static T GetInstanceOf<T>()
        {
            return _kernel.Get<T>();
        }
    }
}