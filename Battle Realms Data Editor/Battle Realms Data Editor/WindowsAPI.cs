namespace BattleRealmsDataEditor
{
    using System;
    using System.Runtime.InteropServices;

    public class WindowsAPI
    {
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
    }
}