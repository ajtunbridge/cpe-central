#region Using directives

using System;
using System.Windows.Forms;

#endregion

namespace nGenLibrary
{
    /// <summary>
    ///     Changes the current cursor to the wait cursor. Wrap in a using
    ///     statement to change back to the default cursor when disposed of
    /// </summary>
    public class BusyCursor : IDisposable
    {
        private readonly bool _cursorAlreadyChanged;

        public BusyCursor()
        {
            if (Cursor.Current == Cursors.WaitCursor) {
                _cursorAlreadyChanged = true;
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (_cursorAlreadyChanged) {
                return;
            }

            Cursor.Current = Cursors.Default;
        }

        #endregion

        /// <summary>
        ///     Instantiates a new BusyCursor for code cleanliness
        /// </summary>
        public static BusyCursor Show()
        {
            return new BusyCursor();
        }
    }
}