using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace RightMenus
{
    public class SendTo
    {
        private string _sendToSource;
        private string _sendToBackup;

        public SendTo()
        {
            string appData = System.Environment.GetEnvironmentVariable("APPDATA");//%APPDATA\Microsoft\Windows\SendTo
            this._sendToSource = appData == null ? null : appData + @"\Microsoft\Windows\SendTo";
            this._sendToBackup = appData == null ? null : appData + @"\Microsoft\Windows\SendTo" + MenusLib.BackUpName;
        }
        public List<OneMenu> GetMenuList()
        {
            //string[] strArr = new[]
            //{
            //    @"HKEY_CLASSES_ROOT\CLSID\{20D04FE0-3AEA-1069-A2D8-08002B30309D}\shell"
            //};
            
            List<OneMenu> oneMenuList=  new List<OneMenu>(); //= GetMenuList(strArr)
            if (Directory.Exists(_sendToSource))
            {
                var files = Directory.GetFiles(_sendToSource, "*.*");
                foreach (var file in files)
                {
                    OneMenu oneMenu = new OneMenu();
                    oneMenu.Checked = true;
                    oneMenu.FileName = MenusLib.GetFileName(file);

                    oneMenu.Name = MenusLib.GetFileName(file);
                    oneMenu.FilePath = GetFilePath(file);
                    oneMenu.RegPath = file;
                    oneMenuList.Add(oneMenu);
                }
            }
            if (Directory.Exists(_sendToBackup))
            {
                var files = Directory.GetFiles(_sendToBackup, "*.*");
                foreach (var file in files)
                {
                    OneMenu oneMenu = new OneMenu();
                    oneMenu.Checked = false;
                    oneMenu.FileName = MenusLib.GetFileName(file);
                    oneMenu.Name = MenusLib.GetFileName(file);
                    oneMenu.FilePath = GetFilePath(file);
                    oneMenu.RegPath = file;

                    oneMenuList.Add(oneMenu);
                }
            }
            else
            {
                Directory.CreateDirectory(_sendToBackup);
            }
            GetVersionInfo(oneMenuList);
            return oneMenuList;
        }

        private void GetVersionInfo(List<OneMenu> oneMenuList)
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
        private string GetFilePath(string file)
        {
            string result = string.Empty;
            if (file.ToLower().EndsWith(".lnk"))
            {
                IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
                IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(file);
                result = shortcut.TargetPath;
            }
            else
            {
                result = file;
            }
            return result;
        }
        public string BackUp(string str, bool isDelete = false)
        {
            string sourcePath = str;
            string[] fileNameArr = str.Split('\\');
            string fileName = fileNameArr[fileNameArr.Length-1];
            string backupPath = String.Empty;
            if (str.Contains(MenusLib.BackUpName))
            {
                backupPath = _sendToSource + "\\" + fileName;
            }
            else
            {
                backupPath = _sendToBackup + "\\" + fileName;
            }
            if (isDelete)
            {
                File.Copy(sourcePath, backupPath, true);
                File.Delete(sourcePath);
            }
            else
            {
                File.Copy(sourcePath, backupPath, true);
            }
            return backupPath;
        }

      

    }
}