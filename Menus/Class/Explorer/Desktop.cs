using System;
using System.Collections.Generic;
using System.Text;

namespace RightMenus
{
    public class Desktop : BaseRegEdit
    {
        public List<OneMenu> GetMenuList()
        {
            //HKEY_LOCAL_MACHINE\SOFTWARE\Classes\Directory\Background\shell  // 此处是目录扩展项可以忽略
            string userBackground = @"HKEY_USERS\" + sid + @"\Software\Classes\directory\background\shell";
            string[] strArr = new[]
            {
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Classes\Directory\Background\shell",
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Classes\Directory\Background\shellex\ContextMenuHandlers",
                userBackground
            };
            List<OneMenu> oneMenuList = GetMenuList(strArr);
            return oneMenuList;
        }
    }
}