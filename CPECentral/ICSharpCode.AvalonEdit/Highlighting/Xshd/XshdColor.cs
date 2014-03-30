#region Using directives

using System;
using System.Runtime.Serialization;
using System.Security;
using System.Windows;

#endregion

namespace ICSharpCode.AvalonEdit.Highlighting.Xshd
{
    /// <summary>
    ///     A color in an Xshd file.
    /// </summary>
    [Serializable]
    public class XshdColor : XshdElement, ISerializable
    {
        /// <summary>
        ///     Creates a new XshdColor instance.
        /// </summary>
        public XshdColor()
        {
        }

        /// <summary>
        ///     Deserializes an XshdColor.
        /// </summary>
        protected XshdColor(SerializationInfo info, StreamingContext context)
        {
            if (info == null) {
                throw new ArgumentNullException("info");
            }
            Name = info.GetString("Name");
            Foreground = (HighlightingBrush) info.GetValue("Foreground", typeof (HighlightingBrush));
            Background = (HighlightingBrush) info.GetValue("Background", typeof (HighlightingBrush));
            if (info.GetBoolean("HasWeight")) {
                FontWeight = System.Windows.FontWeight.FromOpenTypeWeight(info.GetInt32("Weight"));
            }
            if (info.GetBoolean("HasStyle")) {
                FontStyle = (FontStyle?) new FontStyleConverter().ConvertFromInvariantString(info.GetString("Style"));
            }
            ExampleText = info.GetString("ExampleText");
        }

        /// <summary>
        ///     Gets/sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets/sets the foreground brush.
        /// </summary>
        public HighlightingBrush Foreground { get; set; }

        /// <summary>
        ///     Gets/sets the background brush.
        /// </summary>
        public HighlightingBrush Background { get; set; }

        /// <summary>
        ///     Gets/sets the font weight.
        /// </summary>
        public FontWeight? FontWeight { get; set; }

        /// <summary>
        ///     Gets/sets the font style.
        /// </summary>
        public FontStyle? FontStyle { get; set; }

        /// <summary>
        ///     Gets/Sets the example text that demonstrates where the color is used.
        /// </summary>
        public string ExampleText { get; set; }

        #region ISerializable Members

        /// <summary>
        ///     Serializes this XshdColor instance.
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
            info.AddValue("Foreground", Foreground);
            info.AddValue("Background", Background);
            info.AddValue("HasWeight", FontWeight.HasValue);
            if (FontWeight.HasValue) {
                info.AddValue("Weight", FontWeight.Value.ToOpenTypeWeight());
            }
            info.AddValue("HasStyle", FontStyle.HasValue);
            if (FontStyle.HasValue) {
                info.AddValue("Style", FontStyle.Value.ToString());
            }
            info.AddValue("ExampleText", ExampleText);
        }

        #endregion

        /// <inheritdoc />
        public override object AcceptVisitor(IXshdVisitor visitor)
        {
            return visitor.VisitColor(this);
        }
    }
}