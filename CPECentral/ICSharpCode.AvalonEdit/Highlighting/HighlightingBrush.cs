#region Using directives

using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Media;
using ICSharpCode.AvalonEdit.Rendering;

#endregion

namespace ICSharpCode.AvalonEdit.Highlighting
{
    /// <summary>
    ///     A brush used for syntax highlighting. Can retrieve a real brush on-demand.
    /// </summary>
    [Serializable]
    public abstract class HighlightingBrush
    {
        /// <summary>
        ///     Gets the real brush.
        /// </summary>
        /// <param name="context">The construction context. context can be null!</param>
        public abstract Brush GetBrush(ITextRunConstructionContext context);

        /// <summary>
        ///     Gets the color of the brush.
        /// </summary>
        /// <param name="context">The construction context. context can be null!</param>
        public virtual Color? GetColor(ITextRunConstructionContext context)
        {
            var scb = GetBrush(context) as SolidColorBrush;
            if (scb != null) {
                return scb.Color;
            }
            return null;
        }
    }

    /// <summary>
    ///     Highlighting brush implementation that takes a frozen brush.
    /// </summary>
    [Serializable]
    internal sealed class SimpleHighlightingBrush : HighlightingBrush, ISerializable
    {
        private readonly SolidColorBrush brush;

        public SimpleHighlightingBrush(SolidColorBrush brush)
        {
            brush.Freeze();
            this.brush = brush;
        }

        public SimpleHighlightingBrush(Color color) : this(new SolidColorBrush(color))
        {
        }

        private SimpleHighlightingBrush(SerializationInfo info, StreamingContext context)
        {
            brush = new SolidColorBrush((Color) ColorConverter.ConvertFromString(info.GetString("color")));
            brush.Freeze();
        }

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("color", brush.Color.ToString(CultureInfo.InvariantCulture));
        }

        #endregion

        public override Brush GetBrush(ITextRunConstructionContext context)
        {
            return brush;
        }

        public override string ToString()
        {
            return brush.ToString();
        }
    }

    /// <summary>
    ///     HighlightingBrush implementation that finds a brush using a resource.
    /// </summary>
    [Serializable]
    internal sealed class SystemColorHighlightingBrush : HighlightingBrush, ISerializable
    {
        private readonly PropertyInfo property;

        public SystemColorHighlightingBrush(PropertyInfo property)
        {
            Debug.Assert(property.ReflectedType == typeof (SystemColors));
            Debug.Assert(typeof (Brush).IsAssignableFrom(property.PropertyType));
            this.property = property;
        }

        private SystemColorHighlightingBrush(SerializationInfo info, StreamingContext context)
        {
            property = typeof (SystemColors).GetProperty(info.GetString("propertyName"));
            if (property == null) {
                throw new ArgumentException("Error deserializing SystemColorHighlightingBrush");
            }
        }

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("propertyName", property.Name);
        }

        #endregion

        public override Brush GetBrush(ITextRunConstructionContext context)
        {
            return (Brush) property.GetValue(null, null);
        }

        public override string ToString()
        {
            return property.Name;
        }
    }
}