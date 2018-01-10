using System.Collections.Generic;
using System.Text;

namespace RightMenus
{
    public class LocalDisk : BaseRegEdit
    {
        public List<OneMenu> GetMenuList()
        {
            string[] strArr = new[]
            {
                 @"HKEY_LOCAL_MACHINE\SOFTWARE\Classes\Drive\shell",
                 @"HKEY_LOCAL_MACHINE\SOFTWARE\Classes\Drive\shellex\ContextMenuHandlers"
            };
            List<OneMenu> oneMenuList = GetMenuList(strArr);
            return oneMenuList;
        }
    }
}