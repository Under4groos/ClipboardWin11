using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace ClipboardWin11.Controls
{
    public class CLRichTextBox : RichTextBox
    {
        public CLRichTextBox()
        {
            this.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            this.BorderThickness = new System.Windows.Thickness();

        }
        public string Text
        {
            get
            {
                return new TextRange(this.Document.ContentStart, this.Document.ContentEnd).Text;
            }
            set
            {
                Clear();
                AppendText(value, "#ffff");
            }
        }
        public void AppendText(string text, string color)
        {
            BrushConverter bc = new BrushConverter();
            TextRange tr = new TextRange(this.Document.ContentEnd, this.Document.ContentEnd);
            tr.Text = text;
            try
            {
                tr.ApplyPropertyValue(TextElement.ForegroundProperty,
                    bc.ConvertFromString(color));
            }
            catch (FormatException) { }
        }
        public void Clear()
        {
            this.Document.Blocks.Clear();
        }
    }
}
