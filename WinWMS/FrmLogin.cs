using BLL;
using Common.Encrypt;
using Models.VModels;
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

namespace WinWMS
{
    public partial class FrmLogin : Form
    {
        UserBLL userBLL = new UserBLL();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string UserName = txtUserName.Text;
            string PassWord = txtUserPwd.Text;

            if (string.IsNullOrEmpty(UserName))
            {
                MessageHelper.Error("错误", "请输入用户名！");
                txtUserName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(PassWord))
            {
                MessageHelper.Error("错误", "请输入密码！");
                txtUserPwd.Focus();
                return;
            }

            string enPwd = MD5Encrypt.Encrypt(txtUserPwd.Text);
            List<ViewUserRoleModel> urList = userBLL.Login(UserName, enPwd);
            if (urList == null || urList.Count == 0)
            {
                MessageHelper.MsgErrorShow("用户名或者密码错误");
                return;
            }
            else
            {
                if (FormUtility.GetOpenForm("FrmMain") == null)
                {
                    FrmMain frmMain = new FrmMain();
                    frmMain.Tag = new LoginModel()
                    {
                        URList = urList,
                        LoginForm = this
                    };
                    frmMain.Show();
                }
                else
                {
                    //更换操作员todo
                    foreach (Form item in Application.OpenForms)
                    {
                        if (item.Name == "FrmMain")
                        {
                            item.Tag = new LoginModel()
                            {
                                URList = urList,
                                LoginForm = this
                            };
                            item.Show();
                            break;
                        }
                    }
                }
            }
            this.Hide();

        }

    }
}
