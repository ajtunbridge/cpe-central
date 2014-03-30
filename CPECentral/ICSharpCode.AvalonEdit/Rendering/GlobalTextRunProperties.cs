#region Using directives

using System.Globalization;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.TextFormatting;

#endregion

namespace ICSharpCode.AvalonEdit.Rendering
{
    internal sealed class GlobalTextRunProperties : TextRunProperties
    {
        internal Brush backgroundBrush;
        internal CultureInfo cultureInfo;
        internal double fontRenderingEmSize;
        internal Brush foregroundBrush;
        internal Typeface typeface;

        public override Typeface Typeface
        {
            get { return typeface; }
        }

        public override double FontRenderingEmSize
        {
            get { return fontRenderingEmSize; }
        }

        public override double FontHintingEmSize
        {
            get { return fontRenderingEmSize; }
        }

        public override TextDecorationCollection TextDecorations
        {
            get { return null; }
        }

        public override Brush ForegroundBrush
        {
            get { return foregroundBrush; }
        }

        public override Brush BackgroundBrush
        {
            get { return backgroundBrush; }
        }

        public override CultureInfo CultureInfo
        {
            get { return cultureInfo; }
        }

        public override TextEffectCollection TextEffects
        {
            get { return null; }
        }
    }
}