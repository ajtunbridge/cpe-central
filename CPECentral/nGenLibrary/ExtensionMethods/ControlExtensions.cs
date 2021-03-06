﻿#region Using directives

using System;
using System.Windows.Forms;

#endregion

// ReSharper disable CheckNamespace
public static class ControlExtensions
// ReSharper restore CheckNamespace
{
    public static TResult InvokeEx<TControl, TResult>(this TControl control, Func<TControl, TResult> func)
        where TControl : Control
    {
        return control.InvokeRequired
            ? (TResult) control.Invoke(func, control)
            : func(control);
    }

    public static void InvokeEx<TControl>(this TControl control, Action<TControl> func) where TControl : Control
    {
        control.InvokeEx(c => {
            func(c);
            return c;
        });
    }

    public static void InvokeEx<TControl>(this TControl control, Action action)
        where TControl : Control
    {
        control.InvokeEx(c => action());
    }
}