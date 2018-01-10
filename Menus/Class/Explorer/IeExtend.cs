using System;
using System.Collections.Generic;
using System.Text;

namespace RightMenus
{
    public class IeExtend : BaseRegEdit
    {
        public List<OneMenu> GetMenuList()
        {
            string[] strArr = new[]
            {
                 @"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\MenuExt"
            };
            List<OneMenu> oneMenuList = GetMenuList(strArr);
            return oneMenuList;
        }
        public new List<OneMenu> GetMenuList(string[] strPathArr)
        {
            List<OneMenu> oneMenuList = new List<OneMenu>();
            foreach (string path in strPathArr)
            {
                string sourcePath = path;
                List<OneMenu> sourceOneMenuList = MenusLib.GetMenuList(sourcePath);

                string backupPath = AddBackupName(sourcePath);
                List<OneMenu> backupOneMenuList = MenusLib.GetMenuList(backupPath);
                oneMenuList = oneMenuList.AddOneMenuList(sourceOneMenuList).AddOneMenuList(backupOneMenuList);
            }
            return oneMenuList;
        }
        public new string BackUp(string str, bool isDelete = false)
        {
            string sourcePath = str;
            string backupPath = String.Empty;
            if (CanEdit(str))
            {
                if (str.Contains(MenusLib.BackUpName))
                {
                    backupPath = DelBackupName(str);
                }
                else
                {
                    backupPath = AddBackupName(str); ;
                }
                if (isDelete)
                {
                    RegHelper.BackUpByBranch(sourcePath, backupPath, true);
                }
                else
                {
                    RegHelper.BackUpByBranch(sourcePath, backupPath);
                }
            }
            return backupPath;
        }
        public new string AddBackupName(string sourceName)
        {
            string menuExt = "MenuExt";
            StringBuilder sb = new StringBuilder();
            string[] strArr = sourceName.Split('\\');
            for (int i = 0; i < strArr.Length; i++)
            {
                if (strArr[i].ToLower() == menuExt.ToLower())
                {
                    strArr[i] = strArr[i] + MenusLib.BackUpName;
                    break;
                }
            }
            for (int j = 0; j < strArr.Length; j++)
            {
                if (j == strArr.Length - 1)
                {
                    sb.Append(strArr[j]);
                }
                else
                {
                    sb.Append(strArr[j] + "\\");
                }
            }
            return sb.ToString();
        }
        private new string DelBackupName(string sourceName)
        {
            string delBackUpName = ReplaceNoCase(sourceName,  MenusLib.BackUpName, "");
            return delBackUpName;
        }
    }
}