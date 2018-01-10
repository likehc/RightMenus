using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RightMenus
{
    /// <summary>
    /// 新建
    /// </summary>
    public class New : BaseRegEdit
    {
        public List<OneMenu> GetMenuList()
        {
            //读取缓存区域
            string sourcePath = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Discardable\PostSetup\ShellNew";
            string[] sourceNameArr = (string[])RegHelper.GetValueData(sourcePath, "Classes");
            List<OneMenu> sourceOneMenuList = new List<OneMenu>();
            foreach (string name in sourceNameArr)
            {
                string path = "HKEY_CLASSES_ROOT" + @"\" + name;
                string shellNewPath = string.Empty;
                bool keyExist = RegHelper.ExistBranchName(path, "ShellNew", out shellNewPath);
                if (keyExist)
                {
                    OneMenu oneMenu = new OneMenu();
                    if (!path.Contains(MenusLib.BackUpName))
                    {
                        oneMenu.Checked = true;
                    }
                    oneMenu.RegPath = shellNewPath;
                    oneMenu.Name = name;
                    sourceOneMenuList.Add(oneMenu);
                }
            }

            string sourcePath2 = "HKEY_CLASSES_ROOT" + @"\New" + MenusLib.BackUpName;
            string[] backupNameArr = RegHelper.GetBranchNames(sourcePath2);
            
            List<OneMenu> sourceOneMenuList2 = new List<OneMenu>();
            if (backupNameArr != null)
            {
                foreach (string name in backupNameArr)
                {
                    string path = sourcePath2 + "\\" + name;
                    string shellNewPath = string.Empty;
                    bool keyExist = RegHelper.ExistBranchName(path, "ShellNew",out shellNewPath);

                    if (keyExist)
                    {
                        OneMenu oneMenu = new OneMenu();
                        oneMenu.RegPath = shellNewPath;
                        oneMenu.Name = name;
                        sourceOneMenuList2.Add(oneMenu);
                    }
                }   
            }
            
            List<OneMenu> oneMenuList = sourceOneMenuList.AddOneMenuList(sourceOneMenuList2);
            GetFilePath(oneMenuList);
            GetVersionInfo(oneMenuList);
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
                string sourcePathShell = sourcePath + "\\ShellNew";
                string backupPathShell = backupPath + "\\ShellNew";
                if (isDelete)
                {
                    RegHelper.BackUpByBranch(sourcePathShell, backupPathShell, true);
                }
                else
                {
                    RegHelper.BackUpByBranch(sourcePathShell, backupPathShell);
                }
                
            }
            return backupPath;
        }
        public new string AddBackupName(string sourceName)
        {
            StringBuilder sb = new StringBuilder();
            string[] strArr = sourceName.Split('\\');
            strArr[0] = strArr[0] + "\\New" + MenusLib.BackUpName;

            for (int i = 0; i < strArr.Length; i++)
            {
                if (i == strArr.Length - 1)
                {
                    sb.Append(strArr[i]);
                }
                else
                {
                    sb.Append(strArr[i] + "\\");
                }
            }
            return sb.ToString();
        }
        private new string DelBackupName(string sourceName)
        {
            string delBackUpName = ReplaceNoCase(sourceName, "\\\\New" + MenusLib.BackUpName, "");
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
                try
                {
                    string regPathTemp = oneMenu.RegPath;
                    if (regPathTemp.Contains(MenusLib.BackUpName))
                    {
                        regPathTemp = regPathTemp.Replace("\\New" + MenusLib.BackUpName, "");
                    }
                    string[] namePathArr = regPathTemp.Split('\\');
                    string regPath = namePathArr[0] + "\\" + namePathArr[1];
                    string des =RegHelper.GetValueData(regPath, "").ToString();
                    oneMenu.Description = des;
                    string rootSid = RegHelper.GetValueData(regPath, "").ToString();
                    string rootPath = @"HKEY_CLASSES_ROOT\" + rootSid + @"\shell\open\command";
                    bool existBranch = RegHelper.ExistBranchName(rootPath);
                    if (existBranch)
                    {
                        string filePath = RegHelper.GetValueData(rootPath, "").ToString();
                        oneMenu.FilePath = filePath;
                    }
                    else
                    {
                        
                    }
                    

                    string defaultIcon = @"HKEY_CLASSES_ROOT\" + rootSid + @"\DefaultIcon";
                    string defaultIconPath = RegHelper.GetValueData(defaultIcon, "").ToString();
                    oneMenu.DefaultIcon = defaultIconPath;

                }
                catch (Exception)
                {
                    
                }
            }
        }
    }
}