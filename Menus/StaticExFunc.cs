using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RightMenus
{
    public static class StaticExFunc
    {
        public static List<OneMenu> AddOneMenuList(this List<OneMenu> l1, List<OneMenu> l2)
        {
            if (l1 ==null)
            {
                return l2;
            }
            if (l2 == null)
            {
                return l1;
            }
            List<OneMenu> result = new List<OneMenu>();
            foreach (OneMenu oneMenu1 in l1)
            {
                result.Add(oneMenu1);
            }

            foreach (OneMenu oneMenu2 in l2)
            {
                result.Add(oneMenu2);
            }
            if (result.Count > 0)
            {
                return result;
            }
            return null;
        }

        //public static string AddBackUpName(this string s1, string s2)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    string[] root = s1.Split('\\');
        //    for (int i = 0; i < root.Length; i++)
        //    {
        //        if (root[i].ToLower() == s2.ToLower())
        //        {
        //            root[i] = root[i] + MenusLib.BackUpName;
        //        }

        //        if (i == root.Length - 1)
        //        {
        //            sb.Append(root[i]);
        //        }
        //        else
        //        {
        //            sb.Append(root[i] + "\\");
        //        }
        //    }
        //    return sb.ToString();
        //}

      /*  public static string DelBackUpName(this string s1)
        {
            //此处代码没有考虑MenusLib.BackUpName 出现多次的情况
            return s1.ReplaceNoCase(MenusLib.BackUpName, "");
        }*/
/*

        /// <summary>
        /// 合并字符串数组
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        public static string[] AddStringArr(this string[] arr1,string[] arr2)
        {
            if (arr1 == null)
            {
                return arr2;
            }
            if (arr2 == null)
            {
                return arr1;
            }
            List<string> strList = new List<string>();
            foreach (string str1 in arr1)
            {
                strList.Add(str1);
            }
            foreach (string str2 in arr2)
            {
                strList.Add(str2);
            }
            return strList.ToArray();
        }
*/



        /*
        /// <summary>
        /// 不区分大小替换字符串
        /// </summary>
        /// <param name="sourceValue">原字符串</param>
        /// <param name="oldValue">需替换字符</param>
        /// <param name="newValue">新字符</param>
        /// <returns></returns>
        public static string ReplaceNoCase(this string sourceValue, string oldValue, string newValue)
        {
            return System.Text.RegularExpressions.Regex.Replace(sourceValue, oldValue, newValue, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }*/
    }
}