#region Using directives

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.TextFormatting;
using ICSharpCode.AvalonEdit.Utils;

#endregion

namespace ICSharpCode.AvalonEdit.Rendering
{
    /// <summary>
    ///     <see cref="TextRunProperties" /> implementation that allows changing the properties.
    ///     A <see cref="VisualLineElementTextRunProperties" /> instance usually is assigned to a single
    ///     <see cref="VisualLineElement" />.
    /// </summary>
    public class VisualLineElementTextRunProperties : TextRunProperties, ICloneable
    {
        private Brush backgroundBrush;
        private BaselineAlignment baselineAlignment;
        private CultureInfo cultureInfo;
        private double fontHintingEmSize;
        private double fontRenderingEmSize;
        private Brush foregroundBrush;
        private NumberSubstitution numberSubstitution;
        private TextDecorationCollection textDecorations;
        private TextEffectCollection textEffects;
        private Typeface typeface;
        private TextRunTypographyProperties typographyProperties;

        /// <summary>
        ///     Creates a new VisualLineElementTextRunProperties instance that copies its values
        ///     from the specified <paramref name="textRunProperties" />.
        ///     For the <see cref="TextDecorations" /> and <see cref="TextEffects" /> collections, deep copies
        ///     are created if those collections are not frozen.
        /// </summary>
        public VisualLineElementTextRunProperties(TextRunProperties textRunProperties)
        {
            if (textRunProperties == null) {
                throw new ArgumentNullException("textRunProperties");
            }
            backgroundBrush = textRunProperties.BackgroundBrush;
            baselineAlignment = textRunProperties.BaselineAlignment;
            cultureInfo = textRunProperties.CultureInfo;
            fontHintingEmSize = textRunProperties.FontHintingEmSize;
            fontRenderingEmSize = textRunProperties.FontRenderingEmSize;
            foregroundBrush = textRunProperties.ForegroundBrush;
            typeface = textRunProperties.Typeface;
            textDecorations = textRunProperties.TextDecorations;
            if (textDecorations != null && !textDecorations.IsFrozen) {
                textDecorations = textDecorations.Clone();
            }
            textEffects = textRunProperties.TextEffects;
            if (textEffects != null && !textEffects.IsFrozen) {
                textEffects = textEffects.Clone();
            }
            typographyProperties = textRunProperties.TypographyProperties;
            numberSubstitution = textRunProperties.NumberSubstitution;
        }

        /// <inheritdoc />
        public override Brush BackgroundBrush
        {
            get { return backgroundBrush; }
        }

        /// <inheritdoc />
        public override BaselineAlignment BaselineAlignment
        {
            get { return baselineAlignment; }
        }

        /// <inheritdoc />
        public override CultureInfo CultureInfo
        {
            get { return cultureInfo; }
        }

        /// <inheritdoc />
        public override double FontHintingEmSize
        {
            get { return fontHintingEmSize; }
        }

        /// <inheritdoc />
        public override double FontRenderingEmSize
        {
            get { return fontRenderingEmSize; }
        }

        /// <inheritdoc />
        public override Brush ForegroundBrush
        {
            get { return foregroundBrush; }
        }

        /// <inheritdoc />
        public override Typeface Typeface
        {
            get { return typeface; }
        }

        /// <summary>
        ///     Gets the text decorations. The value may be null, a frozen <see cref="TextDecorationCollection" />
        ///     or an unfrozen <see cref="TextDecorationCollection" />.
        ///     If the value is an unfrozen <see cref="TextDecorationCollection" />, you may assume that the
        ///     collection instance is only used for this <see cref="TextRunProperties" /> instance and it is safe
        ///     to add <see cref="TextDecoration" />s.
        /// </summary>
        public override TextDecorationCollection TextDecorations
        {
            get { return textDecorations; }
        }

        /// <summary>
        ///     Gets the text effects. The value may be null, a frozen <see cref="TextEffectCollection" />
        ///     or an unfrozen <see cref="TextEffectCollection" />.
        ///     If the value is an unfrozen <see cref="TextEffectCollection" />, you may assume that the
        ///     collection instance is only used for this <see cref="TextRunProperties" /> instance and it is safe
        ///     to add <see cref="TextEffect" />s.
        /// </summary>
        public override TextEffectCollection TextEffects
        {
            get { return textEffects; }
        }

        /// <summary>
        ///     Gets the typography properties for the text run.
        /// </summary>
        public override TextRunTypographyProperties TypographyProperties
        {
            get { return typographyProperties; }
        }

        /// <summary>
        ///     Gets the number substitution settings for the text run.
        /// </summary>
        public override NumberSubstitution NumberSubstitution
        {
            get { return numberSubstitution; }
        }

        #region ICloneable Members

        object ICloneable.Clone()
        {
            return Clone();
        }

        #endregion

        /// <summary>
        ///     Creates a copy of this instance.
        /// </summary>
        public virtual VisualLineElementTextRunProperties Clone()
        {
            return new VisualLineElementTextRunProperties(this);
        }

        /// <summary>
        ///     Sets the <see cref="BackgroundBrush" />.
        /// </summary>
        public void SetBackgroundBrush(Brush value)
        {
            ExtensionMethods.CheckIsFrozen(value);
            backgroundBrush = value;
        }

        /// <summary>
        ///     Sets the <see cref="BaselineAlignment" />.
        /// </summary>
        public void SetBaselineAlignment(BaselineAlignment value)
        {
            baselineAlignment = value;
        }

        /// <summary>
        ///     Sets the <see cref="CultureInfo" />.
        /// </summary>
        public void SetCultureInfo(CultureInfo value)
        {
            if (value == null) {
                throw new ArgumentNullException("value");
            }
            cultureInfo = value;
        }

        /// <summary>
        ///     Sets the <see cref="FontHintingEmSize" />.
        /// </summary>
        public void SetFontHintingEmSize(double value)
        {
            fontHintingEmSize = value;
        }

        /// <summary>
        ///     Sets the <see cref="FontRenderingEmSize" />.
        /// </summary>
        public void SetFontRenderingEmSize(double value)
        {
            fontRenderingEmSize = value;
        }

        /// <summary>
        ///     Sets the <see cref="ForegroundBrush" />.
        /// </summary>
        public void SetForegroundBrush(Brush value)
        {
            ExtensionMethods.CheckIsFrozen(value);
            foregroundBrush = value;
        }

        /// <summary>
        ///     Sets the <see cref="Typeface" />.
        /// </summary>
        public void SetTypeface(Typeface value)
        {
            if (value == null) {
                throw new ArgumentNullException("value");
            }
            typeface = value;
        }

        /// <summary>
        ///     Sets the <see cref="TextDecorations" />.
        /// </summary>
        public void SetTextDecorations(TextDecorationCollection value)
        {
            ExtensionMethods.CheckIsFrozen(value);
            textDecorations = value;
        }

        /// <summary>
        ///     Sets the <see cref="TextEffects" />.
        /// </summary>
        public void SetTextEffects(TextEffectCollection value)
        {
            ExtensionMethods.CheckIsFrozen(value);
            textEffects = value;
        }

        /// <summary>
        ///     Sets the <see cref="TypographyProperties" />.
        /// </summary>
        public void SetTypographyProperties(TextRunTypographyProperties value)
        {
            typographyProperties = value;
        }

        /// <summary>
        ///     Sets the <see cref="NumberSubstitution" />.
        /// </summary>
        public void SetNumberSubstitution(NumberSubstitution value)
        {
            numberSubstitution = value;
        }
    }
}