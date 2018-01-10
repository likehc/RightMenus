using System;
using System.Collections.Generic;
using System.Text;

namespace RightMenus
{
  
    public class Computer:BaseRegEdit
    {
        public List<OneMenu> GetMenuList()
        {
            string[] strArr = new[]
            {
                @"HKEY_CLASSES_ROOT\CLSID\{20D04FE0-3AEA-1069-A2D8-08002B30309D}\shell"
            };
            List<OneMenu> oneMenuList = GetMenuList(strArr);
            GetFilePath(oneMenuList);//获取文件地址
            GetVersionInfo(oneMenuList);
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
            string[] strArr = sourceName.Split('\\');
            string subKey = String.Empty;
            if (strArr.Length>=5)
            {
                subKey ="\\"+ strArr[4];
            }
            string backupPath =  @"HKEY_CLASSES_ROOT\" + "Computer" + MenusLib.BackUpName + "\\" + strArr[3] + subKey;
            return backupPath;
        }
        private new string DelBackupName(string sourceName)
        {
            string delBackUpName = ReplaceNoCase(sourceName, "Computer" + MenusLib.BackUpName, @"CLSID\{20D04FE0-3AEA-1069-A2D8-08002B30309D}");
           
            return delBackUpName;
        }

        public new void GetFilePath(List<OneMenu> oneMenuList)
        {
            if (oneMenuList == null || oneMenuList.Count <= 0)
            {
                return;
            }
            foreach (OneMenu oneMenu in oneMenuList)
            {
                string regPath = oneMenu.RegPath;
                string[] branchArr = RegHelper.GetBranchNames(regPath);

                if (branchArr.Length > 0)
                {
                    foreach (string branch in branchArr)
                    {
                        if (branch.ToLower() == "command".ToLower())
                        {
                            string valuePath = regPath + @"\command";
                            string[] valueNameArr = RegHelper.GetValueNames(valuePath);
                            foreach (string value in valueNameArr)
                            {
                                if (value.ToLower() == "DelegateExecute".ToLower())
                                {
                                    string cLSID = RegHelper.GetValueData(valuePath, "DelegateExecute").ToString();
                                    string path = @"HKEY_CLASSES_ROOT\CLSID\" + cLSID + @"\InProcServer32";
                                    bool b = RegHelper.ExistBranchName(path);
                                    if (!b)
                                    {
                                        path = @"HKEY_CLASSES_ROOT\Wow6432Node\CLSID\" + cLSID + @"\InProcServer32";

                                    }
                                    string s = RegHelper.GetValueData(path, "").ToString();
                                    oneMenu.FilePath = s;

                                    string desPath = path.Replace(@"\InProcServer32", "");
                                    string[] valueNamesArr = RegHelper.GetValueNames(desPath);
                                    foreach (string valueName in valueNamesArr)
                                    {
                                        if (valueName == string.Empty)
                                        {
                                            oneMenu.Description = RegHelper.GetValueData(desPath, "").ToString();
                                        }
                                    }
                                }
                                if (value == string.Empty)
                                {
                                    string s = RegHelper.GetValueData(valuePath, "").ToString();
                                    oneMenu.FilePath = s;
                                    break;
                                }

                            }
                        }
                    }
                }
                else
                {
                    string cLSID = RegHelper.GetValueData(regPath, "").ToString();
                    string path = @"HKEY_CLASSES_ROOT\CLSID\" + cLSID + @"\InProcServer32";
                    bool b = RegHelper.ExistBranchName(path);
                    if (!b)
                    {
                        path = @"HKEY_CLASSES_ROOT\Wow6432Node\CLSID\" + cLSID + @"\InProcServer32";

                    }
                    string s = RegHelper.GetValueData(path, "").ToString();
                    oneMenu.FilePath = s;

                    string desPath = path.Replace(@"\InProcServer32", "");
                    string[] valueNamesArr = RegHelper.GetValueNames(desPath);
                    foreach (string valueName in valueNamesArr)
                    {
                        if (valueName == string.Empty)
                        {
                            oneMenu.Description = RegHelper.GetValueData(desPath, "").ToString();
                        }
                    }
                }
            }


        }


       
    }

}