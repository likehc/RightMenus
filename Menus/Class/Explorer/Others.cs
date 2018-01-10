using System.Collections.Generic;

namespace RightMenus
{
    public class Others : BaseRegEdit
    {
        public List<OneMenu> GetMenuList()
        {
            string[] strArr = new[]
            {
                 @"HKEY_LOCAL_MACHINE\SOFTWARE\Classes\AllFilesystemObjects\shellex\ContextMenuHandlers"
            };
            List<OneMenu> oneMenuList = GetMenuList(strArr);
            return oneMenuList;
        }
    }
}