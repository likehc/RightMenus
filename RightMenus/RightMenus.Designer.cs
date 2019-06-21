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
            this.treeV.Location = new System.Drawing.Point(16, 2);
            this.treeV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeV.Name = "treeV";
            this.treeV.Size = new System.Drawing.Size(228, 483);
            this.treeV.TabIndex = 0;
            this.treeV.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeV_NodeMouseClick);
            this.treeV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeV_MouseDown);
            // 
            // listV
            // 
            this.listV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listV.Location = new System.Drawing.Point(255, 2);
            this.listV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listV.Name = "listV";
            this.listV.Size = new System.Drawing.Size(877, 293);
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
            this.groupB.Location = new System.Drawing.Point(255, 304);
            this.groupB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupB.Name = "groupB";
            this.groupB.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupB.Size = new System.Drawing.Size(879, 182);
            this.groupB.TabIndex = 2;
            this.groupB.TabStop = false;
            this.groupB.Text = "详细信息";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(48, 48);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(48, 40);
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
            this.txtRegLocDetail.Location = new System.Drawing.Point(143, 146);
            this.txtRegLocDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRegLocDetail.Name = "txtRegLocDetail";
            this.txtRegLocDetail.ReadOnly = true;
            this.txtRegLocDetail.Size = new System.Drawing.Size(712, 18);
            this.txtRegLocDetail.TabIndex = 4;
            // 
            // txtFilePathDetail
            // 
            this.txtFilePathDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePathDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFilePathDetail.Location = new System.Drawing.Point(131, 116);
            this.txtFilePathDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFilePathDetail.Name = "txtFilePathDetail";
            this.txtFilePathDetail.ReadOnly = true;
            this.txtFilePathDetail.Size = new System.Drawing.Size(724, 18);
            this.txtFilePathDetail.TabIndex = 4;
            // 
            // txtMd5Detail
            // 
            this.txtMd5Detail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMd5Detail.Location = new System.Drawing.Point(221, 86);
            this.txtMd5Detail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMd5Detail.Name = "txtMd5Detail";
            this.txtMd5Detail.ReadOnly = true;
            this.txtMd5Detail.Size = new System.Drawing.Size(268, 18);
            this.txtMd5Detail.TabIndex = 4;
            // 
            // txtDesDetail
            // 
            this.txtDesDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDesDetail.Location = new System.Drawing.Point(247, 56);
            this.txtDesDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDesDetail.Name = "txtDesDetail";
            this.txtDesDetail.ReadOnly = true;
            this.txtDesDetail.Size = new System.Drawing.Size(268, 18);
            this.txtDesDetail.TabIndex = 4;
            // 
            // txtFileSizeDetail
            // 
            this.txtFileSizeDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileSizeDetail.Location = new System.Drawing.Point(628, 85);
            this.txtFileSizeDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFileSizeDetail.Name = "txtFileSizeDetail";
            this.txtFileSizeDetail.ReadOnly = true;
            this.txtFileSizeDetail.Size = new System.Drawing.Size(228, 18);
            this.txtFileSizeDetail.TabIndex = 4;
            // 
            // txtCreTimeDetail
            // 
            this.txtCreTimeDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCreTimeDetail.Location = new System.Drawing.Point(628, 56);
            this.txtCreTimeDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCreTimeDetail.Name = "txtCreTimeDetail";
            this.txtCreTimeDetail.ReadOnly = true;
            this.txtCreTimeDetail.Size = new System.Drawing.Size(228, 18);
            this.txtCreTimeDetail.TabIndex = 4;
            // 
            // txtVerDetail
            // 
            this.txtVerDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVerDetail.Location = new System.Drawing.Point(628, 28);
            this.txtVerDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtVerDetail.Name = "txtVerDetail";
            this.txtVerDetail.ReadOnly = true;
            this.txtVerDetail.Size = new System.Drawing.Size(228, 18);
            this.txtVerDetail.TabIndex = 4;
            // 
            // txtFileNameDetail
            // 
            this.txtFileNameDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileNameDetail.Location = new System.Drawing.Point(247, 26);
            this.txtFileNameDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFileNameDetail.Name = "txtFileNameDetail";
            this.txtFileNameDetail.ReadOnly = true;
            this.txtFileNameDetail.Size = new System.Drawing.Size(268, 18);
            this.txtFileNameDetail.TabIndex = 4;
            // 
            // labRegLoc
            // 
            this.labRegLoc.AutoSize = true;
            this.labRegLoc.Location = new System.Drawing.Point(43, 146);
            this.labRegLoc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labRegLoc.Name = "labRegLoc";
            this.labRegLoc.Size = new System.Drawing.Size(97, 15);
            this.labRegLoc.TabIndex = 0;
            this.labRegLoc.Text = "注册表位置：";
            // 
            // labFilePath
            // 
            this.labFilePath.AutoSize = true;
            this.labFilePath.Location = new System.Drawing.Point(43, 116);
            this.labFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labFilePath.Name = "labFilePath";
            this.labFilePath.Size = new System.Drawing.Size(82, 15);
            this.labFilePath.TabIndex = 0;
            this.labFilePath.Text = "文件路径：";
            // 
            // labFileSize
            // 
            this.labFileSize.AutoSize = true;
            this.labFileSize.Location = new System.Drawing.Point(545, 86);
            this.labFileSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labFileSize.Name = "labFileSize";
            this.labFileSize.Size = new System.Drawing.Size(82, 15);
            this.labFileSize.TabIndex = 0;
            this.labFileSize.Text = "文件大小：";
            // 
            // labMd5
            // 
            this.labMd5.AutoSize = true;
            this.labMd5.Location = new System.Drawing.Point(159, 86);
            this.labMd5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labMd5.Name = "labMd5";
            this.labMd5.Size = new System.Drawing.Size(61, 15);
            this.labMd5.TabIndex = 0;
            this.labMd5.Text = "MD5值：";
            // 
            // labCreTime
            // 
            this.labCreTime.AutoSize = true;
            this.labCreTime.Location = new System.Drawing.Point(545, 56);
            this.labCreTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labCreTime.Name = "labCreTime";
            this.labCreTime.Size = new System.Drawing.Size(82, 15);
            this.labCreTime.TabIndex = 0;
            this.labCreTime.Text = "创建时间：";
            // 
            // labDes
            // 
            this.labDes.AutoSize = true;
            this.labDes.Location = new System.Drawing.Point(159, 56);
            this.labDes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labDes.Name = "labDes";
            this.labDes.Size = new System.Drawing.Size(82, 15);
            this.labDes.TabIndex = 0;
            this.labDes.Text = "文件描述：";
            // 
            // labVer
            // 
            this.labVer.AutoSize = true;
            this.labVer.Location = new System.Drawing.Point(545, 26);
            this.labVer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labVer.Name = "labVer";
            this.labVer.Size = new System.Drawing.Size(82, 15);
            this.labVer.TabIndex = 0;
            this.labVer.Text = "版本信息：";
            // 
            // labFileName
            // 
            this.labFileName.AutoSize = true;
            this.labFileName.Location = new System.Drawing.Point(159, 26);
            this.labFileName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labFileName.Name = "labFileName";
            this.labFileName.Size = new System.Drawing.Size(82, 15);
            this.labFileName.TabIndex = 0;
            this.labFileName.Text = "文件名称：";
            // 
            // contextMenuListV
            // 
            this.contextMenuListV.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuListV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConMenuDelRefresh,
            this.ConMenuDel,
            this.ConMenuCopy});
            this.contextMenuListV.Name = "contextMenuListV";
            this.contextMenuListV.Size = new System.Drawing.Size(109, 76);
            this.contextMenuListV.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuListV_Opening);
            // 
            // ConMenuDelRefresh
            // 
            this.ConMenuDelRefresh.Name = "ConMenuDelRefresh";
            this.ConMenuDelRefresh.Size = new System.Drawing.Size(108, 24);
            this.ConMenuDelRefresh.Text = "刷新";
            this.ConMenuDelRefresh.Click += new System.EventHandler(this.ConMenuDelRefresh_Click);
            // 
            // ConMenuDel
            // 
            this.ConMenuDel.Name = "ConMenuDel";
            this.ConMenuDel.Size = new System.Drawing.Size(108, 24);
            this.ConMenuDel.Text = "删除";
            this.ConMenuDel.Click += new System.EventHandler(this.ConMenuDel_Click);
            // 
            // ConMenuCopy
            // 
            this.ConMenuCopy.Name = "ConMenuCopy";
            this.ConMenuCopy.Size = new System.Drawing.Size(108, 24);
            this.ConMenuCopy.Text = "复制";
            this.ConMenuCopy.Click += new System.EventHandler(this.ConMenuCopy_Click);
            // 
            // contextMenutreeV
            // 
            this.contextMenutreeV.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenutreeV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuPaste});
            this.contextMenutreeV.Name = "contextMenutreeV";
            this.contextMenutreeV.Size = new System.Drawing.Size(109, 28);
            // 
            // ToolStripMenuPaste
            // 
            this.ToolStripMenuPaste.Name = "ToolStripMenuPaste";
            this.ToolStripMenuPaste.Size = new System.Drawing.Size(108, 24);
            this.ToolStripMenuPaste.Text = "粘贴";
            this.ToolStripMenuPaste.Click += new System.EventHandler(this.ToolStripMenuPaste_Click);
            // 
            // RightMenus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 512);
            this.Controls.Add(this.groupB);
            this.Controls.Add(this.listV);
            this.Controls.Add(this.treeV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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

