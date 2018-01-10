using System;
using System.Collections.Generic;
using System.Text;

namespace RightMenus
{
    public class Contents:BaseRegEdit
    {
        public List<OneMenu> GetMenuList()
        {
            string userDirectory = @"HKEY_USERS\" + sid + @"\Software\Classes\directory\shell";
            string[] strArr = new[]
            {
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Classes\Directory\shell",
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Classes\Directory\shellex\ContextMenuHandlers",
                userDirectory
            };
            List<OneMenu> oneMenuList = GetMenuList(strArr);
            return oneMenuList;
        }

    }
}