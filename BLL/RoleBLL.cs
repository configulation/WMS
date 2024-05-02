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

        public List<RoleInfoModel> GetALLRoleList(string roleName)
        {
            return roleDAL.GetALLRoleList(roleName);
        }
    }
}
