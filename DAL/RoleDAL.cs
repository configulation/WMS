using DAL.Base;
using Helper;
using Models.DModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RoleDAL:BaseDAL<RoleInfoModel>
    {
        

        public List<RoleInfoModel> GetALLRoleList(string roleName)
        {
            string strWhere = " 1=1";
            string cols = "RoleId,RoleName,IsAdmin";
            SqlParameter[] paras =
            {
                new SqlParameter("@RoleName",roleName)
            };
            if (!string.IsNullOrEmpty(roleName))
            {
                strWhere += $" and RoleName like '%{roleName}%' ";
            }

            return GetModelList(strWhere,cols,"RoleId", paras);
        }

        /// <summary>
        /// 获取所有角色列表
        /// </summary>
        /// <returns></returns>
        public List<RoleInfoModel> GetAllRoleList()
        {
            string cols = "RoleId,RoleName,Remark";
            return GetAllModelList(cols,"",0);
        }

        /// <summary>
        /// 获取指定的角色信息
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public RoleInfoModel GetRole(int roleId)
        {
            string cols = "RoleName,Remark,IsAdmin";
            return GetById(roleId, cols);
        }

        /// <summary>
        /// 判断角色名称是否已存在
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public bool ExistRoleName(string roleName)
        {
            return ExistsByName("RoleName", roleName);
        }

        /// <summary>
        /// 添加角色信息
        /// </summary>
        /// <param name="roleInfo"></param>
        /// <returns></returns>
        public bool AddRoleInfo(RoleInfoModel roleInfo)
        {
            return Add(roleInfo, "RoleName,Remark,Creator", 0) > 0;
        }

        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="roleInfo"></param>
        /// <returns></returns>
        public bool UpdateRoleInfo(RoleInfoModel roleInfo)
        {
            return Update(roleInfo, "RoleId,RoleName,Remark", "");
        }

        public bool DeleteRoles(List<int> roleIds, int delType)
        {
            List<string> sqlList = new List<string>();
            foreach (var roleId in roleIds)
            {
                List<string> eachIdSqlList = GetDeleteRoleSql(roleId, delType);
                sqlList.AddRange(eachIdSqlList);
            }

            return SqlHelper.ExecuteTrans(sqlList);
        }

        public List<string> GetDeleteRoleSql(int roleId, int delType)
        {
            List<string> sqlList = new List<string>();
            string[] tables = { "RoleInfos", "UserRoleInfos", "RoleMenuInfos", "RoleTMenuInfos" };
            string strWhere = $" roleId = {roleId}";
            if (delType == 0)
            {
                foreach (var table in tables)
                {
                    sqlList.Add($"update {table} set IsDeleted=1 where {strWhere}");
                }
            }
            else if (delType == 1)
            {
                foreach (var table in tables)
                {
                    sqlList.Add($"delete from {table}  where {strWhere}");
                }
            }

            return sqlList;
        }
    }
}
