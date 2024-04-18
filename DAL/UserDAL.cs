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
    public class UserDAL:BaseDAL<UserInfoModel>
    {
        public int Login(string UserName, string PassWord) 
        {
            string strWhere = " UserName=@UserName and @UserPwd=@UserPwd";
            SqlParameter[] paras = { 
                new SqlParameter("@UserName",UserName),
                new SqlParameter("@UserPwd",PassWord)
            };
            string cols = "UserId";
            UserInfoModel userInfo = GetModel(strWhere, cols, paras);
            if(userInfo != null)
            {
                return userInfo.UserId;
            }
            else { return 0; }
        }
    }
}
