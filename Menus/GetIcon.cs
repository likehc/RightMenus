using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace RightMenus
{
    public class GetIcon
    {

        //details: https://msdn.microsoft.com/en-us/library/windows/desktop/ms648075(v=vs.85).aspx
        //Creates an array of handles to icons that are extracted from a specified file.
        //This function extracts from executable (.exe), DLL (.dll), icon (.ico), cursor (.cur), animated cursor (.ani), and bitmap (.bmp) files. 
        //Extractions from Windows 3.x 16-bit executables (.exe or .dll) are also supported.
        [DllImport("User32.dll")]
        public static extern int PrivateExtractIcons(
            string lpszFile, //file name
            int nIconIndex,  //The zero-based index of the first icon to extract.
            int cxIcon,      //The horizontal icon size wanted.
            int cyIcon,      //The vertical icon size wanted.
            IntPtr[] phicon, //(out) A pointer to the returned array of icon handles.
            int[] piconid,   //(out) A pointer to a returned resource identifier.
            int nIcons,      //The number of icons to extract from the file. Only valid when *.exe and *.dll
            int flags        //Specifies flags that control this function.
        );

        //details:https://msdn.microsoft.com/en-us/library/windows/desktop/ms648063(v=vs.85).aspx
        //Destroys an icon and frees any memory the icon occupied.
        [DllImport("User32.dll")]
        public static extern bool DestroyIcon(
            IntPtr hIcon //A handle to the icon to be destroyed. The icon must not be in use.
        );

        public List<Icon> GetIconLists(string filePath)
        {
            List<Icon> iconList =  new List<Icon>();
            //选中文件中的图标总数
            int iconTotalCount = PrivateExtractIcons(filePath, 0, 0, 0, null, null, 0, 0);

            //用于接收获取到的图标指针
            IntPtr[] hIcons = new IntPtr[iconTotalCount];

            //对应的图标id
            int[] ids = new int[iconTotalCount];


            //成功获取到的图标个数
            int successCount = PrivateExtractIcons(filePath, 0, 256, 256, hIcons, ids, iconTotalCount, 0);

            //if (successCount > 0)
            //{
            //    Icon ico = Icon.FromHandle(hIcons[0]);
            //    using (var myIcon = ico.ToBitmap())
            //    {
            //        myIcon.Save("c:\\22221.png", ImageFormat.Png);
            //    }
            //}

            for (int i = 0; i < successCount; i++)
            {
                //指针为空，跳过
                if (hIcons[i] == IntPtr.Zero) continue;
                Icon ico = Icon.FromHandle(hIcons[i]);
                iconList.Add(ico);
            }
            return iconList;
        }
    }
}