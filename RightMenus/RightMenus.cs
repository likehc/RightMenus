using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace RightMenus
{
    public partial class RightMenus : Form
    {
        public RightMenus()
        {
            InitializeComponent();
            //如果选定的树节点在树视图已失去焦点时不突出显示，则为 true；否则为 false。默认为 true。
            this.treeV.HideSelection = false;
            this.listV.HideSelection = false;
            Control.CheckForIllegalCrossThreadCalls = false; //跨线程访问

        }
        private string _typeStr = string.Empty; //右则tree选择的项目类型
        private string _fileNameStr = string.Empty; //右则tree选择的文件类型
        private string _regPath = string.Empty; //临时存储修改后,返回的注册表路径
        private string _regCopyPath = string.Empty; //此处选中复制选项的源路径
        private int _listIndex;     //获取选中listV的行号，从而获取其相信信息
        private List<OneMenu> _winOneMenuList = new List<OneMenu>();  //查询的结果放入此list
        private ImageList _imageListSmall = new ImageList();

        TreeNode exFilesType = new TreeNode() { Text = "文件类型" };//不可添加Name属性
        private void InitializeStatus()
        {
            TreeNode internetExplorerRoot = new TreeNode();
            internetExplorerRoot.Text = "Internet Explorer";
            TreeNode ieNode1 = new TreeNode() { Text = "IE右扩展", Name = RegEdit.InternetExplorer.IeExtend.Name };
            internetExplorerRoot.Nodes.Add(ieNode1);
            treeV.Nodes.Add(internetExplorerRoot);

            TreeNode explorerRoot = new TreeNode() { Text = "Explorer " }; //不可添加Name属性
            //explorerRoot.BackColor= Color.DarkGray;
            explorerRoot.NodeFont = new Font(Font, FontStyle.Bold);

            TreeNode exMyComputer = new TreeNode() { Text = "我的电脑", Name = RegEdit.Explorer.Computer.Name };
            TreeNode exLocalDisk = new TreeNode() { Text = "本地磁盘", Name = RegEdit.Explorer.LocalDisk.Name };
            TreeNode exAllFiles = new TreeNode() { Text = "所有文件", Name = RegEdit.Explorer.AllFiles.Name };
            TreeNode exContents = new TreeNode() { Text = "目录", Name = RegEdit.Explorer.Contents.Name };
            TreeNode exDesktop = new TreeNode() { Text = "桌面", Name = RegEdit.Explorer.Desktop.Name };
            TreeNode exFolders = new TreeNode() { Text = "文件夹", Name = RegEdit.Explorer.Folders.Name };
            TreeNode exNew = new TreeNode() { Text = "新建", Name = RegEdit.Explorer.New.Name };
            TreeNode exRecycleBin = new TreeNode() { Text = "回收站", Name = RegEdit.Explorer.RecycleBin.Name };
            TreeNode exOthers = new TreeNode() { Text = "其他", Name = RegEdit.Explorer.Others.Name };

           // TreeNode exFilesType = new TreeNode() { Text = "文件类型" };//不可添加Name属性
            TreeNode lnkFile = new TreeNode() { Text = "快捷方式", Name = RegEdit.Explorer.FileType.LnkFile.Name };
            TreeNode txtType = new TreeNode() { Text = "TXT文件", Name = RegEdit.Explorer.FileType.TxtType.Name };
            TreeNode exeType = new TreeNode() { Text = "EXE文件", Name = RegEdit.Explorer.FileType.ExeType.Name };
            TreeNode dllType = new TreeNode() { Text = "DLL文件", Name = RegEdit.Explorer.FileType.DllType.Name };
            exFilesType.Nodes.AddRange(new TreeNode[] { lnkFile, exeType, dllType, txtType });

            explorerRoot.Nodes.AddRange(new TreeNode[] { exMyComputer, exLocalDisk, exAllFiles, exContents, exDesktop, exFolders, exNew, exRecycleBin, exOthers, exFilesType });
            treeV.Nodes.Add(explorerRoot);
            listV.CheckBoxes = true;
            listV.FullRowSelect = true;
            treeV.Nodes[1].Expand();
        }
        private void RightMenus_Load(object sender, EventArgs e)
        {
            InitializeStatus();
            listV.Columns.Add("Expand", "扩展项", 130);
            listV.Columns.Add("Description", "描述", 150);
            listV.Columns.Add("Path", "文件路径", 200);
            listV.Columns.Add("Company", "发行公司", 120);
            listV.View = View.Details;
            listV.GridLines = true;
            listV.MultiSelect = false;
            AddFileType();
        }

        private XmlNodeList _xml;
        private void AddFileType()
        {
            if (_xml == null)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("info.xml");
                _xml = doc.SelectNodes("/RightMenus/FileType");
                foreach (XmlNode item in _xml)
                {
                   // _fileNameStr = item.Attributes["Name"].Value;
                    string text = item.Attributes["Text"].Value;
                    TreeNode lnkFile = new TreeNode() { Text = text, Name = "FileType" };
                    exFilesType.Nodes.Add(lnkFile);
                }

                //string names = _xml[0].Attributes["Name"].Value;
                //if (names.EndsWith(";"))
                //{
                //    names = names.TrimEnd(';');
                //}
                //string[] nameArr = names.Split(';');
                //foreach (string name in nameArr)
                //{
                //    string regPath = @"HKEY_CLASSES_ROOT\"+ name;
                //    string str = RegHelper.GetValueData(regPath,"").ToString();
                //    FileType fileType = new FileType();
                //    List<OneMenu> oneMenuList = fileType.GetMenuList(str);
                //}
            }
        }
        private void treeV_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            _typeStr = e.Node.Name;
            _fileNameStr = e.Node.Text;
            if (string.IsNullOrEmpty(e.Node.Name))
            {
                return;
            }
            Thread thread = new Thread(new ThreadStart(Refresh));//创建线程
            thread.Start();     
           // Refresh();
        }
        #region 私有方法
        private void BindingListV(List<OneMenu> oneMenuList)
        {
            if (oneMenuList == null)
            {
                listV.Items.Clear();
                ClearTextBoxInGroupBox();
                MessageBox.Show("没有找到数据!");
                return;
            }
            int chkIndex = 0;
            ListViewItem[] itemsBakUp = new ListViewItem[oneMenuList.Count];
            _imageListSmall.Images.Clear();
            _imageListSmall.ColorDepth = ColorDepth.Depth32Bit;  //防止图片失真 
            if (oneMenuList != null)
            {
                foreach (var oneMenu in oneMenuList)
                {
                    System.Drawing.Icon icon = null;
                    if (!string.IsNullOrEmpty(oneMenu.DefaultIcon))
                    {
                        string[] iconStrArr = oneMenu.DefaultIcon.Split(',');
                        if (!string.IsNullOrEmpty(oneMenu.DefaultIcon) && iconStrArr.Length == 2)
                        {
                            if (!iconStrArr[0].Contains(":") && (iconStrArr[0].EndsWith(".dll") || iconStrArr[0].EndsWith(".exe")))
                            {
                                string sysStrPath = System.Environment.GetEnvironmentVariable("path");
                                string[] sysPathArr = sysStrPath.Split(';');
                                string filePath = sysPathArr + "\\" + iconStrArr[0];
                                if (File.Exists(filePath))
                                {
                                    iconStrArr[0] = filePath;
                                }
                            }
                            GetSystemIcon getSystemIcon = new GetSystemIcon();
                            icon = getSystemIcon.extractIcon(iconStrArr[0], int.Parse(iconStrArr[1]));
                           
                        }
                    }
                    else
                    {
                        icon = MenusLib.GetIcon(oneMenu.FilePath);
                       
                    }
                    if (icon == null)
                    {
                        string selfPath = this.GetType().Assembly.Location;
                        icon = Icon.ExtractAssociatedIcon(selfPath);
                    }
                    _imageListSmall.Images.Add(icon);
                    ListViewItem lvItem = new ListViewItem("", chkIndex);
                    lvItem.Text = oneMenu.Name;
                    lvItem.Name = oneMenu.FilePath;
                    lvItem.ToolTipText = oneMenu.RegPath;
                    lvItem.SubItems.Add(oneMenu.Description);
                    lvItem.SubItems.Add(oneMenu.FilePath);
                    lvItem.SubItems.Add(oneMenu.Company);
                    //lvItem.SubItems.Add(oneMenu.Ssid);
                    lvItem.Checked = oneMenu.Checked;
                    itemsBakUp[chkIndex] = lvItem;
                    chkIndex++;
                }
            }
            listV.Items.AddRange(itemsBakUp);
            listV.SmallImageList = _imageListSmall;
            _winOneMenuList = oneMenuList;
        }
        /// <summary>
        /// 清空GroupBox内的详细信息
        /// </summary>
        private void ClearTextBoxInGroupBox()
        {
            foreach(Control txt in this.groupB.Controls)   
            {   
                 if(txt is TextBox)   
                 {
                     if (txt.Name.Contains("Detail"))
                     {
                         txt.Text = string.Empty;
                     }
                 }   
    
            }
            pictureBox.Image = null;
        }
        private void ClearListV()
        {
            for (int i = listV.Items.Count - 1; i >= 0; i--)
            {
                listV.Items.RemoveAt(i);
            }
        }
        /// <summary>
        /// 获取ListView选中的数据
        /// </summary>
        /// <returns>返回ListViewItem类型的数据,如果无数据则返回null</returns>
        private ListViewItem GetListViewSelected()
        {
            if (listV.SelectedItems.Count <= 0)
            {
                return null;
            }
            else
            {
                return listV.SelectedItems[0];
            }
        }
        private string GetTreeViewSelectedNode()
        {
            if (treeV.SelectedNode == null)
            {
                return null;
            }
            return treeV.SelectedNode.Name;
        }

        private void Updatelabs(string regPath)
        {
            foreach (OneMenu oneMenu in _winOneMenuList)
            {
                if (oneMenu.RegPath == regPath)
                {
                    txtFileNameDetail.Text = oneMenu.FileName;
                    txtVerDetail.Text = oneMenu.Version;
                    txtDesDetail.Text = oneMenu.Description;
                    txtCreTimeDetail.Text = oneMenu.Create;
                    txtMd5Detail.Text = oneMenu.Md5;
                    txtFileSizeDetail.Text = oneMenu.Size;
                    txtFilePathDetail.Text = oneMenu.FilePath;
                }
            }
        }
        private void Refresh()
        {
            MenusLib.CanEdit = false;
            try
            {
                listV.Items.Clear();
                BackUp(_typeStr);
                _winOneMenuList = MenusLib.GetDescriptionByXml(_winOneMenuList);
                BindingListV(_winOneMenuList);
                if (listV.Items.Count > 0)
                {

                    listV.Items[0].Selected = true;
                }
                MenusLib.CanEdit = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        #endregion
        private void listV_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                if (!MenusLib.CanEdit)
                {
                    return;
                }
                _listIndex = e.Index;
                if (e.NewValue.ToString() == "Unchecked")
                {
                    string toolTipText = listV.Items[e.Index].ToolTipText;
                    listV.Items[e.Index].ToolTipText = "";
                    BackUp(toolTipText, true);
                }
                if (e.NewValue.ToString() == "Checked")
                {
                    string toolTipText = listV.Items[e.Index].ToolTipText;
                    BackUp(toolTipText, true);
                }
                string indexPath = listV.Items[_listIndex].ToolTipText;
                this.txtRegLocDetail.Text = indexPath;
                Updatelabs(indexPath);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source">要备份的注册表路径</param>
        /// <param name="isBackUp">false是获取扩展项,true是进行备份,默认是false</param>
        private void BackUp(string source, bool isBackUp = false, bool isCopy = false)
        {
            switch (_typeStr)
            {
                //case "IeExtend":RegEdit.InternetExplorer.IeExtend.Name
                case "IeExtend":
                    IeExtend ieExtend = new IeExtend();
                    if (isCopy && !string.IsNullOrEmpty(_regCopyPath))
                    {
                        string result = ieExtend.CopyBranch(source);
                        if (string.IsNullOrEmpty(result))
                        {
                            MessageBox.Show("修改失败！");
                        }
                    }
                    if (isBackUp)
                    {
                        _regPath = ieExtend.BackUp(source, true);
                        listV.Items[_listIndex].ToolTipText = _regPath;
                    }
                    else
                    {
                        _winOneMenuList = ieExtend.GetMenuList();
                    }
                    break;
                case "Computer":
                    Computer computer = new Computer();
                    if (isBackUp)
                    {
                        _regPath = computer.BackUp(source, true);
                        if (string.IsNullOrEmpty(_regPath))
                        {
                            MessageBox.Show("修改失败！");
                        }
                        listV.Items[_listIndex].ToolTipText = _regPath;
                    }
                    else
                    {
                        _winOneMenuList = computer.GetMenuList();
                    }
                    break;
                case "LocalDisk":
                    LocalDisk localDisk = new LocalDisk();
                    if (isBackUp)
                    {
                        _regPath = localDisk.BackUp(source, true);
                        listV.Items[_listIndex].ToolTipText = _regPath;
                    }
                    else
                    {
                        _winOneMenuList = localDisk.GetMenuList();
                    }
                    break;
                case "AllFiles":
                    AllFiles allFiles = new AllFiles();
                    if (isBackUp)
                    {
                        _regPath = allFiles.BackUp(source, true);
                        listV.Items[_listIndex].ToolTipText = _regPath;
                    }
                    else
                    {
                        _winOneMenuList = allFiles.GetMenuList();
                    }
                    break;
                case "Contents":
                    Contents contents = new Contents();
                    if (isBackUp)
                    {
                        _regPath = contents.BackUp(source, true);
                        listV.Items[_listIndex].ToolTipText = _regPath;
                    }
                    else
                    {
                        _winOneMenuList = contents.GetMenuList();
                    }
                    break;
                case "Desktop":
                    Desktop desktop = new Desktop();
                    if (isBackUp)
                    {
                        _regPath = desktop.BackUp(source, true);
                        listV.Items[_listIndex].ToolTipText = _regPath;
                    }
                    else
                    {
                        _winOneMenuList = desktop.GetMenuList();
                    }
                    break;
                case "RecycleBin":
                    RecycleBin recycleBin = new RecycleBin();
                    if (isBackUp)
                    {
                        _regPath = recycleBin.BackUp(source, true);
                        if (string.IsNullOrEmpty(_regPath))
                        {
                            MessageBox.Show("修改失败！");
                        }
                        listV.Items[_listIndex].ToolTipText = _regPath;
                    }
                    else
                    {
                        _winOneMenuList = recycleBin.GetMenuList();
                    }
                    break;
                case "Others":
                    Others others = new Others();
                    if (isBackUp)
                    {
                        _regPath = others.BackUp(source, true);
                        if (string.IsNullOrEmpty(_regPath))
                        {
                            MessageBox.Show("修改失败！");
                        }
                        listV.Items[_listIndex].ToolTipText = _regPath;
                    }
                    else
                    {
                        _winOneMenuList = others.GetMenuList();
                    }
                    break;
                case "Folders":
                    Folders folders = new Folders();
                    if (isBackUp)
                    {
                        _regPath = folders.BackUp(source, true);
                        listV.Items[_listIndex].ToolTipText = _regPath;
                    }
                    else
                    {
                        _winOneMenuList = folders.GetMenuList();
                    }
                    break;
                case "New":
                    New _new = new New();
                    if (isBackUp)
                    {
                        _regPath = _new.BackUp(source, true);
                        listV.Items[_listIndex].ToolTipText = _regPath;
                    }
                    else
                    {
                        _winOneMenuList = _new.GetMenuList();
                    }
                    break;
                case "LnkFile":
                    LnkFile lnkFile = new LnkFile();
                    if (isBackUp)
                    {
                        _regPath = lnkFile.BackUp(source, true);
                        listV.Items[_listIndex].ToolTipText = _regPath;
                    }
                    else
                    {
                        _winOneMenuList = lnkFile.GetMenuList();
                    }
                    break;
                case "TxtType":
                    TxtType txtType = new TxtType();
                    if (isCopy && !string.IsNullOrEmpty(_regCopyPath))
                    {
                        string result = txtType.CopyBranch(source);
                        if (string.IsNullOrEmpty(result))
                        {
                            MessageBox.Show("复制失败！");
                        }
                        _winOneMenuList = txtType.GetMenuList();
                        break;
                    }
                    if (isBackUp)
                    {
                        _regPath = txtType.BackUp(source, true);
                        listV.Items[_listIndex].ToolTipText = _regPath;
                    }
                    else
                    {
                        _winOneMenuList = txtType.GetMenuList();
                    }
                    break;
                case "ExeType":
                    ExeType exeType = new ExeType();
                    if (isBackUp)
                    {
                        _regPath = exeType.BackUp(source, true);
                        listV.Items[_listIndex].ToolTipText = _regPath;
                    }
                    else
                    {
                        _winOneMenuList = exeType.GetMenuList();
                    }
                    break;
                case "FileType":
                    string typeName = string.Empty;
                    foreach (XmlNode item in _xml)
                    {
                        string typeText = item.Attributes["Text"].Value;
                        if (typeText == _fileNameStr)
                        {
                           typeName =  item.Attributes["Name"].Value;
                        }
                    }
                    
                    FileType fileType = new FileType();
                    if (isCopy && !string.IsNullOrEmpty(_regCopyPath))
                    {
                        string openWithExe = RegHelper.GetValueData( @"HKEY_CLASSES_ROOT\" + typeName, "").ToString();
                        string result = fileType.CopyBranch(source, openWithExe);
                        if (string.IsNullOrEmpty(result))
                        {
                            MessageBox.Show("复制失败！");
                        }
                        _winOneMenuList = fileType.GetMenuList(typeName);
                        break;
                    }
                    if (isBackUp)
                    {
                        _regPath = fileType.BackUp(source, true);
                        listV.Items[_listIndex].ToolTipText = _regPath;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(typeName))
                        {
                            _winOneMenuList = fileType.GetMenuList(typeName);
                        }
                    }
                    break;
                default:

                    _winOneMenuList = null;
                    break;
            }

        }
        private void listV_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            _listIndex = e.ItemIndex;
            string indexPath = listV.Items[_listIndex].ToolTipText;
            this.txtRegLocDetail.Text = indexPath;
            Updatelabs(indexPath);
            pictureBox.Image = _imageListSmall.Images[_listIndex];

        }
        private void contextMenuListV_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
        private void listV_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.contextMenuListV.Show(this.listV, e.X, e.Y);
            }
        }
        private void treeV_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode tn = treeV.GetNodeAt(e.X, e.Y);
                if (tn != null)
                {
                    treeV.SelectedNode = tn;
                    _typeStr = tn.Name;
                    if (string.IsNullOrEmpty(_typeStr))
                    {
                        ClearListV();
                        ClearTextBoxInGroupBox();
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(_regCopyPath))
                        {
                            contextMenutreeV.Show(this.treeV, e.X, e.Y);
                        }

                    }
                }
            }
        }
        private void ConMenuDel_Click(object sender, EventArgs e)
        {
            ListViewItem lv = GetListViewSelected();
            _regCopyPath = lv.ToolTipText;
            if (string.IsNullOrEmpty(_regCopyPath))
            {
                MessageBox.Show("请选择有效的节点！", "提示");
                return;
            }
            else
            {
                RegHelper.DeleteBranchName(_regCopyPath);
                Refresh();
            }
        }
        private void ConMenuCopy_Click(object sender, EventArgs e)
        {
            ListViewItem listItem = GetListViewSelected();
            _regCopyPath = listItem.ToolTipText;
            this.Text = _regCopyPath;
        }
        private void ToolStripMenuPaste_Click(object sender, EventArgs e)
        {
            _typeStr = GetTreeViewSelectedNode();
            if (string.IsNullOrEmpty(_regCopyPath))
            {
                MessageBox.Show("请选择有效的节点！", "提示");
                return;
            }
            else
            {
                BackUp(_regCopyPath, false, true);
                Refresh();
            }
        }
        private void ConMenuDelRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
