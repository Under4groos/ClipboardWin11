using System;
using System.Runtime.InteropServices;


public class KeyHook : IDisposable
{
    private const int WH_KEYBOARD_LL = 13;
    private const int WH_KEYDOWN = 0x0100;
    private int _key;
    public Action<bool> KeyPressed;
    bool is_down = false;
    private WinApi.KeyboardHookProc _proc;
    private IntPtr _hHook = IntPtr.Zero;


    public KeyHook(int keyCode)
    {
        _key = keyCode;
        _proc = HookProc;
    }
    public void SetHook()
    {
        _hHook = WinApi.SetWindowsHookEx(WH_KEYBOARD_LL, _proc, WinApi.LoadLibrary("User32"), 0);
    }
    public void Dispose()
    {
        UnHook();
    }
    public void UnHook() { WinApi.UnhookWindowsHookEx(_hHook); }
    private IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam)
    {
        if ((code >= 0 && wParam == (IntPtr)WH_KEYDOWN) && Marshal.ReadInt32(lParam) == _key)
        {
            if (KeyPressed != null)
            {
                is_down = !is_down;
                KeyPressed(is_down);
            }
        }
        return WinApi.CallNextHookEx(_hHook, code, (int)wParam, lParam);
    }
}

