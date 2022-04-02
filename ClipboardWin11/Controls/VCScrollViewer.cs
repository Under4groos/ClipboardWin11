using System.Windows;
using System.Windows.Controls;

namespace ClipboardWin11.Controls
{
    public class VCScrollViewer : ScrollViewer
    {
        StackPanel stackPanel = new StackPanel()
        {
            Orientation = Orientation.Horizontal,
        };
        public double SpeedScroling
        {
            get; set;
        } = 1.7;
        public void Clear()
        {
            stackPanel.Children.Clear();
        }
        public bool isValid(CiItem ciItem_)
        {
            foreach (var item in stackPanel.Children)
            {
                if(item is CiItem)
                {
                    CiItem ciItem = (CiItem)item;

                    if(ciItem_.TEXT == ciItem.TEXT)
                    {
                        return true;    
                    }
                  
                }
            }
            return false;
        }
         
        public VCScrollViewer()
        {
            this.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            this.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
            this.PreviewMouseWheel += (o, e) =>
            {
                double HorizontalOffset_ = this.HorizontalOffset - e.Delta * SpeedScroling;
                this.ScrollToHorizontalOffset(HorizontalOffset_);
                ResizeAll();
            };
            this.AddChild(stackPanel);
        }
        public void ResizeAll()
        {
            foreach (FrameworkElement item in stackPanel.Children)
            {
                item.Height = this.Height;
            }
        }
        public void Add(FrameworkElement ui)
        {
            if (ui != null)
            {
                stackPanel.Children.Add(ui);

                ui.Height = this.Height;
                ui.Margin = new Thickness(10, 0, 10, 0);
            }
             
        }
    }
}
