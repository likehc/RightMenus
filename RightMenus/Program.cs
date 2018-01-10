using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RightMenus
{
    static class Program
    {
        [DllImport("user32.dll")]
        private static extern bool FlashWindow(IntPtr hWnd, bool bInvert);
        [DllImport("user32.dll")]
        private static extern bool FlashWindowEx(int pfwi);
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
             bool runone;
            System.Threading.Mutex run = new System.Threading.Mutex(true, "single_test", out runone);
            if (runone)
            {
                run.ReleaseMutex();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new RightMenus());
                RightMenus frm = new RightMenus();

                int hdc = frm.Handle.ToInt32();
                Application.Run(frm);
                IntPtr a = new IntPtr(hdc);
            }

        }

    }
}
