namespace RightMenus
{
    partial class RightMenus
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RightMenus));
            this.treeV = new System.Windows.Forms.TreeView();
            this.listV = new System.Windows.Forms.ListView();
            this.groupB = new System.Windows.Forms.GroupBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.txtRegLocDetail = new System.Windows.Forms.TextBox();
            this.txtFilePathDetail = new System.Windows.Forms.TextBox();
            this.txtMd5Detail = new System.Windows.Forms.TextBox();
            this.txtDesDetail = new System.Windows.Forms.TextBox();
            this.txtFileSizeDetail = new System.Windows.Forms.TextBox();
            this.txtCreTimeDetail = new System.Windows.Forms.TextBox();
            this.txtVerDetail = new System.Windows.Forms.TextBox();
            this.txtFileNameDetail = new System.Windows.Forms.TextBox();
            this.labRegLoc = new System.Windows.Forms.Label();
            this.labFilePath = new System.Windows.Forms.Label();
            this.labFileSize = new System.Windows.Forms.Label();
            this.labMd5 = new System.Windows.Forms.Label();
            this.labCreTime = new System.Windows.Forms.Label();
            this.labDes = new System.Windows.Forms.Label();
            this.labVer = new System.Windows.Forms.Label();
            this.labFileName = new System.Windows.Forms.Label();
            this.contextMenuListV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ConMenuDelRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.ConMenuDel = new System.Windows.Forms.ToolStripMenuItem();
            this.ConMenuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenutreeV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.groupB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.contextMenuListV.SuspendLayout();
            this.contextMenutreeV.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeV
            // 
            this.treeV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeV.Location = new System.Drawing.Point(12, 2);
            this.treeV.Name = "treeV";
            this.treeV.Size = new System.Drawing.Size(172, 387);
            this.treeV.TabIndex = 0;
            this.treeV.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeV_NodeMouseClick);
            this.treeV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeV_MouseDown);
            // 
            // listV
            // 
            this.listV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listV.Location = new System.Drawing.Point(191, 2);
            this.listV.Name = "listV";
            this.listV.Size = new System.Drawing.Size(659, 235);
            this.listV.TabIndex = 1;
            this.listV.UseCompatibleStateImageBehavior = false;
            this.listV.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listV_ItemCheck);
            this.listV.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listV_ItemSelectionChanged);
            this.listV.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listV_MouseClick);
            // 
            // groupB
            // 
            this.groupB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupB.Controls.Add(this.pictureBox);
            this.groupB.Controls.Add(this.txtRegLocDetail);
            this.groupB.Controls.Add(this.txtFilePathDetail);
            this.groupB.Controls.Add(this.txtMd5Detail);
            this.groupB.Controls.Add(this.txtDesDetail);
            this.groupB.Controls.Add(this.txtFileSizeDetail);
            this.groupB.Controls.Add(this.txtCreTimeDetail);
            this.groupB.Controls.Add(this.txtVerDetail);
            this.groupB.Controls.Add(this.txtFileNameDetail);
            this.groupB.Controls.Add(this.labRegLoc);
            this.groupB.Controls.Add(this.labFilePath);
            this.groupB.Controls.Add(this.labFileSize);
            this.groupB.Controls.Add(this.labMd5);
            this.groupB.Controls.Add(this.labCreTime);
            this.groupB.Controls.Add(this.labDes);
            this.groupB.Controls.Add(this.labVer);
            this.groupB.Controls.Add(this.labFileName);
            this.groupB.Location = new System.Drawing.Point(191, 243);
            this.groupB.Name = "groupB";
            this.groupB.Size = new System.Drawing.Size(659, 146);
            this.groupB.TabIndex = 2;
            this.groupB.TabStop = false;
            this.groupB.Text = "详细信息";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(36, 38);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(36, 32);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 5;
            this.pictureBox.TabStop = false;
            // 
            // txtRegLocDetail
            // 
            this.txtRegLocDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegLocDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRegLocDetail.Location = new System.Drawing.Point(107, 117);
            this.txtRegLocDetail.Name = "txtRegLocDetail";
            this.txtRegLocDetail.ReadOnly = true;
            this.txtRegLocDetail.Size = new System.Drawing.Size(534, 14);
            this.txtRegLocDetail.TabIndex = 4;
            // 
            // txtFilePathDetail
            // 
            this.txtFilePathDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePathDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFilePathDetail.Location = new System.Drawing.Point(98, 93);
            this.txtFilePathDetail.Name = "txtFilePathDetail";
            this.txtFilePathDetail.ReadOnly = true;
            this.txtFilePathDetail.Size = new System.Drawing.Size(543, 14);
            this.txtFilePathDetail.TabIndex = 4;
            // 
            // txtMd5Detail
            // 
            this.txtMd5Detail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMd5Detail.Location = new System.Drawing.Point(166, 69);
            this.txtMd5Detail.Name = "txtMd5Detail";
            this.txtMd5Detail.ReadOnly = true;
            this.txtMd5Detail.Size = new System.Drawing.Size(201, 14);
            this.txtMd5Detail.TabIndex = 4;
            // 
            // txtDesDetail
            // 
            this.txtDesDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDesDetail.Location = new System.Drawing.Point(185, 45);
            this.txtDesDetail.Name = "txtDesDetail";
            this.txtDesDetail.ReadOnly = true;
            this.txtDesDetail.Size = new System.Drawing.Size(201, 14);
            this.txtDesDetail.TabIndex = 4;
            // 
            // txtFileSizeDetail
            // 
            this.txtFileSizeDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileSizeDetail.Location = new System.Drawing.Point(471, 68);
            this.txtFileSizeDetail.Name = "txtFileSizeDetail";
            this.txtFileSizeDetail.ReadOnly = true;
            this.txtFileSizeDetail.Size = new System.Drawing.Size(171, 14);
            this.txtFileSizeDetail.TabIndex = 4;
            // 
            // txtCreTimeDetail
            // 
            this.txtCreTimeDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCreTimeDetail.Location = new System.Drawing.Point(471, 45);
            this.txtCreTimeDetail.Name = "txtCreTimeDetail";
            this.txtCreTimeDetail.ReadOnly = true;
            this.txtCreTimeDetail.Size = new System.Drawing.Size(171, 14);
            this.txtCreTimeDetail.TabIndex = 4;
            // 
            // txtVerDetail
            // 
            this.txtVerDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVerDetail.Location = new System.Drawing.Point(471, 22);
            this.txtVerDetail.Name = "txtVerDetail";
            this.txtVerDetail.ReadOnly = true;
            this.txtVerDetail.Size = new System.Drawing.Size(171, 14);
            this.txtVerDetail.TabIndex = 4;
            // 
            // txtFileNameDetail
            // 
            this.txtFileNameDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileNameDetail.Location = new System.Drawing.Point(185, 21);
            this.txtFileNameDetail.Name = "txtFileNameDetail";
            this.txtFileNameDetail.ReadOnly = true;
            this.txtFileNameDetail.Size = new System.Drawing.Size(201, 14);
            this.txtFileNameDetail.TabIndex = 4;
            // 
            // labRegLoc
            // 
            this.labRegLoc.AutoSize = true;
            this.labRegLoc.Location = new System.Drawing.Point(32, 117);
            this.labRegLoc.Name = "labRegLoc";
            this.labRegLoc.Size = new System.Drawing.Size(77, 12);
            this.labRegLoc.TabIndex = 0;
            this.labRegLoc.Text = "注册表位置：";
            // 
            // labFilePath
            // 
            this.labFilePath.AutoSize = true;
            this.labFilePath.Location = new System.Drawing.Point(32, 93);
            this.labFilePath.Name = "labFilePath";
            this.labFilePath.Size = new System.Drawing.Size(65, 12);
            this.labFilePath.TabIndex = 0;
            this.labFilePath.Text = "文件路径：";
            // 
            // labFileSize
            // 
            this.labFileSize.AutoSize = true;
            this.labFileSize.Location = new System.Drawing.Point(409, 69);
            this.labFileSize.Name = "labFileSize";
            this.labFileSize.Size = new System.Drawing.Size(65, 12);
            this.labFileSize.TabIndex = 0;
            this.labFileSize.Text = "文件大小：";
            // 
            // labMd5
            // 
            this.labMd5.AutoSize = true;
            this.labMd5.Location = new System.Drawing.Point(119, 69);
            this.labMd5.Name = "labMd5";
            this.labMd5.Size = new System.Drawing.Size(47, 12);
            this.labMd5.TabIndex = 0;
            this.labMd5.Text = "MD5值：";
            // 
            // labCreTime
            // 
            this.labCreTime.AutoSize = true;
            this.labCreTime.Location = new System.Drawing.Point(409, 45);
            this.labCreTime.Name = "labCreTime";
            this.labCreTime.Size = new System.Drawing.Size(65, 12);
            this.labCreTime.TabIndex = 0;
            this.labCreTime.Text = "创建时间：";
            // 
            // labDes
            // 
            this.labDes.AutoSize = true;
            this.labDes.Location = new System.Drawing.Point(119, 45);
            this.labDes.Name = "labDes";
            this.labDes.Size = new System.Drawing.Size(65, 12);
            this.labDes.TabIndex = 0;
            this.labDes.Text = "文件描述：";
            // 
            // labVer
            // 
            this.labVer.AutoSize = true;
            this.labVer.Location = new System.Drawing.Point(409, 21);
            this.labVer.Name = "labVer";
            this.labVer.Size = new System.Drawing.Size(65, 12);
            this.labVer.TabIndex = 0;
            this.labVer.Text = "版本信息：";
            // 
            // labFileName
            // 
            this.labFileName.AutoSize = true;
            this.labFileName.Location = new System.Drawing.Point(119, 21);
            this.labFileName.Name = "labFileName";
            this.labFileName.Size = new System.Drawing.Size(65, 12);
            this.labFileName.TabIndex = 0;
            this.labFileName.Text = "文件名称：";
            // 
            // contextMenuListV
            // 
            this.contextMenuListV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConMenuDelRefresh,
            this.ConMenuDel,
            this.ConMenuCopy});
            this.contextMenuListV.Name = "contextMenuListV";
            this.contextMenuListV.Size = new System.Drawing.Size(101, 70);
            this.contextMenuListV.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuListV_Opening);
            // 
            // ConMenuDelRefresh
            // 
            this.ConMenuDelRefresh.Name = "ConMenuDelRefresh";
            this.ConMenuDelRefresh.Size = new System.Drawing.Size(100, 22);
            this.ConMenuDelRefresh.Text = "刷新";
            this.ConMenuDelRefresh.Click += new System.EventHandler(this.ConMenuDelRefresh_Click);
            // 
            // ConMenuDel
            // 
            this.ConMenuDel.Name = "ConMenuDel";
            this.ConMenuDel.Size = new System.Drawing.Size(100, 22);
            this.ConMenuDel.Text = "删除";
            this.ConMenuDel.Click += new System.EventHandler(this.ConMenuDel_Click);
            // 
            // ConMenuCopy
            // 
            this.ConMenuCopy.Name = "ConMenuCopy";
            this.ConMenuCopy.Size = new System.Drawing.Size(100, 22);
            this.ConMenuCopy.Text = "复制";
            this.ConMenuCopy.Click += new System.EventHandler(this.ConMenuCopy_Click);
            // 
            // contextMenutreeV
            // 
            this.contextMenutreeV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuPaste});
            this.contextMenutreeV.Name = "contextMenutreeV";
            this.contextMenutreeV.Size = new System.Drawing.Size(101, 26);
            // 
            // ToolStripMenuPaste
            // 
            this.ToolStripMenuPaste.Name = "ToolStripMenuPaste";
            this.ToolStripMenuPaste.Size = new System.Drawing.Size(100, 22);
            this.ToolStripMenuPaste.Text = "粘贴";
            this.ToolStripMenuPaste.Click += new System.EventHandler(this.ToolStripMenuPaste_Click);
            // 
            // RightMenus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 410);
            this.Controls.Add(this.groupB);
            this.Controls.Add(this.listV);
            this.Controls.Add(this.treeV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RightMenus";
            this.Text = "右键菜单管理";
            this.Load += new System.EventHandler(this.RightMenus_Load);
            this.groupB.ResumeLayout(false);
            this.groupB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.contextMenuListV.ResumeLayout(false);
            this.contextMenutreeV.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeV;
        private System.Windows.Forms.ListView listV;
        private System.Windows.Forms.GroupBox groupB;
        private System.Windows.Forms.Label labRegLoc;
        private System.Windows.Forms.Label labFilePath;
        private System.Windows.Forms.Label labFileSize;
        private System.Windows.Forms.Label labMd5;
        private System.Windows.Forms.Label labCreTime;
        private System.Windows.Forms.Label labDes;
        private System.Windows.Forms.Label labVer;
        private System.Windows.Forms.Label labFileName;
        private System.Windows.Forms.ContextMenuStrip contextMenuListV;
        private System.Windows.Forms.ToolStripMenuItem ConMenuDel;
        private System.Windows.Forms.ToolStripMenuItem ConMenuCopy;
        private System.Windows.Forms.ContextMenuStrip contextMenutreeV;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuPaste;
        private System.Windows.Forms.ToolStripMenuItem ConMenuDelRefresh;
        private System.Windows.Forms.TextBox txtFileNameDetail;
        private System.Windows.Forms.TextBox txtRegLocDetail;
        private System.Windows.Forms.TextBox txtFilePathDetail;
        private System.Windows.Forms.TextBox txtMd5Detail;
        private System.Windows.Forms.TextBox txtDesDetail;
        private System.Windows.Forms.TextBox txtFileSizeDetail;
        private System.Windows.Forms.TextBox txtCreTimeDetail;
        private System.Windows.Forms.TextBox txtVerDetail;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}

