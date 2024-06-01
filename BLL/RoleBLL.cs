using DAL;
using Models.DModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RoleBLL
    {
        RoleDAL roleDAL = new RoleDAL();
        RoleMenuDAL rmDAL = new RoleMenuDAL();
        

        /// <summary>
        /// 获取绑定的角色列表（主要用于绑定下拉框或列表框）
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public List<RoleInfoModel> GetALLRoleList(string roleName)
        {
            return roleDAL.GetALLRoleList(roleName);
        }

        /// <summary>
        /// 获取所有角色列表
        /// </summary>
        /// <returns></returns>
        public List<RoleInfoModel> GetAllRoleList()
        {
            return roleDAL.GetAllRoleList();
        }

        /// <summary>
        /// 获取指定的角色信息
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public RoleInfoModel GetRole(int roleId)
        {
            return roleDAL.GetRole(roleId);
        }

        public bool ExistRoleName(string roleName)
        {
            return roleDAL.ExistRoleName(roleName);
        }

        /// <summary>
        /// 添加角色信息
        /// </summary>
        /// <param name="roleInfo"></param>
        /// <returns></returns>
        public bool AddRoleInfo(RoleInfoModel roleInfo)
        {
            return roleDAL.AddRoleInfo(roleInfo);
        }

        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="roleInfo"></param>
        /// <returns></returns>
        public bool UpdateRoleInfo(RoleInfoModel roleInfo)
        {
            return roleDAL.UpdateRoleInfo(roleInfo);
        }

        public bool DeleteRoles(List<int> roleIds, int delType)
        {
            return roleDAL.DeleteRoles(roleIds, delType);
        }

        /// <summary>
        /// 获取绑定的角色列表（主要用于绑定下拉框或列表框）
        /// </summary>
        /// <returns></returns>
        public List<RoleInfoModel> GetAllRoles()
        {
            return roleDAL.GetAllRoleList();
        }

        public RoleInfoModel GetRoleInfoById(int roleId)
        {
            return roleDAL.GetById(roleId, "RoleId,RoleName,Remark,IsAdmin");
        }

        /// <summary>
        /// 获取指定角色的菜单编号集合
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<int> GetRoleMenuList(int roleId)
        {
            var result = rmDAL.GetRoleMenuList(roleId);

            return result.Select(rm=>rm.MId).ToList();
        }

        public bool SetRoleRight(int rId, List<int> menuIds, List<int> tMenuIds, string uName)
        {
            List<RoleMenuInfoModel> rmList = new List<RoleMenuInfoModel>();
            List<RoleTMenuInfoModel> rtmList = new List<RoleTMenuInfoModel>();
            if (menuIds !=null)
            {
                foreach (int menuId in menuIds)
                {
                    rmList.Add(new RoleMenuInfoModel()
                    {
                        MId = menuId,
                        RoleId = rId,
                        Creator = uName
                    });
                }
            }
            if (tMenuIds != null)
            {
                foreach (int tmenu in tMenuIds)
                {
                    rtmList.Add(new RoleTMenuInfoModel()
                    {
                        TMenuId = tmenu,
                        RoleId = rId,
                        Creator = uName
                    });
                }
            }

           return roleDAL.SetRoleRight(rId, rmList, rtmList);
        }
    }
}
