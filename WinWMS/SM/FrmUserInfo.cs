using BLL;
using Common.Encrypt;
using Models.DModels;
using Models.VModels;
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

namespace WinWMS.SM
{
    public partial class FrmUserInfo : Form
    {
        public FrmUserInfo()
        {
            InitializeComponent();
        }
        RoleBLL roleBLL = new RoleBLL();
        UserBLL userBLL = new UserBLL();

        //加载所有的角色
        List<RoleInfoModel> allRoleList = new List<RoleInfoModel>();
        //修改前用户的用户角色对应关系
        List<ViewUserRoleModel> vurList = new List<ViewUserRoleModel>();
        string oldUserName = "";
        FInfoModel fUser = null;
        int UserId = 0;

        private void FrmUserInfo_Load(object sender, EventArgs e)
        {
            if(this.Tag != null)
            {
                fUser= this.Tag as FInfoModel;
                //加载所有角色
                LoadRoleList();
                if (fUser.ActType == 1) 
                {
                    this.Text += "-新增";
                    txtUName.Clear();
                    txtUPwd.Clear();
                    rbEnabed.Checked = true;
                    UserId = 0;
                }
                else if (fUser.ActType == 2)
                {
                    this.Text += "-修改";
                    this.btnAdd.Text = "修改";
                    InitUserInfo(fUser.FId);
                }

            }
        }

        private void InitUserInfo(int id)
        {
            UserId = id;
            vurList = userBLL.GetRolesByUserId(id);
            UserInfoModel uInfo = userBLL.GetUserInfoById(id);
            if(uInfo != null) 
            {
                txtUName.Text = uInfo.UserName;
                if (uInfo.UserState == 1)
                {
                    rbEnabed.Checked = true;
                }
                else if (uInfo.UserState == 0) rbEnabed.Checked = true;
            }
            if(vurList != null)
            {
                foreach (var vur in vurList)
                {
                    for (int i = 0;i<allRoleList.Count;i++)
                    {
                        if (vur.RoleId == allRoleList[i].RoleId)
                        {
                            chkList.SetItemCheckState(i, CheckState.Checked);

                            break;
                        }
                    }
                }
            }

        }

        private void LoadRoleList()
        {
            allRoleList = roleBLL.GetALLRoleList("");
            chkList.Items.Clear();
            chkList.DataSource = allRoleList;
            chkList.DisplayMember = "RoleName";
            chkList.ValueMember = "RoleId";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string userName = txtUName.Text.Trim();
            string passWord = txtUPwd.Text.Trim();
            int userStatus = rbEnabed.Checked ? 1 : 0;
            if (string.IsNullOrEmpty(userName))
            {
                MessageHelper.Error("错误", "用户名不能为空");
                return;
            }
            if (fUser.ActType == 1 && string.IsNullOrEmpty(passWord))
            {
                MessageHelper.Error("错误", "密码不能为空");
                return;
            }
            if (passWord != "")
                passWord = MD5Encrypt.Encrypt(passWord);
            

            UserInfoModel userInfo = new UserInfoModel() {
                UserName = userName,
                UserPwd = passWord,
                UserState = userStatus,
                Creator = fUser.UName,
                CreateTime = DateTime.Now,
            };
            if (UserId > 0)
            {
                userInfo.UserId = UserId;
            }

            List<UserRoleInfoModel> urList = new List<UserRoleInfoModel>();
            for (int i = 0;i < chkList.Items.Count;i++)
            {
                if (chkList.GetItemChecked(i))
                {
                    RoleInfoModel roleInfo = chkList.Items[i] as RoleInfoModel;
                    urList.Add(new UserRoleInfoModel()
                    {
                        UserId = fUser.FId,
                        RoleId = roleInfo.RoleId,
                        Creator = fUser.UName
                    });
                }
            }

            List<UserRoleInfoModel> urListNew = new List<UserRoleInfoModel>();
            foreach (var ur in urList)
            {
                bool isExits = false;
                foreach (var vur in vurList)
                {
                    if (ur.RoleId == vur.RoleId)
                    {
                        isExits = true;
                        break;
                    }
                }
                if(!isExits)
                    urListNew.Add(ur);
            }


            if (fUser.ActType == 1)
            {
                bool blAdd = userBLL.AddUserRoleList(userInfo,urList);
                if (blAdd)
                {
                    MessageHelper.Info("添加用户", $"用户{userName}添加成功！");
                    fUser.ReLoad?.Invoke();
                }
                else
                {
                    MessageHelper.Error("添加用户", $"用户{userName}添加失败！");
                    return;
                }
            }
            else if (fUser.ActType == 2)
            {
                bool blUpdate = userBLL.UpdateUserRoleList(userInfo, urList, urListNew);
                if (blUpdate)
                {
                    MessageHelper.Info("修改用户", $"用户{userName}修改成功！");
                    fUser.ReLoad?.Invoke();
                }
                else
                {
                    MessageHelper.Error("修改用户", $"用户{userName}修改失败！");
                    return;
                }
            }

        }
    }
}
