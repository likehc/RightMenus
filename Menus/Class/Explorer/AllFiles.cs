using System.Collections.Generic;

namespace RightMenus
{
    public class AllFiles:BaseRegEdit
    {
        public List<OneMenu> GetMenuList()
        {
            string userAllFiles = @"HKEY_USERS\" + sid + @"\Software\Classes\*\shell";
            string[] strArr = new[]
            {
                 @"HKEY_CLASSES_ROOT\*\shell",
                 @"HKEY_CLASSES_ROOT\*\shellex\ContextMenuHandlers",
                 userAllFiles
            };
            List<OneMenu> oneMenuList = GetMenuList(strArr);
            return oneMenuList;
        }
       
    }
}