using System.Collections.Generic;
using System.Text;

namespace RightMenus
{
    public class TxtType : BaseRegEdit
    {
        public List<OneMenu> GetMenuList()
        {
            string[] strArr = new[]
            {
              @"HKEY_CLASSES_ROOT\txtfile\shell",
              @"HKEY_CLASSES_ROOT\txtfile\shellex\ContextMenuHandlers"

            };
            List<OneMenu> oneMenuList = GetMenuList(strArr);
            return oneMenuList;
        }
        public new string CopyBranch(string sourceBranch)
        {
            string shellPath = @"HKEY_CLASSES_ROOT\txtfile\shell";
            string shellExPath = @"HKEY_CLASSES_ROOT\txtfile\shellex\ContextMenuHandlers";
            string[] strArr = sourceBranch.Split('\\');
            StringBuilder sb = new StringBuilder();
            string result = string.Empty;
            for (int i = 0; i < strArr.Length; i++)
            {
                if (strArr[i].ToLower() == "shell".ToLower())
                {
                    for (int j = i+1; j < strArr.Length; j++)
                    {
                        sb.Append("\\" + strArr[j]);
                        
                    }
                    result = shellPath + sb.ToString();
                }
            }

            for (int i = 0; i < strArr.Length; i++)
            {
                if (strArr[i].ToLower() == "ContextMenuHandlers".ToLower())
                {
                    for (int j = i+1; j < strArr.Length; j++)
                    {
                        sb.Append("\\" + strArr[j]);

                    }
                }
                result =shellExPath + sb.ToString();
            }
            if (!string.IsNullOrEmpty(result))
            {
                RegHelper.BackUpByBranch(sourceBranch, result);
            }
            return result;
        }
    }
}