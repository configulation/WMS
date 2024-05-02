using DAL;
using DAL.Base;
using Helper;
using Models.DModels;
using Models.VModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public List<UserInfoModel> GetUserList(string uName)
        {
            return userDAL.GetUserList(uName);
        }

        public List<ViewUserRoleModel> GetRolesByUserId(int id)
        {
            List<ViewUserRoleModel> viewUserRoles = new List<ViewUserRoleModel>();

            if (id > 0)
            {
                viewUserRoles = vurDAL.GetUserRoles(id);
            }

            return viewUserRoles;
        }

        public UserInfoModel GetUserInfoById(int id)
        {
            return userDAL.GetUserInfoById(id);
        }

        public bool AddUserRoleList(UserInfoModel userInfo, List<UserRoleInfoModel> urList)
        {
            return userDAL.AddUserRoleList(userInfo, urList);
        }

        public bool UpdateUserRoleList(UserInfoModel userInfo, List<UserRoleInfoModel> urList, List<UserRoleInfoModel> urListNew)
        {

            return userDAL.UpdateUserRoleList(userInfo, urList, urListNew);
        }
    }
}
