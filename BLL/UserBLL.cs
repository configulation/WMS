using DAL;
using Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserBLL
    {
        UserDAL userDAL = new UserDAL();
        ViewUserRoleDAL vurDAL = new ViewUserRoleDAL();

        public List<ViewUserRoleModel> Login(string UserName, string PassWord)
        {
            List<ViewUserRoleModel> viewUserRoles = new List<ViewUserRoleModel>();

            int id = userDAL.Login(UserName, PassWord);
            if (id > 0)
            {
                viewUserRoles = vurDAL.GetUserRoles(id);
            }

            return viewUserRoles;
        }
    }
}
