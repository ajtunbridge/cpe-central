#region Using directives

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#endregion

namespace nGenLibrary
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable SuggestUseVarKeywordEvident

    /// <summary>
    ///     Summary description for Win32.
    /// </summary>
    public static class Win32
    {
        #region Struct defs

        #region Nested type: LASTINPUTINFO

        [StructLayout(LayoutKind.Sequential)]
        internal struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }

        #endregion

        #region Nested type: SHFILEINFO

        [StructLayout(LayoutKind.Sequential)]
        internal struct SHFILEINFO
        {
            public const int NAMESIZE = 80;
            public readonly IntPtr hIcon;
            public readonly int iIcon;
            public readonly uint dwAttributes;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)] public readonly string szDisplayName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NAMESIZE)] public readonly string szTypeName;
        }

        #endregion

        #endregion

        #region Dll imports

        private const uint FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
        private const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;
        private const int MAX_PATH = 256;

        private const uint SHGFI_ICON = 0x000000100;
        private const uint SHGFI_LARGEICON = 0x000000000;
        private const uint SHGFI_LINKOVERLAY = 0x000008000;
        private const uint SHGFI_OPENICON = 0x000000002;
        private const uint SHGFI_SMALLICON = 0x000000001;
        private const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;

        private const int WM_SETREDRAW = 11;

        [DllImport("Shell32.dll")]
        private static extern IntPtr SHGetFileInfo(
            string pszPath,
            uint dwFileAttributes,
            ref SHFILEINFO psfi,
            uint cbFileInfo,
            uint uFlags
            );

        [DllImport("User32.dll")]
        private static extern int DestroyIcon(IntPtr hIcon);

        [DllImport("User32.dll")]
        public static extern bool LockWorkStation();

        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [DllImport("Kernel32.dll")]
        private static extern uint GetLastError();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        #endregion

        #region Public methods

        public static void SuspendDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
        }

        public static void ResumeDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
            parent.Refresh();
        }

        public static uint GetIdleTime()
        {
            var lastInPut = new LASTINPUTINFO();
            lastInPut.cbSize = (uint) Marshal.SizeOf(lastInPut);
            GetLastInputInfo(ref lastInPut);

            return ((uint) Environment.TickCount - lastInPut.dwTime);
        }

        public static long GetLastInputTime()
        {
            var lastInPut = new LASTINPUTINFO();
            lastInPut.cbSize = (uint) Marshal.SizeOf(lastInPut);
            if (!GetLastInputInfo(ref lastInPut)) {
                throw new Exception(GetLastError().ToString());
            }

            return lastInPut.dwTime;
        }

        /// <summary>
        ///     Used to access system folder icons.
        /// </summary>
        /// <param name="largeIcon">Specify large or small icons.</param>
        /// <param name="openFolder">Specify open or closed FolderType.</param>
        /// <returns>The requested Icon.</returns>
        public static Icon GetIconForFolder(bool largeIcon, bool openFolder)
        {
            var shellFileInfo = new SHFILEINFO();
            try {
                uint flags = SHGFI_ICON | SHGFI_USEFILEATTRIBUTES;
                flags |= openFolder ? SHGFI_OPENICON : 0;
                flags |= largeIcon ? SHGFI_LARGEICON : SHGFI_SMALLICON;

                SHGetFileInfo(null,
                    FILE_ATTRIBUTE_DIRECTORY,
                    ref shellFileInfo,
                    (uint) Marshal.SizeOf(shellFileInfo),
                    flags);

                return (Icon) Icon.FromHandle(shellFileInfo.hIcon).Clone();
            }
            finally {
                DestroyIcon(shellFileInfo.hIcon); // Cleanup
            }
        }

        /// <summary>
        ///     Used to access file icons for a given extension.
        /// </summary>
        /// <param name="extension">The file extension to get the icon for.</param>
        /// <param name="largeIcon">Specify large or small icons.</param>
        /// <param name="linkOverlay">Specify link overlay on the icon.</param>
        /// <returns>The requested Icon</returns>
        public static Icon GetIconForFileExtension(string extension, bool largeIcon, bool linkOverlay)
        {
            if (!extension.StartsWith(".")) {
                extension = "." + extension;
            }

            var shellFileInfo = new SHFILEINFO();
            try {
                uint flags = SHGFI_ICON | SHGFI_USEFILEATTRIBUTES;
                flags |= linkOverlay ? SHGFI_LINKOVERLAY : 0;
                flags |= largeIcon ? SHGFI_LARGEICON : SHGFI_SMALLICON;

                SHGetFileInfo(extension,
                    FILE_ATTRIBUTE_NORMAL,
                    ref shellFileInfo,
                    (uint) Marshal.SizeOf(shellFileInfo),
                    flags);

                return (Icon) Icon.FromHandle(shellFileInfo.hIcon).Clone();
            }
            finally {
                DestroyIcon(shellFileInfo.hIcon);
            }
        }

        #endregion
    }

    // ReSharper restore InconsistentNaming
    // ReSharper restore SuggestUseVarKeywordEvident
}