using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClipboardWin11.Controls
{
    /// <summary>
    /// Логика взаимодействия для CiItem.xaml
    /// </summary>
    public partial class CiItem : UserControl
    {
        public string TEXT = "";
        public void SetText(string str)
        {
            TEXT = str;
            if(str.Length > 100)
            {
                text__d.Text = str.Substring(0,200).Replace("  " , "").Replace("\n" , " ");
                return;
            }
            text__d.Text = TEXT;
            image__d.Visibility = Visibility.Hidden;
        }
        public void SetImage(string path_img)
        {


            Uri uri = new Uri(path_img);
            BitmapImage source = new BitmapImage();
            source.BeginInit();
            source.UriSource = uri;
            source.DecodePixelHeight = 10;
            source.DecodePixelWidth = 10;
            source.EndInit();

            image__d.Source = source;
            text__d.Visibility = Visibility.Hidden;
        }
        public void SetImage(System.Windows.Media.Imaging.BitmapSource bitmapSource)
        {
            image__d.Source = bitmapSource;
            text__d.Visibility = Visibility.Hidden;
        }
        public CiItem()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(image__d.Visibility == Visibility.Visible)
            {
                if(image__d.Source != null)
                    Clipboard.SetImage((BitmapImage)image__d.Source);
            }
            if (text__d.Visibility == Visibility.Visible)
            {
                Clipboard.SetText(TEXT);
            }
        }
    }
}
