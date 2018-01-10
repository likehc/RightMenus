using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RightMenus
{
    public class RecycleBin : BaseRegEdit
    {
        public List<OneMenu> GetMenuList()
        {
            string[] strArr = new[]
            {
                @"HKEY_CLASSES_ROOT\CLSID\{645FF040-5081-101B-9F08-00AA002F954E}\shell",
                @"HKEY_CLASSES_ROOT\CLSID\{645FF040-5081-101B-9F08-00AA002F954E}\shellex\ContextMenuHandlers"
            };
            List<OneMenu> oneMenuList = GetMenuList(strArr);
            GetFilePath(oneMenuList);//获取文件地址
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
            Regex regex = new Regex("(?<=HKEY_CLASSES_ROOT\\\\).*?(?=}\\\\)", RegexOptions.IgnoreCase);
            string backupPath = regex.Replace(sourceName, "RecycleBin" + MenusLib.BackUpName).Replace("}", "");
            return backupPath;
        }
        private new string DelBackupName(string sourceName)
        {
            string delBackUpName = ReplaceNoCase(sourceName, "RecycleBin" + MenusLib.BackUpName, @"CLSID\{645FF040-5081-101B-9F08-00AA002F954E}");
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

                string[] nameArr = RegHelper.GetValueNames(regPath);
                foreach (string name in nameArr)
                {
                    if (name.ToLower() == "Icon".ToLower())
                    {
                        string iconStr = RegHelper.GetValueData(regPath, "Icon").ToString();
                        oneMenu.DefaultIcon = iconStr;
                    }
                }
                

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