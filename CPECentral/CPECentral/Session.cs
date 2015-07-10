﻿#region Using directives

using System;
using System.Drawing;
using System.IO;
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
        private static PartPhotoCache _partPhotoCache;

        internal static IMessageBus MessageBus
        {
            get { return _kernel.Get<IMessageBus>(); }
        }

        internal static Font AppFont
        {
            get { return _appFont; }
        }

        internal static PartPhotoCache PartPartPhotoCache
        {
            get { return _partPhotoCache; }
        }
            
            internal static Employee CurrentEmployee { get; set; }

        internal static DocumentService DocumentService { get; private set; }

        internal static void Initialize()
        {
            _kernel = new StandardKernel();

            _kernel.Bind<IMessageBus>().To<MessageBus>().InSingletonScope();
            _kernel.Bind<IDialogService>().To<StandardDialogService>().InTransientScope();
            _kernel.Bind<IPasswordService>().To<PBKDF2PasswordService>().InTransientScope();

            Rectangle resolution = Screen.PrimaryScreen.Bounds;

            _appFont = resolution.Height < 1080
                ? new Font(Settings.Default.AppFont.FontFamily.Name, 8f)
                : Settings.Default.AppFont;

            DocumentService = new DocumentService();

            _partPhotoCache = new PartPhotoCache();

            CopyQmsLocally();
        }

        internal static T GetInstanceOf<T>()
        {
            return _kernel.Get<T>();
        }

        private static void CopyQmsLocally()
        {
            string commonAppDir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) +
                                  "\\CPECentral\\";

            var pathToRemoteQms = Settings.Default.PathToQMSDatabase;

            var fileName = Path.GetFileName(pathToRemoteQms);

            var localFilePath = Path.Combine(commonAppDir, fileName);

            if (!File.Exists(localFilePath))
            {
                File.Copy(pathToRemoteQms, localFilePath);
                return;
            }
            
            var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

            bool fileHasBeenModified = false;

            using (var remoteStream = new FileStream(pathToRemoteQms, FileMode.Open))
            {
                using (var localStream = new FileStream(localFilePath, FileMode.Open))
                {
                    var remoteHash = md5.ComputeHash(remoteStream);
                    var localHash = md5.ComputeHash(localStream);

                    fileHasBeenModified = remoteHash != localHash;
                }
            }

            if (fileHasBeenModified)
            {
                File.Copy(pathToRemoteQms, localFilePath, true);
            }
        }
    }
}