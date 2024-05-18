using BLL;
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
using WinWMS.FModels;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinWMS.SM
{
    public partial class FrmMenuList : Form
    {
        public FrmMenuList()
        {
            InitializeComponent();
        }

        MenuBLL menuBLL = new MenuBLL();
        string uName = "";
        private void FrmMenuList_Load(object sender, EventArgs e)
        {
            Action action = () =>
            {
                if (this.Tag != null)
                {
                    uName = this.Tag.ToString();
                    LoadMenuList();
                }
            };
            action.TryCatch("菜单管理页面加载异常");
        }

        private void LoadMenuList()
        {
            string keywords = txtkeywords.Text.Trim();

            List<MenuInfoModel> menuList = menuBLL.GetMenuListByKeyWords(keywords);
            if (menuList.Count > 0)
            {
                dgvMenuList.AutoGenerateColumns = false;
                dgvMenuList.DataSource = menuList;
            }
        }

        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            ShowMenuInfoPage(1,0);
        }

        private void ShowMenuInfoPage(int actType, int menuId)
        {
            FrmMenuInfo fMenu = new FrmMenuInfo();
            fMenu.Tag = new FInfoModel()
            {
                ActType = actType,
                FId = menuId,
                UName = uName,
                ReLoad = LoadMenuList
            };
            fMenu.ShowDialog();
            
        }

        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
            if(dgvMenuList.SelectedRows.Count > 0)
            {
                MenuInfoModel menuInfo = dgvMenuList.SelectedRows[0].DataBoundItem as MenuInfoModel;
                if(menuInfo != null)
                {
                    ShowMenuInfoPage(2, menuInfo.MId);
                }
            }
            else
            {
                MessageHelper.Error("","请选择你要修改的菜单信息！");
                return;
            }
        }

        private void dgvMenuList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewCell currCell = dgvMenuList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                MenuInfoModel menuInfo = dgvMenuList.Rows[e.RowIndex].DataBoundItem as MenuInfoModel;

                string cellValue = currCell.FormattedValue.ToString();
                switch (cellValue)
                {
                    case "修改":
                        ShowMenuInfoPage(2, menuInfo.MId);
                        break;
                    case "添加子菜单":
                        ShowMenuInfoPage(3, menuInfo.MId);
                        break;
                    case "删除":
                        
                        break;
                }
            }
        }

        private void tsbtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMenuList.SelectedRows.Count >0)
            {
                if (MessageHelper.Confirm("删除菜单信息", "您确定要删除选择的菜单信息吗？删除菜单会连同菜单及其角色菜单关系数据一并删除？") == DialogResult.OK)
                {
                    List<MenuInfoModel> mList = new List<MenuInfoModel>();
                    foreach (DataGridViewRow r in dgvMenuList.SelectedRows)
                    {
                        mList.Add(r.DataBoundItem as MenuInfoModel);
                    }
                    //menuBLL.DeleteMenuInfo(mList.Select(m => { return m.MId; }).ToList(), 0) ;
                    bool bl = menuBLL.DeleteMenuInfo(mList.Select(m => m.MId).ToList(), 1);

                    if (bl)
                    {
                        MessageHelper.Info("删除菜单", "选择的菜单信息删除成功！");
                        LoadMenuList();
                    }
                    else
                    {
                        MessageHelper.Error("","选择的菜单信息删除失败！");
                        return;
                    }
                }
            }
            else
            {
                MessageHelper.Error("", "当前没有选择要删除的行");
            }
        }
    }
}
