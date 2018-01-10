using System;
using System.Collections.Generic;
using System.Text;

namespace RightMenus
{
    public class LnkFile : BaseRegEdit
    {
        public List<OneMenu> GetMenuList()
        {
            string[] strArr = new[]
            {
               @"HKEY_CLASSES_ROOT\lnkfile\shell",
               @"HKEY_CLASSES_ROOT\lnkfile\shellex\ContextMenuHandlers"
            };
            List<OneMenu> oneMenuList = GetMenuList(strArr);
            return oneMenuList;
        }
    }
}