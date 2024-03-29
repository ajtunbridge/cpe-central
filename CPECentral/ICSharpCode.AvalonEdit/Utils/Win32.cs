﻿#region Using directives

using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

#endregion

namespace ICSharpCode.AvalonEdit.Utils
{
    /// <summary>
    ///     Wrapper around Win32 functions.
    /// </summary>
    internal static class Win32
    {
        /// <summary>
        ///     Gets the caret blink time.
        /// </summary>
        public static TimeSpan CaretBlinkTime
        {
            get { return TimeSpan.FromMilliseconds(SafeNativeMethods.GetCaretBlinkTime()); }
        }

        /// <summary>
        ///     Creates an invisible Win32 caret for the specified Visual with the specified size (coordinates local to the owner
        ///     visual).
        /// </summary>
        public static bool CreateCaret(Visual owner, Size size)
        {
            if (owner == null) {
                throw new ArgumentNullException("owner");
            }
            var source = PresentationSource.FromVisual(owner) as HwndSource;
            if (source != null) {
                Vector r = owner.PointToScreen(new Point(size.Width, size.Height)) -
                           owner.PointToScreen(new Point(0, 0));
                return SafeNativeMethods.CreateCaret(source.Handle, IntPtr.Zero, (int) Math.Ceiling(r.X),
                    (int) Math.Ceiling(r.Y));
            }
            return false;
        }

        /// <summary>
        ///     Sets the position of the caret previously created using <see cref="CreateCaret" />. position is relative to the
        ///     owner visual.
        /// </summary>
        public static bool SetCaretPosition(Visual owner, Point position)
        {
            if (owner == null) {
                throw new ArgumentNullException("owner");
            }
            var source = PresentationSource.FromVisual(owner) as HwndSource;
            if (source != null) {
                Point pointOnRootVisual = owner.TransformToAncestor(source.RootVisual).Transform(position);
                Point pointOnHwnd = pointOnRootVisual.TransformToDevice(source.RootVisual);
                return SafeNativeMethods.SetCaretPos((int) pointOnHwnd.X, (int) pointOnHwnd.Y);
            }
            return false;
        }

        /// <summary>
        ///     Destroys the caret previously created using <see cref="CreateCaret" />.
        /// </summary>
        public static bool DestroyCaret()
        {
            return SafeNativeMethods.DestroyCaret();
        }

        #region Nested type: SafeNativeMethods

        [SuppressUnmanagedCodeSecurity]
        private static class SafeNativeMethods
        {
            [DllImport("user32.dll")]
            public static extern int GetCaretBlinkTime();

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool CreateCaret(IntPtr hWnd, IntPtr hBitmap, int nWidth, int nHeight);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool SetCaretPos(int x, int y);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool DestroyCaret();
        }

        #endregion
    }
}