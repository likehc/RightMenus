using System;
using System.Collections.Generic;
using System.Text;

namespace RightMenus
{
    public class ExeType : BaseRegEdit
    {
        public List<OneMenu> GetMenuList()
        {
            string[] strArr = new[]
            {
                @"HKEY_CLASSES_ROOT\exefile\shell",
                @"HKEY_CLASSES_ROOT\exefile\shellex\ContextMenuHandlers"
            };
            List<OneMenu> oneMenuList = GetMenuList(strArr);
            return oneMenuList;
        }
    }
}