using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;


public static class WinApi
{
    public delegate IntPtr KeyboardHookProc(int code, IntPtr wParam, IntPtr lParam);
    //========================================================
    [DllImport("user32.dll")]
    public static extern IntPtr GetForegroundWindow();
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
    [DllImport("user32.dll")]
    public static extern IntPtr SetWindowsHookEx(int idHook, IntPtr callback, IntPtr hInstance, uint threadId);
    [DllImport("user32.dll")]
    public static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);
    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
    [DllImport("user32.dll")]
    public static extern bool SetCursorPos(int X, int Y);
 
    [DllImport("user32.dll")]
    public static extern short GetAsyncKeyState(UInt16 virtualKeyCode);
    [DllImport("user32.dll")]
    public static extern short VkKeyScan(char ch);
    [DllImport("kernel32.dll")]
    public static extern IntPtr LoadLibrary(string lpFileName);
    [DllImport("user32.dll")]
    public static extern IntPtr SetWindowsHookEx(int idHook, KeyboardHookProc callback, IntPtr hInstance, uint threadId);
    [DllImport("user32.dll")]
    public static extern bool UnhookWindowsHookEx(IntPtr hInstance);
    //========================================================
   

}

