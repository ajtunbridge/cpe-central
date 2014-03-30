#region Using directives

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

#endregion

namespace nGenLibrary.IO
{
    public delegate CopyFileCallbackAction CopyFileCallback(
        string fileName, string destinationDirectory, int percentComplete);

    public class FileCopier
    {
        #region API imports

        [SuppressUnmanagedCodeSecurity]
        [DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool CopyFileEx(string lpExistingFileName, string lpNewFileName,
            CopyProgressRoutine lpProgressRoutine, IntPtr lpData, ref bool pbCancel,
            int dwCopyFlags);

        #endregion

        #region Public methods

        public static void Copy(string source, string destination)
        {
            Copy(source, destination, CopyFileOptions.None);
        }

        public static void Copy(string source, string destination, CopyFileCallback callback)
        {
            Copy(source, destination, callback, CopyFileOptions.None);
        }

        public static void Copy(string source, string destination, CopyFileOptions options)
        {
            Copy(source, destination, null, options);
        }

        public static void Copy(string source, string destination, CopyFileCallback callback, CopyFileOptions options)
        {
            Copy(source, destination, callback, options, null);
        }

        public static void Copy(string source, string destination, CopyFileCallback callback,
            CopyFileOptions options, object state)
        {
            if (!File.Exists(source)) {
                throw new FileNotFoundException("File does not exist!", source);
            }

            if ((options & ~CopyFileOptions.All) != 0) {
                throw new ArgumentOutOfRangeException("options");
            }

            new FileIOPermission(FileIOPermissionAccess.Read, source).Demand();
            new FileIOPermission(FileIOPermissionAccess.Write, destination).Demand();

            CopyProgressRoutine cpr = (callback == null)
                ? null
                : new CopyProgressRoutine(
                    new ProgressData(destination, callback).CallbackHandler);

            bool cancel = false;

            if (!CopyFileEx(source, destination, cpr, IntPtr.Zero, ref cancel, (int) options)) {
                throw new IOException(new Win32Exception().Message);
            }
        }

        #endregion

        #region Nested type: CopyProgressRoutine

        private delegate int CopyProgressRoutine(
            long totalFileSize, long totalBytesTransferred, long streamSize,
            long streamBytesTransferred, int streamNumber, int callbackReason,
            IntPtr sourceFile, IntPtr destinationFile, IntPtr data);

        #endregion

        #region Nested type: ProgressData

        private class ProgressData
        {
            private readonly CopyFileCallback _callback;
            private readonly string _destination;

            public ProgressData(string destination, CopyFileCallback callback)
            {
                _destination = destination;
                _callback = callback;
            }

            public int CallbackHandler(long totalBytes, long bytesCopied, long streamSize,
                long streamBytesTransferred, int streamNumber, int callbackReason,
                IntPtr sourceFile, IntPtr destinationFile, IntPtr data)
            {
                string fileName = Path.GetFileName(_destination);
                string directory = Path.GetDirectoryName(_destination);

                double temp = ((double) bytesCopied/totalBytes*100);

                int progress = Convert.ToInt32(temp);

                return (int) _callback(fileName, directory, progress);
            }
        }

        #endregion
    }

    public enum CopyFileCallbackAction
    {
        Continue = 0,
        Cancel = 1,
        Stop = 2,
        Quiet = 3
    }

    [Flags]
    public enum CopyFileOptions
    {
        None = 0x0,
        FailIfDestinationExists = 0x1,
        Restartable = 0x2,
        AllowDecryptedDestination = 0x8,
        All = FailIfDestinationExists | Restartable | AllowDecryptedDestination
    }
}