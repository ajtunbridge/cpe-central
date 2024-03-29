﻿#region Using directives

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Serialization;
using System.Security;
using System.Text;
using System.Windows;
using System.Windows.Media;

#endregion

namespace ICSharpCode.AvalonEdit.Highlighting
{
    /// <summary>
    ///     A highlighting color is a set of font properties and foreground and background color.
    /// </summary>
    [Serializable]
    public class HighlightingColor : ISerializable
    {
        /// <summary>
        ///     Creates a new HighlightingColor instance.
        /// </summary>
        public HighlightingColor()
        {
        }

        /// <summary>
        ///     Deserializes a HighlightingColor.
        /// </summary>
        protected HighlightingColor(SerializationInfo info, StreamingContext context)
        {
            if (info == null) {
                throw new ArgumentNullException("info");
            }
            Name = info.GetString("Name");
            if (info.GetBoolean("HasWeight")) {
                FontWeight = System.Windows.FontWeight.FromOpenTypeWeight(info.GetInt32("Weight"));
            }
            if (info.GetBoolean("HasStyle")) {
                FontStyle = (FontStyle?) new FontStyleConverter().ConvertFromInvariantString(info.GetString("Style"));
            }
            Foreground = (HighlightingBrush) info.GetValue("Foreground", typeof (HighlightingBrush));
            Background = (HighlightingBrush) info.GetValue("Background", typeof (HighlightingBrush));
        }

        /// <summary>
        ///     Gets/Sets the name of the color.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets/sets the font weight. Null if the highlighting color does not change the font weight.
        /// </summary>
        public FontWeight? FontWeight { get; set; }

        /// <summary>
        ///     Gets/sets the font style. Null if the highlighting color does not change the font style.
        /// </summary>
        public FontStyle? FontStyle { get; set; }

        /// <summary>
        ///     Gets/sets the foreground color applied by the highlighting.
        /// </summary>
        public HighlightingBrush Foreground { get; set; }

        /// <summary>
        ///     Gets/sets the background color applied by the highlighting.
        /// </summary>
        public HighlightingBrush Background { get; set; }

        #region ISerializable Members

        /// <summary>
        ///     Serializes this HighlightingColor instance.
        /// </summary>
#if DOTNET4
        [SecurityCritical]
#else
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
		#endif
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) {
                throw new ArgumentNullException("info");
            }
            info.AddValue("Name", Name);
            info.AddValue("HasWeight", FontWeight.HasValue);
            if (FontWeight.HasValue) {
                info.AddValue("Weight", FontWeight.Value.ToOpenTypeWeight());
            }
            info.AddValue("HasStyle", FontStyle.HasValue);
            if (FontStyle.HasValue) {
                info.AddValue("Style", FontStyle.Value.ToString());
            }
            info.AddValue("Foreground", Foreground);
            info.AddValue("Background", Background);
        }

        #endregion

        /// <summary>
        ///     Gets CSS code for the color.
        /// </summary>
        [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase",
            Justification = "CSS usually uses lowercase, and all possible values are English-only")]
        public virtual string ToCss()
        {
            var b = new StringBuilder();
            if (Foreground != null) {
                Color? c = Foreground.GetColor(null);
                if (c != null) {
                    b.AppendFormat(CultureInfo.InvariantCulture, "color: #{0:x2}{1:x2}{2:x2}; ", c.Value.R, c.Value.G,
                        c.Value.B);
                }
            }
            if (FontWeight != null) {
                b.Append("font-weight: ");
                b.Append(FontWeight.Value.ToString().ToLowerInvariant());
                b.Append("; ");
            }
            if (FontStyle != null) {
                b.Append("font-style: ");
                b.Append(FontStyle.Value.ToString().ToLowerInvariant());
                b.Append("; ");
            }
            return b.ToString();
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return "[" + GetType() + " " + (string.IsNullOrEmpty(Name) ? ToCss() : Name) + "]";
        }
    }
}