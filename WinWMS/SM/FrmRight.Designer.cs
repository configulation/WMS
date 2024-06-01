namespace WinWMS.SM
{
    partial class FrmRight
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
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.cboRoles = new Sunny.UI.UIComboBox();
            this.btnSubmit = new Sunny.UI.UIButton();
            this.tcRights = new Sunny.UI.UITabControl();
            this.tpMenu = new System.Windows.Forms.TabPage();
            this.tvMenus = new System.Windows.Forms.TreeView();
            this.tpTMenu = new System.Windows.Forms.TabPage();
            this.tvTMenus = new System.Windows.Forms.TreeView();
            this.tcRights.SuspendLayout();
            this.tpMenu.SuspendLayout();
            this.tpTMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(64, 22);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(75, 36);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "角色：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboRoles
            // 
            this.cboRoles.DataSource = null;
            this.cboRoles.FillColor = System.Drawing.Color.White;
            this.cboRoles.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboRoles.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cboRoles.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cboRoles.Location = new System.Drawing.Point(161, 22);
            this.cboRoles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboRoles.MinimumSize = new System.Drawing.Size(63, 0);
            this.cboRoles.Name = "cboRoles";
            this.cboRoles.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cboRoles.Size = new System.Drawing.Size(212, 36);
            this.cboRoles.SymbolSize = 24;
            this.cboRoles.TabIndex = 1;
            this.cboRoles.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cboRoles.Watermark = "";
            this.cboRoles.SelectedIndexChanged += new System.EventHandler(this.cboRoles_SelectedIndexChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSubmit.Location = new System.Drawing.Point(664, 23);
            this.btnSubmit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(126, 35);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "提交设置";
            this.btnSubmit.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // tcRights
            // 
            this.tcRights.Controls.Add(this.tpMenu);
            this.tcRights.Controls.Add(this.tpTMenu);
            this.tcRights.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tcRights.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tcRights.ItemSize = new System.Drawing.Size(150, 40);
            this.tcRights.Location = new System.Drawing.Point(14, 80);
            this.tcRights.MainPage = "";
            this.tcRights.Name = "tcRights";
            this.tcRights.SelectedIndex = 0;
            this.tcRights.Size = new System.Drawing.Size(888, 515);
            this.tcRights.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tcRights.TabIndex = 3;
            this.tcRights.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // tpMenu
            // 
            this.tpMenu.Controls.Add(this.tvMenus);
            this.tpMenu.Location = new System.Drawing.Point(0, 40);
            this.tpMenu.Name = "tpMenu";
            this.tpMenu.Size = new System.Drawing.Size(888, 475);
            this.tpMenu.TabIndex = 0;
            this.tpMenu.Text = "菜单";
            this.tpMenu.UseVisualStyleBackColor = true;
            // 
            // tvMenus
            // 
            this.tvMenus.Location = new System.Drawing.Point(26, 22);
            this.tvMenus.Name = "tvMenus";
            this.tvMenus.Size = new System.Drawing.Size(840, 438);
            this.tvMenus.TabIndex = 0;
            this.tvMenus.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvMenus_AfterCheck);
            // 
            // tpTMenu
            // 
            this.tpTMenu.Controls.Add(this.tvTMenus);
            this.tpTMenu.Location = new System.Drawing.Point(0, 40);
            this.tpTMenu.Name = "tpTMenu";
            this.tpTMenu.Size = new System.Drawing.Size(888, 475);
            this.tpTMenu.TabIndex = 1;
            this.tpTMenu.Text = "工具栏";
            this.tpTMenu.UseVisualStyleBackColor = true;
            // 
            // tvTMenus
            // 
            this.tvTMenus.Location = new System.Drawing.Point(29, 25);
            this.tvTMenus.Name = "tvTMenus";
            this.tvTMenus.Size = new System.Drawing.Size(843, 432);
            this.tvTMenus.TabIndex = 0;
            // 
            // FrmRight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 631);
            this.Controls.Add(this.tcRights);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.cboRoles);
            this.Controls.Add(this.uiLabel1);
            this.Name = "FrmRight";
            this.Text = "权限分配";
            this.Load += new System.EventHandler(this.FrmRight_Load);
            this.tcRights.ResumeLayout(false);
            this.tpMenu.ResumeLayout(false);
            this.tpTMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIComboBox cboRoles;
        private Sunny.UI.UIButton btnSubmit;
        private Sunny.UI.UITabControl tcRights;
        private System.Windows.Forms.TabPage tpMenu;
        private System.Windows.Forms.TabPage tpTMenu;
        private System.Windows.Forms.TreeView tvMenus;
        private System.Windows.Forms.TreeView tvTMenus;
    }
}