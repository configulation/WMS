using BLL;
using Models.VModels;
using PSI.Models.DModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;
using WinPSI.FModels;

namespace WinWMS
{
    public partial class FrmMain : Form
    {
        MenuBLL menuBLL = new MenuBLL();
        ToolMenuBLL toolMenuBLL = new ToolMenuBLL();
        public FrmMain()
        {
            InitializeComponent();
        }
        bool isAdmin=false;
        string uName = "";
        FrmLogin fLogin = null;
        List<ViewUserRoleModel> urList = new List<ViewUserRoleModel>();
        int isFirst=0;

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if(this.Tag != null) 
            {
                InitMenuInfo();
            }
        }

        private void CheckIsAdmin()
        {
            isAdmin = false;
            foreach (var item in urList)
            {
                if (item.IsAdmin == 1)
                {
                    isAdmin = true;
                }
            }
        }

        private void InitMenuInfo()
        {
            LoginModel loginModel = this.Tag as LoginModel;
            if (loginModel != null)
            {
                urList = loginModel.URList;
                fLogin = loginModel.LoginForm;
                uName = urList[0].UserName;
            }
            //判断是否是超级管理员
            CheckIsAdmin();
            AddMenusAndToolMenus();
            lblUName.Text = uName;
            lblLoginTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            
        }

        private void AddMenusAndToolMenus()
        {
            List<MenuInfoModel> mlist = new List<MenuInfoModel>();
            List<ToolMenuInfoModel> tmList = new List<ToolMenuInfoModel>();
            List<int> roleIds = urList.Select(i => i.UserId).ToList();
            if(isAdmin)
            {
                //获取菜单栏信息
                mlist = menuBLL.GetMenuList(new List<int>() { });

                //获取工具菜单栏信息
                tmList = toolMenuBLL.GetToolMenuList(new List<int>() { });
            }
            else
            {
                //获取菜单栏信息
                mlist = menuBLL.GetMenuList(roleIds);

                //获取工具菜单栏信息
                tmList = toolMenuBLL.GetToolMenuList(roleIds);
            }
            WMS_Menus.Items.Clear();
            WMS_Tools.Items.Clear();
            //添加菜单项
            AddMenuItem(mlist, null, 0);
            //添加工具菜单项
            AddToolMenuItem(tmList);
        }

        private void AddToolMenuItem(List<ToolMenuInfoModel> tmList)
        {
            List<int> TGroups = new List<int>();
            foreach (var tm in tmList)
            {
                if(!TGroups.Contains(tm.TGroupId)) 
                    TGroups.Add(tm.TGroupId);
            }

            foreach (var tGroup in TGroups)
            {
                var gTools = tmList.Where(t => t.TGroupId == tGroup).ToList();
                if(gTools.Count > 0)
                {
                    foreach (var gTool in gTools)
                    {
                        ToolStripButton tsbtn = new ToolStripButton();
                        tsbtn.Name = gTool.TMenuId.ToString();
                        tsbtn.Text = gTool.TMenuName;
                        //图片
                        if (!string.IsNullOrEmpty(gTool.TMPic))
                            tsbtn.Image = Image.FromFile(Application.StartupPath + "/" + gTool.TMPic);
                        //图片与文本显示方式
                        tsbtn.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                        //文本与图片的显示位置
                        tsbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                        tsbtn.Tag = gTool;
                        tsbtn.Click += Tsbtn_Click; ;//单击事件注册
                        WMS_Tools.Items.Add(tsbtn);
                    }
                    ToolStripSeparator sp = new ToolStripSeparator();
                    WMS_Tools.Items.Add(sp);
                }
            }

        }

        private void Tsbtn_Click(object sender, EventArgs e)
        {
            ToolStripButton tsbtn = sender as ToolStripButton;
            if (tsbtn.Tag != null)
            {
                ToolMenuInfoModel tmInfo = tsbtn.Tag as ToolMenuInfoModel;
                string mUrl = tmInfo.TMUrl;
                if (!string.IsNullOrEmpty(mUrl))
                    CreateForm(mUrl, tmInfo.IsTop);
                else
                {
                    //退出系统
                    if (tmInfo.TMDesp == ToolMenuDesp.ExitSystem.ToString())
                    {
                        Application.Exit();
                    }
                    else if (tmInfo.TMDesp == ToolMenuDesp.RefreshMenu.ToString())
                    {
                        AddMenusAndToolMenus();
                    }
                    //更换操作者
                    else if (tmInfo.TMDesp == ToolMenuDesp.ChangeActor.ToString())
                    {
                        // 重新启动应用程序
                        //Application.Restart();
                        this.Hide();
                        fLogin.Show();
                        isFirst = 2;

                    }
                }
            }
        }

        private void CreateForm(string url, int isTop)
        {
            //程序集的名称
            string assName = this.GetType().Assembly.GetName().Name;
            string frmName = url.Substring(url.LastIndexOf('.') + 1);
            if (!FormUtility.CheckOpenForm(frmName))
            {
                ObjectHandle t = Activator.CreateInstance(assName, assName + "." + url);
                Form f = (Form)t.Unwrap();

                if (f.Name.Contains(MenuDesp.ModifyPwd.ToString()))//修改密码页面传值
                {
                    f.Tag = new FMPwdModel()
                    {
                        UName = uName,
                        FLogin = this.fLogin,
                        FMain = this
                    };
                }
                else
                    f.Tag = uName;

                if (isTop == 0)
                {
                    //内嵌到选项卡里
                    WMS_Pages.AddTabFormPage(f);
                }
                else
                {
                    //顶级显示
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.WindowState = FormWindowState.Normal;
                    f.ShowDialog();
                }
            }
        }

        private void AddMenuItem(List<MenuInfoModel> mList, ToolStripMenuItem pMenu, int PId)
        {
            var childList = mList.Where(m => m.ParentId == PId);
            foreach (var child in childList)
            {
                ToolStripMenuItem mi = new ToolStripMenuItem();
                mi.Name = child.MId.ToString();
                mi.Text = child.MName.ToString();
                if (!string.IsNullOrEmpty(child.MKey))
                {
                    //alt+K
                    string sKey = child.MKey.ToString().Trim();
                    //设置Alt快捷键  Ctrl+P   Shift+C
                    if (sKey.Length > 1 && sKey.Split('+')[0].ToLower() == "alt" && child.ParentId == 0)
                    {
                        mi.Text += $"(&{sKey.Split('+')[1]})";
                    }
                    mi.ShortcutKeys = SetShortKeys(sKey);
                }
                //菜单项关联页面
                if (!string.IsNullOrEmpty(child.MUrl))
                {
                    mi.Tag = child;
                }
                if(mList.Where(m=>m.ParentId == child.MId).Count() == 0)
                {
                    mi.Click += Mi_Click;
                }
                
                if (pMenu != null)
                    pMenu.DropDownItems.Add(mi);
                else 
                    WMS_Menus.Items.Add(mi);//cqy刚开始还没有ToolStripMenuItem类型的，还需要WMS_Menus添加
                AddMenuItem(mList, mi, child.MId);//为当前菜单项添加它的子菜单
            }
        }

        private void Mi_Click(object sender, EventArgs e)
        {
            // 获取单击的菜单项
            ToolStripMenuItem mi = sender as ToolStripMenuItem;
            if (mi.Tag != null)
            {
                MenuInfoModel mInfo = mi.Tag as MenuInfoModel;
                if (!string.IsNullOrEmpty(mInfo.MUrl))
                    CreateForm(mInfo.MUrl, mInfo.IsTop);
                else
                {

                }
            }
        }


        /// 获取快捷键
        /// </summary>
        /// <param name="mkey"></param>
        /// <returns></returns>
        private Keys SetShortKeys(string mkey)
        {
            Keys reKey = default(Keys);
            string[] arrKeys = mkey.Split('+');
            if (arrKeys.Length == 2)
            {
                Keys k;
                Enum.TryParse<Keys>(arrKeys[1], out k);
                if (arrKeys[0].ToLower() == "ctrl")
                {
                    reKey = Keys.Control | k;
                }
                else if (arrKeys[0].ToLower() == "alt")
                {
                    reKey = Keys.Alt | k;
                }
                else if (arrKeys[0].ToLower() == "shift")
                {
                    reKey = Keys.Shift | k;
                }
            }
            else if (arrKeys.Length == 3)
            {
                Keys k;
                Enum.TryParse<Keys>(arrKeys[2], out k);
                string start = arrKeys[0].ToLower() + "+" + arrKeys[1].ToLower();
                switch (start)
                {
                    case "shift+alt":
                        reKey = Keys.Shift | Keys.Alt | k;
                        break;
                    case "ctrl+alt":
                        reKey = Keys.Control | Keys.Alt | k;
                        break;
                    case "ctrl+shift":
                        reKey = Keys.Control | Keys.Shift | k;
                        break;
                }
            }
            else if (arrKeys.Length == 4)
            {
                Keys k;
                Enum.TryParse<Keys>(arrKeys[3], out k);
                reKey = Keys.Control | Keys.Shift | Keys.Alt | k;
            }
            Keys key = (Keys)reKey;
            return reKey;

        }

        /// <summary>
        /// 特殊菜单项说明
        /// </summary>
        private enum MenuDesp
        {
            ExitSystem = 1,
            ModifyPwd = 2,
            OpenSys = 3,
            UnOpenSys = 4
        }
        /// <summary>
        /// 特殊工具栏项
        /// </summary>
        private enum ToolMenuDesp
        {
            ExitSystem=1,
            ChangeActor= 2,
            RefreshMenu
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //太不友好？---选择机会---确认是否关闭   是--关闭； 否---不关闭
            //会出现两弹框？？
            if (MessageHelper.Confirm("关闭系统", "您确定要退出系统？") == DialogResult.OK)
            {
                Application.ExitThread();//退出消息循环
            }
            else
                e.Cancel = true;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            TabPage tabPage = WMS_Pages.SelectedTab;
            if (tabPage != null)
            {
                WMS_Pages.TabPages.Remove(tabPage);
                FormUtility.CloseOpenForm(tabPage.Name);
            }
        }

        private void FrmMain_VisibleChanged(object sender, EventArgs e)
        {
            if (isFirst == 2)
            {
                InitMenuInfo();
                isFirst = 1;
            }
        }
    }
}
