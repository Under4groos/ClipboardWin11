using ClipboardLib;
using ClipboardWin11.Controls;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ClipboardWin11
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KeyHook keyHook = new KeyHook(86); // 86 V
        WinScreen winScreen;
        CustomClipboard customClipboard;
        double margin_ = 0;
        WinApiWindow winApiWindow = new WinApiWindow();
        bool b = false;
        public MainWindow()
        {
            // C:\Windows\SystemApps\MicrosoftWindows.Client.CBS_cw5n1h2txyewy
            InitializeComponent();
            this.Closing += (o, e) =>
            {
                ProcessLib.ResumeProcessesByName("TextInputHost");
            };
            this.Loaded += (o, e) =>
            {
                Hidden(); 
                new WindowBlureffect(this, WindowBlureffect.AccentState.ACCENT_ENABLE_BLURBEHIND);
                ProcessLib.SuspendProcessesByName("TextInputHost");
                winApiWindow.Set(this);
                winApiWindow.HideWin_Tab();
                double size_h_ = this.Height;
                winScreen = new WinScreen(this);
                winScreen.SizeChanged += (ls, cs) =>
                {                   
                    this.Width = cs.Width; 
                    this.Height = size_h_;
                    this.Left = 0;
                    this.Top = cs.Height - size_h_ - 100;  
                };
            };
            keyHook.KeyPressed += (b) =>
            {
                if (Keyboard.IsKeyDown(Key.LWin))
                {
                    switch (this.Visibility)
                    {
                        case Visibility.Visible:
                            Hidden();
                            break;
                        case Visibility.Hidden:
                            Visible();
                    break;
                        case Visibility.Collapsed:
                            break;
                        default:
                            break;
                    }
                }
            };
            keyHook.SetHook();

            customClipboard = new CustomClipboard(this);
            customClipboard.UpdateClipboardText += (str) =>
            {
                CiItem b = new CiItem();
                b.SetText(str);

                if (!list.isValid(b))
                    list.Add(b);
            };
            customClipboard.UpdateClipboardBitmapSource += (img) =>
            { 
                CiItem b = new CiItem();
                b.SetImage(img);
                list.Add(b);
            };
        }

        private void Border_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            list.Clear();
        }
         
        void Hidden()
        {
            this.Visibility = Visibility.Hidden;
            winApiWindow.SetMostTop(false);
            GC.Collect();
        }
        void Visible()
        {
            this.Visibility = Visibility.Visible;
            winApiWindow.SetMostTop(true);
        }
        private void Border_PreviewMouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
