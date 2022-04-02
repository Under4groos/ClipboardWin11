using System;
using System.Windows;

public class WinScreen
{
    public Action<Size, Size> SizeChanged;
    ThreadTimer timer;
    //IntPtr Handle = IntPtr.Zero;
    Size LAST_SIZE_SCREEN;
    Size CUR_SIZE_SCREEN;
    public WinScreen(Window win)
    {
        //Handle = new System.Windows.Interop.WindowInteropHelper(win).Handle;
        timer = new ThreadTimer(win);
        timer.TickTime = 1000;
        timer.Tick += (o, e) =>
        {

            CUR_SIZE_SCREEN = new Size(System.Windows.SystemParameters.PrimaryScreenWidth, System.Windows.SystemParameters.PrimaryScreenHeight);

            if (SizeChanged != null && !this.equals(CUR_SIZE_SCREEN, LAST_SIZE_SCREEN))
            {
                SizeChanged(LAST_SIZE_SCREEN, CUR_SIZE_SCREEN);
                LAST_SIZE_SCREEN = CUR_SIZE_SCREEN;
            }
        };
        timer.initialize();
    }
    public bool equals(Size s, Size ss)
    {
        if (ss == null || s == null)
            return false;
        return s.Width == ss.Width && s.Height == ss.Height;
    }
}
