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
using WinFModels;

namespace WinWMS.SM
{
    public partial class FrmUserList : Form
    {
        public FrmUserList()
        {
            InitializeComponent();
        }

        string uName = "";
        UserBLL userBLL = new UserBLL();

        private void btnFind_Click(object sender, EventArgs e)
        {
            LoadUserList();
        }

        private void FrmUserList_Load(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                uName = this.Tag.ToString();
            }
            LoadUserList();
        }

        private void LoadUserList()
        {
            string uName = txtUserName.Text.Trim();
            List<UserInfoModel> userList = userBLL.GetUserList(uName);
            if (userList.Count>0)
            {
                dgvUserList.AutoGenerateColumns = false;
                dgvUserList.DataSource = userList;
                foreach (DataGridViewRow row in dgvUserList.Rows)
                {
                    UserInfoModel user = row.DataBoundItem as UserInfoModel;
                    if (user.UserState == 0)
                    {
                        row.Cells["EnableUser"].Value = "禁用";
                    }
                    else if (user.UserState == 1)
                    {
                        row.Cells["EnableUser"].Value = "启用";
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowUserInfo(1,0);
        }

        private void ShowUserInfo(int ActType, int Id)
        {
            FrmUserInfo fUI = new FrmUserInfo();
            fUI.Tag = new FInfoModel()
            {
                ActType = ActType,
                FId = Id,
                UName = uName,
                ReLoad = LoadUserList
            };
            fUI.ShowDialog();
        }

        private void dgvUserList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell curCell = dgvUserList.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCell;
            UserInfoModel userInfo = dgvUserList.Rows[e.RowIndex].DataBoundItem as UserInfoModel;
            if (curCell != null)
            {
                string cellValue = curCell.FormattedValue.ToString().Trim();
                switch(cellValue)
                {
                    case "修改":
                        ShowUserInfo(2,userInfo.UserId);
                        break;
                }
            }
        }
    }
}
