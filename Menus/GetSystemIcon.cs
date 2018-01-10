using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace RightMenus
{
    public class GetSystemIcon
    {
        [DllImport("shell32.dll")]
        private static extern int ExtractIcon(IntPtr hInst, string lpFileName, int nIndex);
        public virtual Icon extractIcon(string FileName, int iIndex)
        {
            try
            {
                IntPtr hInst = IntPtr.Zero;
                IntPtr hIcon = (IntPtr)ExtractIcon(hInst, FileName, iIndex);
                if (!hIcon.Equals(null))
                {
                    Icon icon = Icon.FromHandle(hIcon);
                    return icon;
                }
            }
            catch (Exception ex)
            {
                return null;

            }
            return null;
        }
    }
}