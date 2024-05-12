namespace WinWMS.SM
{
    partial class FrmMenuList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Panel panelWhere;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtkeywords = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tsMenus = new System.Windows.Forms.ToolStrip();
            this.tsbtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbtnEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnInfo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.dgvMenuList = new System.Windows.Forms.DataGridView();
            this.colChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddChild = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewLinkColumn1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnFind = new System.Windows.Forms.Button();
            panelWhere = new System.Windows.Forms.Panel();
            panelWhere.SuspendLayout();
            this.tsMenus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuList)).BeginInit();
            this.SuspendLayout();
            // 
            // panelWhere
            // 
            panelWhere.Controls.Add(this.btnFind);
            panelWhere.Controls.Add(this.txtkeywords);
            panelWhere.Controls.Add(this.label1);
            panelWhere.Dock = System.Windows.Forms.DockStyle.Top;
            panelWhere.Location = new System.Drawing.Point(0, 64);
            panelWhere.Margin = new System.Windows.Forms.Padding(4);
            panelWhere.Name = "panelWhere";
            panelWhere.Size = new System.Drawing.Size(1319, 70);
            panelWhere.TabIndex = 5;
            // 
            // txtkeywords
            // 
            this.txtkeywords.Location = new System.Drawing.Point(253, 22);
            this.txtkeywords.Margin = new System.Windows.Forms.Padding(4);
            this.txtkeywords.Name = "txtkeywords";
            this.txtkeywords.Size = new System.Drawing.Size(229, 25);
            this.txtkeywords.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(41, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入菜单名称或父级名称：";
            // 
            // tsMenus
            // 
            this.tsMenus.AutoSize = false;
            this.tsMenus.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tsMenus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsMenus.BackgroundImage")));
            this.tsMenus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsMenus.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMenus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnAdd,
            this.tsbtnEdit,
            this.tsbtnDelete,
            this.toolStripSeparator1,
            this.tsbtnInfo,
            this.toolStripSeparator2,
            this.tsbtnClose,
            this.toolStripSeparator3,
            this.tsbtnRefresh,
            this.toolStripSeparator4,
            this.toolStripSeparator5});
            this.tsMenus.Location = new System.Drawing.Point(0, 0);
            this.tsMenus.Name = "tsMenus";
            this.tsMenus.Padding = new System.Windows.Forms.Padding(0, 0, 1, 2);
            this.tsMenus.Size = new System.Drawing.Size(1319, 64);
            this.tsMenus.TabIndex = 4;
            this.tsMenus.Text = "toolStrip1";
            // 
            // tsbtnAdd
            // 
            this.tsbtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAdd.Image")));
            this.tsbtnAdd.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAdd.Margin = new System.Windows.Forms.Padding(0, 1, 0, 5);
            this.tsbtnAdd.Name = "tsbtnAdd";
            this.tsbtnAdd.Size = new System.Drawing.Size(55, 56);
            this.tsbtnAdd.Text = "  新增 ";
            this.tsbtnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnAdd.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.tsbtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbtnEdit
            // 
            this.tsbtnEdit.Image = global::WinWMS.Properties.Resources.edit;
            this.tsbtnEdit.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEdit.Margin = new System.Windows.Forms.Padding(0, 1, 0, 5);
            this.tsbtnEdit.Name = "tsbtnEdit";
            this.tsbtnEdit.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.tsbtnEdit.Size = new System.Drawing.Size(47, 56);
            this.tsbtnEdit.Text = " 修改";
            this.tsbtnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbtnDelete
            // 
            this.tsbtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDelete.Image")));
            this.tsbtnDelete.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDelete.Margin = new System.Windows.Forms.Padding(0, 1, 0, 5);
            this.tsbtnDelete.Name = "tsbtnDelete";
            this.tsbtnDelete.Size = new System.Drawing.Size(47, 56);
            this.tsbtnDelete.Text = " 删除";
            this.tsbtnDelete.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tsbtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 62);
            // 
            // tsbtnInfo
            // 
            this.tsbtnInfo.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnInfo.Image")));
            this.tsbtnInfo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnInfo.Margin = new System.Windows.Forms.Padding(0, 1, 0, 5);
            this.tsbtnInfo.Name = "tsbtnInfo";
            this.tsbtnInfo.Size = new System.Drawing.Size(47, 56);
            this.tsbtnInfo.Text = " 详情";
            this.tsbtnInfo.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tsbtnInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 62);
            // 
            // tsbtnClose
            // 
            this.tsbtnClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnClose.Image")));
            this.tsbtnClose.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnClose.Margin = new System.Windows.Forms.Padding(0, 1, 0, 5);
            this.tsbtnClose.Name = "tsbtnClose";
            this.tsbtnClose.Size = new System.Drawing.Size(47, 56);
            this.tsbtnClose.Text = " 关闭";
            this.tsbtnClose.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tsbtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 62);
            // 
            // tsbtnRefresh
            // 
            this.tsbtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRefresh.Image")));
            this.tsbtnRefresh.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefresh.Margin = new System.Windows.Forms.Padding(0, 1, 0, 5);
            this.tsbtnRefresh.Name = "tsbtnRefresh";
            this.tsbtnRefresh.Size = new System.Drawing.Size(47, 56);
            this.tsbtnRefresh.Text = " 刷新";
            this.tsbtnRefresh.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.tsbtnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 62);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 62);
            // 
            // dgvMenuList
            // 
            this.dgvMenuList.AllowUserToAddRows = false;
            this.dgvMenuList.AllowUserToDeleteRows = false;
            this.dgvMenuList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMenuList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMenuList.BackgroundColor = System.Drawing.Color.White;
            this.dgvMenuList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMenuList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMenuList.ColumnHeadersHeight = 35;
            this.dgvMenuList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMenuList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChk,
            this.MId,
            this.MName,
            this.ParentId,
            this.ParentName,
            this.MOrder,
            this.MKey,
            this.MUrl,
            this.AddChild,
            this.dataGridViewLinkColumn1,
            this.Delete});
            this.dgvMenuList.EnableHeadersVisualStyles = false;
            this.dgvMenuList.GridColor = System.Drawing.Color.LightSteelBlue;
            this.dgvMenuList.Location = new System.Drawing.Point(12, 166);
            this.dgvMenuList.MultiSelect = false;
            this.dgvMenuList.Name = "dgvMenuList";
            this.dgvMenuList.RowHeadersWidth = 30;
            this.dgvMenuList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dgvMenuList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMenuList.RowTemplate.Height = 27;
            this.dgvMenuList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMenuList.Size = new System.Drawing.Size(1295, 468);
            this.dgvMenuList.TabIndex = 29;
            // 
            // colChk
            // 
            this.colChk.FillWeight = 50F;
            this.colChk.HeaderText = "选择";
            this.colChk.MinimumWidth = 6;
            this.colChk.Name = "colChk";
            // 
            // MId
            // 
            this.MId.DataPropertyName = "MId";
            this.MId.FillWeight = 80F;
            this.MId.HeaderText = "编号";
            this.MId.MinimumWidth = 6;
            this.MId.Name = "MId";
            this.MId.ReadOnly = true;
            // 
            // MName
            // 
            this.MName.DataPropertyName = "MName";
            this.MName.FillWeight = 200F;
            this.MName.HeaderText = "名称";
            this.MName.MinimumWidth = 6;
            this.MName.Name = "MName";
            this.MName.ReadOnly = true;
            // 
            // ParentId
            // 
            this.ParentId.DataPropertyName = "ParentId";
            this.ParentId.HeaderText = "父菜单编号";
            this.ParentId.MinimumWidth = 6;
            this.ParentId.Name = "ParentId";
            this.ParentId.ReadOnly = true;
            // 
            // ParentName
            // 
            this.ParentName.DataPropertyName = "ParentName";
            this.ParentName.HeaderText = "父菜单名称";
            this.ParentName.MinimumWidth = 6;
            this.ParentName.Name = "ParentName";
            this.ParentName.ReadOnly = true;
            this.ParentName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // MOrder
            // 
            this.MOrder.DataPropertyName = "MOrder";
            this.MOrder.HeaderText = "排序号";
            this.MOrder.MinimumWidth = 6;
            this.MOrder.Name = "MOrder";
            this.MOrder.ReadOnly = true;
            // 
            // MKey
            // 
            this.MKey.DataPropertyName = "MKey";
            this.MKey.FillWeight = 60F;
            this.MKey.HeaderText = "快捷键";
            this.MKey.MinimumWidth = 6;
            this.MKey.Name = "MKey";
            this.MKey.ReadOnly = true;
            // 
            // MUrl
            // 
            this.MUrl.DataPropertyName = "MUrl";
            this.MUrl.HeaderText = "关联页面";
            this.MUrl.MinimumWidth = 6;
            this.MUrl.Name = "MUrl";
            // 
            // AddChild
            // 
            this.AddChild.FillWeight = 80F;
            this.AddChild.HeaderText = "添加子菜单";
            this.AddChild.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.AddChild.LinkColor = System.Drawing.Color.Blue;
            this.AddChild.MinimumWidth = 6;
            this.AddChild.Name = "AddChild";
            this.AddChild.Text = "添加子菜单";
            this.AddChild.TrackVisitedState = false;
            this.AddChild.UseColumnTextForLinkValue = true;
            // 
            // dataGridViewLinkColumn1
            // 
            this.dataGridViewLinkColumn1.FillWeight = 50F;
            this.dataGridViewLinkColumn1.HeaderText = "修改";
            this.dataGridViewLinkColumn1.MinimumWidth = 6;
            this.dataGridViewLinkColumn1.Name = "dataGridViewLinkColumn1";
            this.dataGridViewLinkColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLinkColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewLinkColumn1.Text = "修改";
            this.dataGridViewLinkColumn1.UseColumnTextForLinkValue = true;
            // 
            // Delete
            // 
            dataGridViewCellStyle2.NullValue = "删除";
            this.Delete.DefaultCellStyle = dataGridViewCellStyle2;
            this.Delete.FillWeight = 50F;
            this.Delete.HeaderText = "删除";
            this.Delete.MinimumWidth = 6;
            this.Delete.Name = "Delete";
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnFind.FlatAppearance.BorderSize = 0;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFind.ForeColor = System.Drawing.Color.White;
            this.btnFind.Location = new System.Drawing.Point(520, 16);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(78, 32);
            this.btnFind.TabIndex = 24;
            this.btnFind.Text = "查询";
            this.btnFind.UseVisualStyleBackColor = false;
            // 
            // FrmMenuList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 646);
            this.Controls.Add(this.dgvMenuList);
            this.Controls.Add(panelWhere);
            this.Controls.Add(this.tsMenus);
            this.Name = "FrmMenuList";
            this.Text = "FrmMenuList";
            panelWhere.ResumeLayout(false);
            panelWhere.PerformLayout();
            this.tsMenus.ResumeLayout(false);
            this.tsMenus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtkeywords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip tsMenus;
        private System.Windows.Forms.ToolStripButton tsbtnAdd;
        private System.Windows.Forms.ToolStripButton tsbtnEdit;
        private System.Windows.Forms.ToolStripButton tsbtnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.DataGridView dgvMenuList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn MId;
        private System.Windows.Forms.DataGridViewTextBoxColumn MName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn MKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn MUrl;
        private System.Windows.Forms.DataGridViewLinkColumn AddChild;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn1;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
        private System.Windows.Forms.Button btnFind;
    }
}