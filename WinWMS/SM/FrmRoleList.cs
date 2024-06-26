﻿using BLL;
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
    public partial class FrmRoleList : Form
    {
        public FrmRoleList()
        {
            InitializeComponent();
        }

        private RoleBLL roleBLL = new RoleBLL();
        private string uName = "";

        private void FrmRoleList_Load(object sender, EventArgs e)
        {
            Action act = () =>
            {
                if (this.Tag != null)
                    uName = this.Tag.ToString();
                LoadAllRoles();
            };
            act.TryCatch("角色管理页面加载异常！");
        }

        private void LoadAllRoles()
        {
            List<RoleInfoModel> list = roleBLL.GetAllRoleList();
            dgvRoles.AutoGenerateColumns = false;
            dgvRoles.DataSource = list;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowRoleInfoPage(1,0);
        }

        /// <summary>
        /// 显示角色新增或修改页面
        /// </summary>
        /// <param name="actType"></param>
        /// <param name="roleId"></param>
        private void ShowRoleInfoPage(int actType, int roleId)
        {
            FrmRoleInfo fRole = new FrmRoleInfo();
            fRole.Tag = new FInfoModel()
            {
                ActType = actType,
                FId = roleId,
                UName = uName,
                ReLoad = LoadAllRoles
            };
            fRole.ShowDialog();
        }

        private void dgvRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Action act = () =>
            {
                if (e.RowIndex >= 0)
                {
                    var curCell = dgvRoles.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    string cellVal = curCell.FormattedValue.ToString();
                    RoleInfoModel roleInfo = dgvRoles.Rows[e.RowIndex].DataBoundItem as RoleInfoModel;
                    switch (cellVal)
                    {
                        case "修改":
                            ShowRoleInfoPage(2, roleInfo.RoleId);
                            break;
                        case "分配权限":
                            ShowRightPage(roleInfo.RoleId);
                            break;
                        case "删除":
                            DeleteRole(roleInfo);
                            break;

                    }
                }
            };
            act.TryCatch("行操作异常！");
        }

        /// <summary>
        /// 单个角色信息删除
        /// </summary>
        /// <param name="roleInfo"></param>
        private void DeleteRole(RoleInfoModel roleInfo)
        {
            string titleMsg = "删除角色";
            if (MessageHelper.Confirm(titleMsg, "您确定要删除选择的角色吗？会连同与角色相关的数据一并删除？") == DialogResult.OK)
            {
                List<int> roleIds = new List<int>();
                roleIds.Add(roleInfo.RoleId);
                bool bl = roleBLL.DeleteRoles(roleIds, 0);
                if (bl)
                {
                    MessageHelper.Info(titleMsg, $"选择角色信息删除成功！");
                    LoadAllRoles();
                }
                else
                {
                    MessageHelper.MsgErrorShow($"选择角色信息删除失败！");
                    return;
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvRoles.SelectedRows.Count > 0)
            {
                string titleMsg = "删除角色";
                if (MessageHelper.Confirm(titleMsg, "您确定要删除选择的角色吗？会连同与角色相关的数据一并删除？") == DialogResult.OK)
                {
                    List<int> roleIds = new List<int>();
                    foreach (DataGridViewRow row in dgvRoles.SelectedRows)
                    {
                        RoleInfoModel roleInfo = row.DataBoundItem as RoleInfoModel;
                        roleIds.Add(roleInfo.RoleId);
                    }
                    bool bl = roleBLL.DeleteRoles(roleIds, 0);
                    if (bl)
                    {
                        MessageHelper.Info(titleMsg, $"选择角色信息删除成功！");
                        LoadAllRoles();
                    }
                    else
                    {
                        MessageHelper.MsgErrorShow($"选择角色信息删除失败！");
                        return;
                    }
                }

            }
            else
            {
                MessageHelper.MsgErrorShow("请选择要删除的角色信息！");
                return;
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            ShowRightPage(0);
        }

        /// <summary>
        /// 打开权限分配页面
        /// </summary>
        /// <param name="actType"></param>
        /// <param name="roleId"></param>
        private void ShowRightPage(int roleId)
        {
            FrmRight fRight = new FrmRight();
            fRight.Tag = new 
            {
                UName = uName,
                RoleId = roleId
            };
            fRight.ShowDialog();
        }
    }
}
