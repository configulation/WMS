using DAL.Base;
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


    }
}
