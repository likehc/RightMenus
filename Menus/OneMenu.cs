using System;

namespace RightMenus
{
    public static class RootKey
    {
        public static string ClassesRoot = "ClassesRoot";
        public static string CurrentUser = "CurrentUser";
        public static string LocalMachine = "LocalMachine";
        public static string Users = "Users";
        public static string CurrentConfig = "CurrentConfig";
    }
    public class OneMenu
    {
        /// <summary>
        /// 扩展项
        /// </summary>
        public string Name = string.Empty;
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName = string.Empty;
        /// <summary>
        /// 描述
        /// </summary>
        public string Description = string.Empty;
        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath = string.Empty;
        /// <summary>
        /// 注册表项
        /// </summary>
        public string RegPath = string.Empty;
        public string Company = string.Empty;
        public string Ssid = string.Empty;
        public bool Checked = false;
        /// <summary>
        /// MD5值
        /// </summary>
        public string Md5 = string.Empty;
        /// <summary>
        /// 版本信息
        /// </summary>
        public string Version = string.Empty;
        /// <summary>
        /// 文件大小
        /// </summary>
        public string Size = string.Empty;
        /// <summary>
        /// 创建时间
        /// </summary>
        public string Create = string.Empty;
        /// <summary>
        /// 图标
        /// </summary>
        public string DefaultIcon = string.Empty;
    }


}