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
            if (this.Tag != null)
            {
                uName = this.Tag.ToString();
                LoadMenuList();
            }
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

    }
}
