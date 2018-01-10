using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Text;

namespace RightMenus
{
    public class BaseRegEdit : IBaseRegEdit
    {
        public string sid = String.Empty;

        private string[] _canNotEditArr = new[]
        {
            //计算机 
            //搜索
            @"HKEY_CLASSES_ROOT\CLSID\{20D04FE0-3AEA-1069-A2D8-08002B30309D}\shell\find",
            //管理
            @"HKEY_CLASSES_ROOT\CLSID\{20D04FE0-3AEA-1069-A2D8-08002B30309D}\shell\Manage",

            //清空回收站
            @"HKEY_CLASSES_ROOT\CLSID\{645FF040-5081-101B-9F08-00AA002F954E}\shell\empty"
        };
        public BaseRegEdit()
        {
            System.Security.Principal.WindowsIdentity currentUser = System.Security.Principal.WindowsIdentity.GetCurrent();
            this.sid = currentUser.User.ToString();
        }

        public List<OneMenu> GetMenuList(string[] strPathArr)
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
            GetFilePath(oneMenuList);
            GetVersionInfo(oneMenuList);
            return oneMenuList;
        }
        public string BackUp(string str, bool isDelete = false)
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
        public string DelBackupName(string sourceName)
        {
            return ReplaceNoCase(sourceName, MenusLib.BackUpName, "");
        }
        public string AddBackupName(string sourceName)
        {
            string shell = "shell";
            string shellEx = "shellEx";
            StringBuilder sb = new StringBuilder();
            string[] strArr = sourceName.Split('\\');
            for (int i = 0; i < strArr.Length; i++)
            {
                if (strArr[i].ToLower() == shell.ToLower())
                {
                    strArr[i] = strArr[i] + MenusLib.BackUpName;
                    break;
                }
                if (strArr[i].ToLower() == shellEx.ToLower())
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

        /// <summary>
        /// 删除项
        /// </summary>
        /// <param name="sourceName">删除项的完全路径</param>
        public void DelBranch(string sourceName)
        {
            RegHelper.DeleteBranchName(sourceName);
        }

        #region 要调用的方法
        public bool CanEdit(string path)
        {
            foreach (string str in _canNotEditArr)
            {
                if (path.Contains(str))
                {
                    return false;
                }
            }
            return true;
        }
        public string ReplaceNoCase(string sourceValue, string oldValue, string newValue)
        {
            return System.Text.RegularExpressions.Regex.Replace(sourceValue, oldValue, newValue, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }
        #endregion
        public string CopyBranch(string sourceBranch)
        {
            return string.Empty;
        }


        public void GetFilePath(List<OneMenu> oneMenuList)
        {
            if (oneMenuList == null || oneMenuList.Count <= 0)
            {
                return;
            }

            foreach (OneMenu oneMenu in oneMenuList)
            {
                try
                {
                    if (oneMenu.RegPath.Contains("{"))
                    {
                        string[] tempArr = oneMenu.RegPath.Split('\\');
                        string rootClsid = @"HKEY_CLASSES_ROOT\CLSID\" + tempArr[tempArr.Length - 1] + @"\InProcServer32";
                        oneMenu.FilePath = RegHelper.GetValueData(rootClsid, "").ToString();
                        continue;
                    }
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
                                        oneMenu.FilePath = RegHelper.GetValueData(path, "").ToString();

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
                                    }

                                }
                            }
                        }
                    }
                    else
                    {

                        if (RegHelper.ExistBranchName(regPath))
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
                catch (Exception ex)
                {
                }
            }

        }

        public void GetVersionInfo(List<OneMenu> oneMenuList)
        {
            foreach (OneMenu oneMenu in oneMenuList)
            {
                try
                {
                    string filePath = MenusLib.GetFilePath(oneMenu.FilePath);
                    oneMenu.FilePath = filePath;
                    oneMenu.FileName = MenusLib.GetFileName(filePath);
                    oneMenu.Md5 = MenusLib.GetMd5(filePath).ToUpper();

                    FileVersionInfo fileVerInfo = MenusLib.GetFileVersionInfo(filePath);
                    oneMenu.Version = fileVerInfo.ProductVersion;
                    oneMenu.Company = fileVerInfo.LegalCopyright;

                    FileInfo fileInfo = MenusLib.GetFileInfo(filePath);
                    oneMenu.Size = MenusLib.GetFileSize(fileInfo.Length) + " (" + (fileInfo.Length + "字节)");
                    oneMenu.Create = fileInfo.CreationTime.ToString("yyyy/MM/dd HH:mm:ss");
                }
                catch (Exception ex)
                {
                }
            }
        }


        public void GetFileInfo(List<OneMenu> oneMenuList)
        {
            throw new NotImplementedException();
        }
    }
}