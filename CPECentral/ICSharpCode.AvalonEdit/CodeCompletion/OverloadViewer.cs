﻿#region Using directives

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

#endregion

namespace ICSharpCode.AvalonEdit.CodeCompletion
{
    /// <summary>
    ///     Represents a text between "Up" and "Down" buttons.
    /// </summary>
    public class OverloadViewer : Control
    {
        /// <summary>
        ///     The text property.
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof (string), typeof (OverloadViewer));

        /// <summary>
        ///     The ItemProvider property.
        /// </summary>
        public static readonly DependencyProperty ProviderProperty =
            DependencyProperty.Register("Provider", typeof (IOverloadProvider), typeof (OverloadViewer));

        static OverloadViewer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (OverloadViewer),
                new FrameworkPropertyMetadata(typeof (OverloadViewer)));
        }

        /// <summary>
        ///     Gets/Sets the text between the Up and Down buttons.
        /// </summary>
        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        /// <summary>
        ///     Gets/Sets the item provider.
        /// </summary>
        public IOverloadProvider Provider
        {
            get { return (IOverloadProvider) GetValue(ProviderProperty); }
            set { SetValue(ProviderProperty, value); }
        }

        /// <inheritdoc />
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var upButton = (Button) Template.FindName("PART_UP", this);
            upButton.Click += (sender, e) => {
                e.Handled = true;
                ChangeIndex(-1);
            };

            var downButton = (Button) Template.FindName("PART_DOWN", this);
            downButton.Click += (sender, e) => {
                e.Handled = true;
                ChangeIndex(+1);
            };
        }

        /// <summary>
        ///     Changes the selected index.
        /// </summary>
        /// <param name="relativeIndexChange">The relative index change - usual values are +1 or -1.</param>
        public void ChangeIndex(int relativeIndexChange)
        {
            IOverloadProvider p = Provider;
            if (p != null) {
                int newIndex = p.SelectedIndex + relativeIndexChange;
                if (newIndex < 0) {
                    newIndex = p.Count - 1;
                }
                if (newIndex >= p.Count) {
                    newIndex = 0;
                }
                p.SelectedIndex = newIndex;
            }
        }
    }

    internal sealed class CollapseIfSingleOverloadConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((int) value < 2) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}