using System;
using System.IO;
using System.Threading;
using System.Windows;
namespace ClipboardLib
{
    public class CustomClipboard
    {
        ThreadTimer timer;

        public Action<string> UpdateClipboardText;
        //public Action<string> UpdateClipboardBitmapSource;
        public Action<System.Windows.Media.Imaging.BitmapSource> UpdateClipboardBitmapSource;

        string CUR_STRING_ = "";
        string LAST_STRING_ = "";

        System.Windows.Media.Imaging.BitmapSource BitmapSource;
        System.Windows.Media.Imaging.BitmapSource LastBitmapSource;

        Random random = new Random();

        public CustomClipboard(System.Windows.Window window)
        {



            timer = new ThreadTimer(window);
            timer.TickTime = 100;
            timer.Tick += (o, e) =>
            {
                try
                {
                    if (Clipboard.ContainsText())
                    {
                        LAST_STRING_ = Clipboard.GetText();
                        if (CUR_STRING_ != LAST_STRING_)
                        {
                            CUR_STRING_ = LAST_STRING_;
                            if (UpdateClipboardText != null)
                            {
                                UpdateClipboardText(CUR_STRING_);
                            }
                        }

                    }
                    if (Clipboard.ContainsImage())
                    {

                        
                        if (UpdateClipboardBitmapSource != null)
                        {
                            LastBitmapSource = Clipboard.GetImage();

                            if (BitmapSource == null && LastBitmapSource != null)
                            {



                                //string s = SaveImage();
                                //Thread.Sleep(1000);
                                UpdateClipboardBitmapSource(LastBitmapSource);

                                BitmapSource = LastBitmapSource;
                                return;
                            }
                            if (BitmapSource != null && LastBitmapSource != null)
                            {
                                if (LastBitmapSource.PixelWidth != BitmapSource.PixelWidth || LastBitmapSource.PixelHeight != BitmapSource.PixelHeight)
                                {
                                    
                                    UpdateClipboardBitmapSource(LastBitmapSource);
                                    BitmapSource = LastBitmapSource;
                                }
                            }

                        }


                    }
                }
                catch (Exception)
                {
                    CUR_STRING_ = LAST_STRING_ = "";
                }
            };
            timer.initialize();

        }
        public string SaveImage()
        {
            string path_ = Path.Combine("images", $"{random.Next(0, 1000)}_{random.Next(0, 1000)}.png");
            if (!Directory.Exists("images"))
                Directory.CreateDirectory("images");
            if(LastBitmapSource != null)
                LastBitmapSource.ImageSave(path_);
            return path_;
        }
    }
}
