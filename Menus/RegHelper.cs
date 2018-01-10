using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace RightMenus
{
    /// <summary>
    /// 注册表操作类
    /// </summary>
    public static class RegHelper
    {
        #region 自定义类
        /// <summary>
        /// 值类型
        /// </summary>
        public class RegModel
        {
            public string Name = string.Empty;
            public string Data = string.Empty;
            public byte[] Binary = null;
            public string[] MultiString = null;
            public RegistryValueKind Type = RegistryValueKind.String;
        }
        
        #endregion
        #region 获取根键
        /// <summary>
        /// 获取注册表根键
        /// </summary>
        /// <param name="s">注册表字符串路径</param>
        /// <returns>返回根键</returns>
        public static RegistryKey GetHKey(string s)
        {
            string[] root = s.Split('\\');
            RegistryKey key = null;
            switch (root[0].ToUpper())
            {
                case "HKEY_CURRENT_USER":
                    //rootKey = Registry.ClassesRoot;
                    key = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
                    break;
                case "HKEY_LOCAL_MACHINE":
                    key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
                    break;
                case "HKEY_CLASSES_ROOT":
                    key = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
                    break;
                case "HKEY_USERS":
                    key = RegistryKey.OpenBaseKey(RegistryHive.Users, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
                    break;
                case "HKEY_PERFORMANCE_DATA":
                    key = RegistryKey.OpenBaseKey(RegistryHive.PerformanceData, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
                    break;
                case "HKEY_CURRENT_CONFIG":
                    key = RegistryKey.OpenBaseKey(RegistryHive.CurrentConfig, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
                    break;
                case "HKEY_DYN_DATA":
                    key = RegistryKey.OpenBaseKey(RegistryHive.DynData, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
                    break;
            }
            return key;
        }
        /// <summary>
        /// 获取注册表根目录
        /// </summary>
        /// <param name="s">注册表字符串路径</param>
        /// <param name="p">返回没有根键的路径</param>
        /// <returns>返回根键,及路径</returns>
        public static RegistryKey GetHKey(string s, out string p)
        {
            StringBuilder sb = new StringBuilder();
            string[] root = s.Split('\\');
            RegistryKey key = GetHKey(root[0]);
            for (int i = 1; i < root.Length; i++)
            {
                if (i == root.Length - 1)
                {
                    sb.Append(root[i]);
                }
                else
                {
                    sb.Append(root[i] + "\\");
                }
            }
            p = sb.ToString();
            return key;
        }
        private static RegistryKey GetRootKey(string s,bool isWrite = false)
        {
            string p = "";
            RegistryKey rootKey = GetHKey(s, out p);
            RegistryKey openSubKey;
            if (isWrite)
            {
                openSubKey = rootKey.OpenSubKey(p, true);
            }
            else
            {
                openSubKey = rootKey.OpenSubKey(p);
            }
            return openSubKey;
        }
        #endregion
        #region 新增
        /// <summary>
        /// 新增项
        /// </summary>
        /// <param name="s">新增项的父项路径</param>
        /// <param name="b">新增项的名称</param>
        public static void AddBranchName(string s,string b=null)
        {
            string p = string.Empty;
            RegistryKey key = GetHKey(s,out p);
            if (b !=null)
            {
                p = p + "\\" + b;
            }
            RegistryKey software = key.CreateSubKey(p);
        }

        private static void CreateBranch(string s)
        {
            
        }
        #endregion
        #region 删除
        public static void DeleteBranchName(string s)
        {
            string p = "";
            RegistryKey rootKey = GetHKey(s, out p);
            rootKey.DeleteSubKeyTree(p, true);
        }
        public static bool DeleteValueName(string branchName, string valueName)
        {
            RegistryKey branchKey = GetRootKey(branchName);
            string[] valueNames = branchKey.GetValueNames();
            foreach (string name in valueNames)
            {
                if (name.ToLower() == valueName.ToLower())
                {
                    branchKey.DeleteValue(name);
                    return true;
                }
            }
            return false;
        }
        #endregion
        #region 修改
        public static void SetValueData<T>(string branch, string branchName, T valueData, RegistryValueKind valueType = RegistryValueKind.String)
        {
            RegistryKey branchKey = GetRootKey(branch);
            branchKey.SetValue(branchName, valueData, valueType);
        }
        public static bool SetValueDatas(string branch, List<RegModel> regModelList)
        {
            //分支项不存在,则会报错
            AddBranchName(branch);
            RegistryKey branchKey = GetRootKey(branch,true);
            foreach (RegModel regModel in regModelList)
            {
                if (regModel.Type == RegistryValueKind.Binary)
                {
                    branchKey.SetValue(regModel.Name, regModel.Binary, regModel.Type);
                }
                if (regModel.Type == RegistryValueKind.MultiString)
                {
                    branchKey.SetValue(regModel.Name, regModel.MultiString, regModel.Type);
                }
                if (regModel.Type != RegistryValueKind.Binary && regModel.Type != RegistryValueKind.MultiString)
                {
                    branchKey.SetValue(regModel.Name, regModel.Data, regModel.Type);
                }
               
            }
            return false;
        }
        #endregion
        #region 查询
        /// <summary>
        /// 获取项名称,如果没有则返回null,存在但没分支则返回数量为0的数组
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string[] GetBranchNames(string s)
        {
            try
            {
                RegistryKey branchName = GetRootKey(s);
                string[] branchNameArr = branchName.GetSubKeyNames();
                return branchNameArr;
            }
            catch (Exception)
            {
                //如果注册表路径不存在,则会报错
                return null;
            }
        }
        /// <summary>
        /// 获取键值的名称
        /// </summary>
        /// <param name="s">注册表路径</param>
        /// <returns>如果注册表路径不存在,则返回null</returns>
        public static string[] GetValueNames(string s)
        {
            RegistryKey valueName = GetRootKey(s);
            if (valueName == null)
            {
                return null;
            }
            string[] valueNameArr = valueName.GetValueNames();
            return valueNameArr;
        }
        /// <summary>
        /// 返回数据数值(返回的数值会有byte[],string,null,需要在调用处判断)
        /// 可用is 或GetType().ToString()判断
        /// </summary>
        /// <param name="s"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static object GetValueData(string s, string d)
        {
            RegistryKey valueData = GetRootKey(s);
            RegistryValueKind type = valueData.GetValueKind(d);
            if (type == RegistryValueKind.Binary)
            {
                byte[] array = (byte[])valueData.GetValue(d);
                return array;
            }
            if (type == RegistryValueKind.MultiString)
            {
                string[] array = (string[])valueData.GetValue(d);
                return array;
            }
            // 如果存在null ，则ToString
            if (valueData.GetValue(d) == null)
            {
                return null;
            }
            return valueData.GetValue(d).ToString();
        }
        public static List<RegModel> GetRegModelList(string s)
        {
            List<RegModel> regModelList = new List<RegModel>();
            string[] valueNames = GetValueNames(s);
            foreach (string valueName in valueNames)
            {
                RegModel regModel = new RegModel();
                regModel.Name = valueName;
                object valueData = GetValueData(s, valueName);
                RegistryKey newValueData = GetRootKey(s);
                regModel.Type = newValueData.GetValueKind(valueName);
                if (valueData is byte[])
                {
                    regModel.Binary = (byte[])valueData;
                }
                if (valueData is string[])
                {
                    regModel.MultiString = (string[])valueData;
                }
                if (newValueData.GetValue(valueName) != null)
                {
                    regModel.Data = newValueData.GetValue(valueName).ToString();
                }
                regModelList.Add(regModel);
            }
            return regModelList;
        }
        /// <summary>
        /// 返回数据类型
        /// </summary>
        /// <param name="s"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static RegistryValueKind GetValueType(string s, string d)
        {
            RegistryKey valueData = GetRootKey(s);
            RegistryValueKind type = valueData.GetValueKind(d);
            return type;
        }

        public static bool ExistBranchName(string path)
        {
            string[] nameArr = path.Split('\\');
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < nameArr.Length-1; i++)
            {
                if (i == nameArr.Length-1 )
                {
                    sb.Append(nameArr[i]);
                }
                else
                {
                    sb.Append(nameArr[i] +"\\");
                }
                
            }
            string branchPath = sb.ToString();
            string branchName = nameArr[nameArr.Length-1];
            bool result = ExistBranchName(branchPath, branchName);
            return result;
        }
       
        /// <summary>
        /// 其目录下是否存在分支
        /// </summary>
        /// <param name="path">注册表目录</param>
        /// <param name="branchName">分支名</param>
        /// <returns></returns>
        public static bool ExistBranchName(string path, string branchName)
        {
            string shellNewPath = string.Empty;
            PrivateExistBranchName(path, branchName, out shellNewPath);
            if (string.IsNullOrEmpty(shellNewPath))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 判断路径下是否存在分支
        /// </summary>
        /// <param name="path">要判断的路径</param>
        /// <param name="branchName">分支名</param>
        /// <param name="shellNewPath">分支存在的路径</param>
        /// <returns>true存在,false不存在</returns>
        public static bool ExistBranchName(string path, string branchName, out string shellNewPath)
        {
            PrivateExistBranchName(path, branchName, out shellNewPath);
            if (string.IsNullOrEmpty(shellNewPath))
            {
                return false;
            }
            return true;
        }
        #endregion
        #region 常用方法
        public static void BackUpByBranch(string sourceBranch,string backupBranch,bool isDelete =false )
        {
            AddBranchName(backupBranch);
            List<RegModel> regModelList = GetRegModelList(sourceBranch);
            SetValueDatas(backupBranch, regModelList);
            string[] valueNames = GetBranchNames(sourceBranch);
            foreach (string valueName in valueNames)
            {
                string newSourceBranch = sourceBranch + "\\" + valueName;
                string newBackupBranch = backupBranch + "\\" + valueName;
                BackUpByBranch(newSourceBranch, newBackupBranch);
            }
            if (isDelete)
            {
                DeleteBranchName(sourceBranch);
            }
        }

        private static RegistryValueKind GetType(object obj)
        {
            //string,DWord32,DWord64,多字符串值,可扩展字符串
            if (obj is string)
            {
                return RegistryValueKind.String;
            }
            if (obj is byte[])
            {
                return RegistryValueKind.Binary;
            }

            return RegistryValueKind.None;
        }
        #endregion

        #region 私有方法
        private static void PrivateExistBranchName(string path, string branchName, out string shellNewPath)
        {
            shellNewPath = "";
            RegistryKey key = GetRootKey(path);
            if (key == null)
            {
                return;
            }
            string[] branchNameArr = key.GetSubKeyNames();
            foreach (string name in branchNameArr)
            {
                if (name.ToLower() == branchName.ToLower())
                {
                    shellNewPath = path;
                    return;
                }
                else
                {
                    if (string.IsNullOrEmpty(shellNewPath))
                    {
                        string newBranchNam = path + "\\" + name;
                        PrivateExistBranchName(newBranchNam, branchName, out shellNewPath);
                    }
                    
                }

            }
        }

        #endregion
    }
}