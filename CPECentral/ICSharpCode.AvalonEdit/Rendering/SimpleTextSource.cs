#region Using directives

using System;
using System.Windows.Media.TextFormatting;

#endregion

namespace ICSharpCode.AvalonEdit.Rendering
{
    internal sealed class SimpleTextSource : TextSource
    {
        private readonly TextRunProperties properties;
        private readonly string text;

        public SimpleTextSource(string text, TextRunProperties properties)
        {
            this.text = text;
            this.properties = properties;
        }

        public override TextRun GetTextRun(int textSourceCharacterIndex)
        {
            if (textSourceCharacterIndex < text.Length) {
                return new TextCharacters(text, textSourceCharacterIndex, text.Length - textSourceCharacterIndex,
                    properties);
            }
            return new TextEndOfParagraph(1);
        }

        public override int GetTextEffectCharacterIndexFromTextSourceCharacterIndex(int textSourceCharacterIndex)
        {
            throw new NotImplementedException();
        }

        public override TextSpan<CultureSpecificCharacterBufferRange> GetPrecedingText(int textSourceCharacterIndexLimit)
        {
            throw new NotImplementedException();
        }
    }
}