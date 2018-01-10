using System.Net.Security;

namespace RightMenus
{
    public static class RegEdit
    {
        public static InternetExplorer InternetExplorer = new InternetExplorer();
        public static Explorer Explorer = new Explorer();
    }
    public class InternetExplorer
    {
        public BaseModel IeExtend = new BaseModel("IeExtend");
        public BaseModel IeExtend2 = new BaseModel("IeExtend2");
    }
    public class Explorer
    {
        public BaseModel Computer = new BaseModel("Computer");
        public BaseModel LocalDisk = new BaseModel("LocalDisk");
        public BaseModel AllFiles = new BaseModel("AllFiles");
        public BaseModel Contents = new BaseModel("Contents");

        public BaseModel Desktop = new BaseModel("Desktop");
        public BaseModel Folders = new BaseModel("Folders");
        public BaseModel New = new BaseModel("New");
        public BaseModel RecycleBin = new BaseModel("RecycleBin");
        public BaseModel Others = new BaseModel("Others");

        public FileTypes FileType = new FileTypes();
    }
    #region 自定义类
    public class BaseModel
    {
        public string Name = string.Empty;
        public string Path = string.Empty;
        public BaseModel(string name): this(name, "")
        {
        }
        public BaseModel(string name, string path)
        {
            this.Name = name;
            this.Path = path;
        }
    }
    public class FileTypes
    {
        public BaseModel LnkFile = new BaseModel("LnkFile");
        public BaseModel TxtType = new BaseModel("TxtType");
        public BaseModel ExeType = new BaseModel("ExeType");
        public BaseModel DllType = new BaseModel("DllType");
    }

    #endregion

}