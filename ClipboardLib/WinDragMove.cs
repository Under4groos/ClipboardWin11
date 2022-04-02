using System;
using System.Windows;



    public class WinDragMove
    {


       
        public WinDragMove(Window win_, FrameworkElement ee)
        {
            ee.MouseLeftButtonDown += (sender, e) =>
            {

                win_.DragMove();


            };
        }
    }


