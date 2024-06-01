using BLL;
using Common;
using Models.DModels;
using Sunny.UI;
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

namespace WinWMS.SM
{
    public partial class FrmRight : Form
    {
        public FrmRight()
        {
            InitializeComponent();
        }
        RoleBLL roleBLL = new RoleBLL();
        MenuBLL menuBLL = new MenuBLL();
        string uName = "";
        int roleId = 0;
        private bool isAdmin = false;
        bool blEnablecboRoles=false;//决定了什么时候该cboRoles下拉框的事件生效

        private void FrmRight_Load(object sender, EventArgs e)
        {
            LoadRoleList();
            if (this.Tag != null)
            {
                //从主页面打开
                if (this.Tag is string)
                {
                    // this.Tag 是一个字符串
                    string tagString = this.Tag as string;
                }
                //从角色管理页面打开
                else if (this.Tag is object tagObject)
                {
                    // 尝试将 Tag 转换为动态对象
                    dynamic data = tagObject;

                    uName = data.UName;
                    roleId = data.RoleId;
                }
                //todo
                blEnablecboRoles = true;
                tcRights.SelectedIndex = 0;

                LoadTvMenus();
                LoadTvToolMenus();
                if (roleId>0)
                {
                    cboRoles.SelectedValue = roleId;
                    cboRoles.Enabled = false;
                }
                else
                    cboRoles.SelectedValue= roleId;
            }
        }

        private void LoadTvToolMenus()
        {
            
        }

        /// <summary>
        /// 加载菜单数据
        /// </summary>
        private void LoadTvMenus()
        {
            List<MenuInfoModel> menuList = menuBLL.GetTvMenus();
            tvMenus.Nodes.Clear();
            tvMenus.CheckBoxes = true;
            TreeNode root = new TreeNode() { Name = "0", Text = "系统菜单" };
            tvMenus.Nodes.Add(root);
            CreateMenuNode(menuList, root, 0);
            tvMenus.ExpandAll();
        }

        private void CreateMenuNode(List<MenuInfoModel> menuList, TreeNode pNode, int parentId)
        {
            List<MenuInfoModel> mList = menuList.Where(m=>m.ParentId==parentId).ToList();
            foreach (var m in mList)
            {
                TreeNode treeNode = new TreeNode() { Name = m.MId.ToString(), Text = m.MName };
                pNode.Nodes.Add(treeNode);
                CreateMenuNode(menuList,treeNode,m.MId);
            }
        }

        private void LoadRoleList()
        {
            List<RoleInfoModel> roleList = roleBLL.GetAllRoles();
            roleList.Insert(0,new RoleInfoModel()
            {
                RoleId = 0,
                RoleName = "请选择角色",
            });
            cboRoles.DataSource = roleList;
            cboRoles.DisplayMember = "RoleName";
            cboRoles.ValueMember = "RoleId";
            cboRoles.SelectedIndex = 0;
        }

        private void cboRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blEnablecboRoles)
            {
                int rId = cboRoles.SelectedValue.GetInt();
                CheckIsAdmin(rId);
                if (isAdmin)
                {
                    tvMenus.Nodes[0].Checked = true;
                    CheckAllNodes(tvMenus.Nodes[0]);
                    btnSubmit.Enabled = false;
                }
                else
                {
                    btnSubmit.Enabled = true;
                    tvMenus.Nodes[0].Checked = false;
                    CheckAllNodes(tvMenus.Nodes[0]);
                    if (rId > 0)
                    {
                        List<int> menuIds = roleBLL.GetRoleMenuList(rId);
                        if (menuIds.Count > 0)
                            LoadCheckedNodes(menuIds, tvMenus.Nodes[0]);
                    }
                }
            }
        }

        /// <summary>
        /// 加载当前角色拥有的菜单项，将它们打勾
        /// </summary>
        /// <param name="menuIds"></param>
        /// <param name="treeNode"></param>
        private void LoadCheckedNodes(List<int> menuIds, TreeNode treeNode)
        {
            foreach (TreeNode chird in treeNode.Nodes)
            {
                if (menuIds.Contains(chird.Name.GetInt()))
                {
                    chird.Checked = true;
                    LoadCheckedNodes(menuIds, chird);
                }
            }
        }

        private void CheckAllNodes(TreeNode treeNode)
        {
            bool bl = treeNode.Checked;
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = bl;
                CheckAllNodes(node);
            }
        }

        private void CheckIsAdmin(int rId)
        {
            isAdmin = false;
            RoleInfoModel roleInfo = roleBLL.GetRoleInfoById(rId);
            if (roleInfo != null)
            {
                if(roleInfo.IsAdmin == 1)
                {
                    isAdmin = true;
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int rId = cboRoles.SelectedValue.GetInt();
            if (rId == 0)
            {
                MessageHelper.MsgErrorShow("请先选择一个角色");
                return;
            }
            List<int> menuIds = new List<int>();
            //父菜单没选到，已经解决，通过事件 AfterCheck
            menuIds = GetSelectedNode(menuIds, tvMenus.Nodes[0]);
            List<int> tMenuIds = new List<int>();

            bool bl = false;
            if (menuIds.Count == 0 && tMenuIds.Count == 0)
            {
                MessageHelper.MsgErrorShow("请设置该角色的菜单和工具栏权限！");
                return;
            }
            else if (menuIds.Count == 0 && tMenuIds.Count > 0)
            {
                if (MessageHelper.Confirm("权限设置", "您没有设置系统菜单权限，将会无法使用系统菜单功能！是否继续？") == DialogResult.OK)
                {
                    //设置工具栏权限
                    bl = roleBLL.SetRoleRight(rId, null, tMenuIds, uName);
                }
            }
            else if (menuIds.Count > 0 && tMenuIds.Count == 0)
            {
                if (MessageHelper.Confirm("权限设置", "您没有设置工具菜单权限，将会无法使用工具栏菜单功能！是否继续？") == DialogResult.OK)
                {
                    //设置菜单权限
                    bl = roleBLL.SetRoleRight(rId, menuIds, null, uName);
                }
            }

            if (bl)
            {
                MessageHelper.Info("权限设置", "权限设置保存成功！");
            }
            else
            {
                MessageHelper.MsgErrorShow("权限设置保存失败！");
                return;
            }
        }

        /// <summary>
        /// 获取到当前角色对应的所有的打勾状态的项
        /// </summary>
        /// <param name="menuIds"></param>
        /// <param name="treeNode"></param>
        /// <returns></returns>
        private List<int> GetSelectedNode(List<int> menuIds, TreeNode treeNode)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                if (node.Checked)
                    menuIds.Add(node.Name.ToInt());
                GetSelectedNode(menuIds, node);
            }

            return menuIds;
        }
        /// <summary>
        /// 勾选状态更改后发生,有时候勾选子项之后，其父项的check状态并不是true,子项也不是全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvMenus_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //e.Node 当前操作节点

            if (e.Action == TreeViewAction.ByKeyboard || e.Action == TreeViewAction.ByMouse)
            {
                //设置当前节点的子节点的勾选处理
                SetChildNodesCheckState(e.Node);
                //设置当前节点的父节点的勾选处理
                SetParentNodesCheckState(e.Node);
                var d = tvMenus.Nodes[0];
            }
        }

        /// <summary>
        /// 递归处理 子节点勾选
        /// </summary>
        /// <param name="node"></param>
        private void SetChildNodesCheckState(TreeNode node)
        {
            foreach (TreeNode child in node.Nodes)
            {
                child.Checked = node.Checked;
                SetChildNodesCheckState(child);
            }
        }

        /// <summary>
        /// //递归处理 父节点勾选
        /// </summary>
        /// <param name="node"></param>
        private void SetParentNodesCheckState(TreeNode node)
        {
            TreeNode pNode = node.Parent;//父节点
            if (pNode != null)
            {
                bool bl = false;
                foreach (TreeNode tn in pNode.Nodes)
                {
                    if (tn.Checked)
                    {
                        bl = true;
                        break;
                    }
                }
                pNode.Checked = bl;
                SetParentNodesCheckState(pNode);
            }
        }
    }
}
