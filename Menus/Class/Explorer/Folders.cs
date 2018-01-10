using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace RightMenus
{
    /// <summary>
    /// 文件夹
    /// </summary>
    public class Folders : BaseRegEdit
    {
        public List<OneMenu> GetMenuList()
        {
            string[] strArr = new[]
            {
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Classes\Folder\shell",
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Classes\Folder\ShellEx\ContextMenuHandlers"
            };
            List<OneMenu> oneMenuList = GetMenuList(strArr);
            return oneMenuList;
        }
    }
}