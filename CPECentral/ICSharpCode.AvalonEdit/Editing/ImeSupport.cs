﻿#region Using directives

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

#endregion

namespace ICSharpCode.AvalonEdit.Editing
{
    internal class ImeSupport
    {
        private readonly TextArea textArea;
        private IntPtr currentContext;
        private IntPtr defaultImeWnd;
        private HwndSource hwndSource;

        private bool isReadOnly;
        private IntPtr previousContext;

        private EventHandler requerySuggestedHandler;
            // we need to keep the event handler instance alive because CommandManager.RequerySuggested uses weak references

        public ImeSupport(TextArea textArea)
        {
            if (textArea == null) {
                throw new ArgumentNullException("textArea");
            }
            this.textArea = textArea;
            InputMethod.SetIsInputMethodSuspended(this.textArea, textArea.Options.EnableImeSupport);
            // We listen to CommandManager.RequerySuggested for both caret offset changes and changes to the set of read-only sections.
            // This is because there's no dedicated event for read-only section changes; but RequerySuggested needs to be raised anyways
            // to invalidate the Paste command.
            requerySuggestedHandler = OnRequerySuggested;
            CommandManager.RequerySuggested += requerySuggestedHandler;
            textArea.OptionChanged += TextAreaOptionChanged;
        }

        private void OnRequerySuggested(object sender, EventArgs e)
        {
            UpdateImeEnabled();
        }

        private void TextAreaOptionChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "EnableImeSupport") {
                InputMethod.SetIsInputMethodSuspended(textArea, textArea.Options.EnableImeSupport);
                UpdateImeEnabled();
            }
        }

        public void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            UpdateImeEnabled();
        }

        public void OnLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            if (e.OldFocus == textArea && currentContext != IntPtr.Zero) {
                ImeNativeWrapper.NotifyIme(currentContext);
            }
            ClearContext();
        }

        private void UpdateImeEnabled()
        {
            if (textArea.Options.EnableImeSupport && textArea.IsKeyboardFocused) {
                bool newReadOnly = !textArea.ReadOnlySectionProvider.CanInsert(textArea.Caret.Offset);
                if (hwndSource == null || isReadOnly != newReadOnly) {
                    ClearContext(); // clear existing context (on read-only change)
                    isReadOnly = newReadOnly;
                    CreateContext();
                }
            }
            else {
                ClearContext();
            }
        }

        private void ClearContext()
        {
            if (hwndSource != null) {
                ImeNativeWrapper.ImmAssociateContext(hwndSource.Handle, previousContext);
                ImeNativeWrapper.ImmReleaseContext(defaultImeWnd, currentContext);
                currentContext = IntPtr.Zero;
                defaultImeWnd = IntPtr.Zero;
                hwndSource.RemoveHook(WndProc);
                hwndSource = null;
            }
        }

        private void CreateContext()
        {
            hwndSource = (HwndSource) PresentationSource.FromVisual(textArea);
            if (hwndSource != null) {
                if (isReadOnly) {
                    defaultImeWnd = IntPtr.Zero;
                    currentContext = IntPtr.Zero;
                }
                else {
                    defaultImeWnd = ImeNativeWrapper.ImmGetDefaultIMEWnd(IntPtr.Zero);
                    currentContext = ImeNativeWrapper.ImmGetContext(defaultImeWnd);
                }
                previousContext = ImeNativeWrapper.ImmAssociateContext(hwndSource.Handle, currentContext);
                hwndSource.AddHook(WndProc);
                // UpdateCompositionWindow() will be called by the caret becoming visible

                ITfThreadMgr threadMgr = ImeNativeWrapper.GetTextFrameworkThreadManager();
                if (threadMgr != null) {
                    // Even though the docu says passing null is invalid, this seems to help
                    // activating the IME on the default input context that is shared with WPF
                    threadMgr.SetFocus(IntPtr.Zero);
                }
            }
        }

        private IntPtr WndProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg) {
                case ImeNativeWrapper.WM_INPUTLANGCHANGE:
                    // Don't mark the message as handled; other windows
                    // might want to handle it as well.

                    // If we have a context, recreate it
                    if (hwndSource != null) {
                        ClearContext();
                        CreateContext();
                    }
                    break;
                case ImeNativeWrapper.WM_IME_COMPOSITION:
                    UpdateCompositionWindow();
                    break;
            }
            return IntPtr.Zero;
        }

        public void UpdateCompositionWindow()
        {
            if (currentContext != IntPtr.Zero) {
                ImeNativeWrapper.SetCompositionFont(hwndSource, currentContext, textArea);
                ImeNativeWrapper.SetCompositionWindow(hwndSource, currentContext, textArea);
            }
        }
    }
}