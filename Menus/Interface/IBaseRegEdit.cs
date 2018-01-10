using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Microsoft.SqlServer.Server;

namespace RightMenus
{
    public interface IBaseRegEdit
    {
        List<OneMenu> GetMenuList(string[] strPathArr);
        string BackUp(string source, bool isDelete = false);
        string AddBackupName(string str);
        string CopyBranch(string sourceBranch);

        #region 获取详细信息
        void GetFilePath(List<OneMenu> oneMenuList);
        void GetVersionInfo(List<OneMenu> oneMenuList);
        void GetFileInfo(List<OneMenu> oneMenuList);
        #endregion

    }
}