using DAL.Base;
using Models.VModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ViewUserRoleDAL:BQuery<ViewUserRoleModel>
    {
        public List<ViewUserRoleModel> GetUserRoles(int UserId)
        {
            string strWhere = " UserId=@UserId ";
            string cols = "UserId,UserName,RoleId,RoleName,IsAdmin";
            SqlParameter[] paras = new SqlParameter[] 
            { 
                new SqlParameter("@UserId",UserId)
            };
             List<ViewUserRoleModel> viewUserRoleModels = GetModelList(strWhere, cols,"UserId",paras);

            return viewUserRoleModels;
        }
    }
}
