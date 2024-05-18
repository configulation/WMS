using BLL;
using Common;
using Models.DModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;
using WinFModels;

namespace WinWMS.FModels
{
    public partial class FrmMenuInfo : Form
    {
        public FrmMenuInfo()
        {
            InitializeComponent();
        }

        MenuBLL menuBLL = new MenuBLL();
        FInfoModel fModel = null;
        string uName = "";
        int menuId = 0;
        string oldName = "";//用于检测菜单名有没有被修改，有则判断数据表有有没有重复记录

        private void FrmMenuInfo_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                if (this.Tag != null)
                {
                    fModel = this.Tag as FInfoModel;
                    if (fModel != null)
                    {
                        LoadCboParents();//加载父菜单下拉框
                        LoadCboForms();//加载关联页面下拉框
                        uName = fModel.UName;
                        menuId = fModel.FId;
                        int actType = fModel.ActType;
                        string title = "";
                        switch (actType)
                        {
                            case 1:
                                title = "新增";
                                ClearInfo();
                                break;
                            case 2:
                                title = "修改";
                                InitMenuInfo(menuId);
                                tsbtnClear.Enabled = false;
                                break;
                            case 3:
                                title = "添加子类";
                                cboParents.SelectedValue = menuId;
                                cboParents.Enabled = false;
                                break;
                            case 4:
                                title = "详细信息";
                                InitMenuInfo(menuId);
                                tsbtnSave.Enabled = false;
                                tsbtnClear.Enabled = false;
                                break;
                        }
                    }
                }
            };
            act.TryCatch("菜单信息页面加载异常");
        }

        private void InitMenuInfo(int menuId)
        {
            MenuInfoModel menuInfo = menuBLL.GetMenuInfoById(menuId);
            if (menuInfo !=null)
            {
                txtMName.Text = menuInfo.MName;
                oldName = menuInfo.MName.ToString();
                txtMKey.Text = menuInfo.MKey;
                txtOrder.Text = menuInfo.MOrder.ToString();
                txtMDesp.Text = menuInfo.MDesp;
                if (menuInfo.ParentName !=null)
                {
                    cboParents.SelectedValue = menuInfo.ParentId;
                }
                if (!string.IsNullOrEmpty(menuInfo.MUrl))
                {
                    cboUrls.SelectedValue = menuInfo.MUrl;
                }
                if (menuInfo.IsTop == 1)
                {
                    chkTop.Checked = true;
                }
                else
                { chkTop.Checked = false; }
            }
        }


        private void LoadCboForms()
        {
            string assName = this.GetType().Assembly.GetName().Name;
            Type[] types = this.GetType().Assembly.GetTypes();
            var frmTypes = types.Where(t=> t.BaseType.Name == "Form");

            List<KeyValuePair<string,string>> listForms = new List<KeyValuePair<string,string>>();
            listForms.Add(new KeyValuePair<string, string>("", "请选择页面"));

            foreach ( var t in frmTypes )
            {
                Form f = (Form)Activator.CreateInstance(t);
                listForms.Add(new KeyValuePair<string, string>(t.FullName.Remove(0,assName.Length+1), f.Text));
                f.Dispose();
            }

            cboUrls.DataSource = listForms;
            cboUrls.DisplayMember = "Value";
            cboUrls.ValueMember = "Key";
            cboUrls.SelectedItem = "";
        }

        private void LoadCboParents()
        {
            List<MenuInfoModel> menuList = menuBLL.GetAllMenus();
            menuList.Insert(0, new MenuInfoModel()
            {
                MName = "请选择",
                MId = 0
            });
            cboParents.DataSource = menuList;
            cboParents.DisplayMember = "MName";
            cboParents.ValueMember = "MId";
        }

        /// <summary>
        /// 清空
        /// </summary>
        private void ClearInfo()
        {
            txtMName.Clear();
            txtMKey.Clear();
            txtOrder.Clear();
            txtMDesp.Clear();
            chkTop.Checked = false;
            cboParents.SelectedIndex = 0;
            cboUrls.SelectedIndex = 0;
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            Action act = () =>
            {
                //1、接受信息录入
                string mName = txtMName.Text.Trim();
                string mKey = txtMKey.Text.Trim();
                int parentId = cboParents.SelectedValue.GetInt();
                string parentName = cboParents.Text.Trim();
                string mUrl = cboUrls.SelectedValue.ToString();
                if (parentId == 0)
                    parentName = null;
                if (string.IsNullOrEmpty(mUrl))
                    mUrl = null;
                int mOrder = txtOrder.Text.Trim().GetInt();
                int isTop = chkTop.Checked ? 1 : 0;
                string mDesp = txtMDesp.Text.Trim();
                //2、判断菜单名称不能为空
                if (string.IsNullOrEmpty(mName))
                {
                    MessageHelper.Error("", "菜单名称不能为空！");
                    txtMName.Focus();
                    return;
                }
                //3、判断菜单名称是否已存在
                if (string.IsNullOrEmpty(oldName) || (!string.IsNullOrEmpty(oldName) && oldName != mName))
                {
                    if (menuBLL.ExistMName(mName))
                    {
                        MessageHelper.Error("", "菜单名称存在重复值！");
                        txtMName.Focus();
                        return;
                    }
                }
                //4、信息封装
                MenuInfoModel menuInfo = new MenuInfoModel()
                {
                    MName = mName,
                    ParentId = parentId,
                    MKey = mKey,
                    MDesp = mDesp,
                    IsTop = isTop,
                    Creator = fModel.UName,
                    MUrl = mUrl,
                    ParentName = parentName,
                };
                //5、执行方法（新增、修改）
                bool bl = false;
                string title = fModel.ActType == 1 ? "新增" : "修改";
                if (fModel.ActType == 1)
                {
                    bl = menuBLL.AddMenuInfo(menuInfo);
                    if (bl)
                    {
                        MessageHelper.Info($"{title}菜单", $"{mName}{title}成功！");
                        fModel.ReLoad?.Invoke();
                    }
                    else
                    {
                        MessageHelper.Info($"{title}菜单", $"{mName}{title}失败！");
                    }
                }
                else if (fModel.ActType == 2)
                {
                    menuInfo.MId = menuId;
                    bool blUpdateParentName = false;
                    if (oldName != mName)
                        blUpdateParentName = true;
                    bl = menuBLL.UpdateMenuInfo(menuInfo, blUpdateParentName);
                    if (bl)
                    {
                        MessageHelper.Info($"{title}菜单", $"{mName}{title}成功！");
                        fModel.ReLoad?.Invoke();
                    }
                    else
                    {
                        MessageHelper.Info($"{title}菜单", $"{mName}{title}失败！");
                    }
                }
            };
            act.TryCatch("保存菜单信息异常");
        }
    }
}
