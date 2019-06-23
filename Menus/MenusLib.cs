
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Resources;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Xml;
using Microsoft.Win32;

namespace RightMenus
{
    public static class MenusLib
    {
        
        public static bool CanEdit = false; //防止ListView加载时,触发不必要的事件

        public static string BackUpName = "Yhc_BackUp";
        //数组内出现的路径将会跳过
        private static string[] _skipArr = new[]
        {
            @"HKEY_CLASSES_ROOT\CLSID\{645FF040-5081-101B-9F08-00AA002F954E}\shell\empty"
        };

        private static XmlNodeList _xml;
        private static string[] sysPathArr;

        /// <summary>
        /// 根据配置文件 获取文件说明
        /// </summary>
        /// <param name="oneMenuList"></param>
        /// <returns></returns>
        public static List<OneMenu> GetDescriptionByXml(List<OneMenu> oneMenuList)
        {
            try
            {
                if (_xml == null)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load("info.xml");
                    _xml = doc.SelectNodes("/RightMenus/Term");
                }
                foreach (OneMenu oneMenu in oneMenuList)
                {
                    foreach (XmlNode item in _xml)
                    {
                        if ((oneMenu.Name.ToLower() == item.Attributes["Name"].Value.ToLower()) &&oneMenu.Description == string.Empty )
                        {
                            oneMenu.Description = item.Attributes["Des"].Value;
                        }
                        if ((oneMenu.Name.ToLower() == item.Attributes["Name"].Value.ToLower()) && item.Attributes["Update"].Value.ToLower() == "true")
                        {
                            oneMenu.Description = item.Attributes["Des"].Value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return oneMenuList;
            }
            return oneMenuList;
        }

        private static bool Skip(string s, string n)
        {
            foreach (string str in _skipArr)
            {
                string skipStr = s +"\\"+ n;
                if (str.ToLower().Contains(skipStr.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        public static List<OneMenu> GetMenuList(string path)
        {
            string[] nameArr = RegHelper.GetBranchNames(path);
            if (nameArr == null)
            {
                return null;
            }
            List<OneMenu> oneMenuList = new List<OneMenu>();
            foreach (string name in nameArr)
            {
                OneMenu oneMenu = new OneMenu();
                if (!path.Contains(MenusLib.BackUpName))
                {
                    oneMenu.Checked = true;
                }
                oneMenu.RegPath = path + "\\" + name;
                oneMenu.Name = name;
                oneMenuList.Add(oneMenu);
            }
            return oneMenuList;
        }
        public static string GetFileName(string filePath)
        {
            string fileName = string.Empty;
            fileName = Path.GetFileName(filePath);
            return fileName;
        }
        public static string GetFilePath(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return filePath;
            }
            //以引号开头,截取第一对引号内的内容，eg："C:\Program Files\Git\cmd\git-gui.exe" "--working-dir" "%1"
            if (filePath.StartsWith("\""))
            {
                int index1 = filePath.IndexOf("\"");
                int index2 = filePath.IndexOf("\"", index1 + 1);
                string path = filePath.Substring(index1, index2 - index1).Replace("\"", "");
                return path;
            }
            // eg: C:\Windows\System32\BitLockerWizard.exe %1 T
            if (filePath.Contains(":") && filePath.ToLower().Contains(".exe %"))
            {
                int index = filePath.IndexOf("%");
                string path = filePath.Substring(0, index).Trim();
                return path;
            }
            //eg: C:\Windows\SysWow64\NOTEPAD.EXE /p %1
            if (filePath.Contains(":") && filePath.ToLower().Contains(".exe /"))
            {
                int index = filePath.IndexOf("/");
                string path = filePath.Substring(0, index).Trim();
                return path;
            }
            //cmd.exe /s /k pushd "%V"
            string[] filePathArr = filePath.Split(' ');
            //if ((!filePathArr[0].Contains(":") && filePathArr[0].ToLower().Contains(".exe")) || (!filePathArr[0].Contains(":") && filePathArr[0].ToLower().Contains(".dll")))
            if (!filePathArr[0].Contains(":") &&(filePathArr[0].ToLower().Contains(".exe") ||  filePathArr[0].ToLower().Contains(".dll")))
            {
                string file = filePathArr[0];
                if (sysPathArr == null)
                {
                    string sysStrPath = System.Environment.GetEnvironmentVariable("path");
                    sysPathArr = sysStrPath.Split(';');
                }
                for (int i = 0; i < sysPathArr.Length; i++)
                {
                    string addFilePath = sysPathArr[i] + "\\" + file;
                    if (File.Exists(addFilePath))
                    {
                        return addFilePath;
                        break;

                    }
                }
            }
            return filePath;
        }
        /// <summary>
        /// 获取文件版本相关信息
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static FileVersionInfo GetFileVersionInfo(string filePath)
        {
            System.Diagnostics.FileVersionInfo info = System.Diagnostics.FileVersionInfo.GetVersionInfo(filePath);
            return info;
            
            
        }
        /// <summary>
        /// 获取文件大小，访问日期
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static FileInfo GetFileInfo(string filePath)
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(filePath);
            return fileInfo;
        }
        /// <summary>
        /// 获取文件的MD5值
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static string GetMd5(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return String.Empty;
            }
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
            byte[] buffer = md5Provider.ComputeHash(fs);
            string resule = BitConverter.ToString(buffer);
            resule = resule.Replace("-", "");
            md5Provider.Clear();
            fs.Close();
            return resule;  
            //if (string.IsNullOrEmpty(filePath))
            //{
            //    return String.Empty;
            //}
            //FileStream file = new FileStream(filePath, FileMode.Open);
            //System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            //byte[] retVal = md5.ComputeHash(file);
            //file.Close();
            //StringBuilder sb = new StringBuilder();
            //for (int i = 0; i < retVal.Length; i++)
            //{
            //    sb.Append(retVal[i].ToString("x2"));
            //}
            //return sb.ToString();
        }
        /// <summary>
        /// 计算文件大小函数(保留两位小数),Size为字节大小
        /// </summary>
        /// <param name="size">初始文件大小</param>
        /// <returns></returns>
        public static string GetFileSize(long size)
        {
            var num = 1024.00; //byte

            if (size < num)
                return size + "B";
            if (size < Math.Pow(num, 2))
                return (size / num).ToString("f2") + "K"; //kb
            if (size < Math.Pow(num, 3))
                return (size / Math.Pow(num, 2)).ToString("f2") + "M"; //M
            if (size < Math.Pow(num, 4))
                return (size / Math.Pow(num, 3)).ToString("f2") + "G"; //G

            return (size / Math.Pow(num, 4)).ToString("f2") + "T"; //T
        }

        public static Icon GetIcon(string path)
        {
            if (File.Exists(path))
            {
                return Icon.ExtractAssociatedIcon(path);
            }
            string[] iconStrArr = path.Split(',');
            if (iconStrArr.Length == 2)
            {
                
            }
            return null;
        }

        /// <summary>
        /// 判断文件类型关联是否存在
        /// </summary>
        /// <param name="type">文件格式 如.exe 、.txt</param>
        /// <returns>存在返回true,否则为false</returns>
        public static bool ExistFileType(string type)
        {
            bool reslut = false;
            if (string.IsNullOrEmpty(type))
            {
                return reslut;
            }
            RegistryKey cr = Registry.ClassesRoot;
            RegistryKey exist = cr.OpenSubKey(type, true);
            if (exist != null)
            {
                string value = exist.GetValue("").ToString();
                if (value !="")
                {
                    reslut = true;
                }
            }
            return reslut;
        }
    }
}