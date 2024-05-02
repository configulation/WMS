using Common;
using DAL.Base;
using Helper;
using Models.DModels;
using System;
using System.Collections.Generic;
using System.Data;
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

        public List<UserInfoModel> GetUserList(string uName)
        {
            string strWhere = " 1=1";
            string cols = "UserId,UserName,UserPwd,UserState,CreateTime";
            SqlParameter[] paras = 
            { 
                new SqlParameter("@UserName",uName)
            };
            if (!string.IsNullOrEmpty(uName))
            {
                strWhere += $" and UserName like '%{uName}%' ";
            }

            return GetModelList(strWhere,cols,"UserId",paras);
        }

        public UserInfoModel GetUserInfoById(int id)
        {
            string strWhere = " 1=1";
            string cols = "UserId,UserName,UserPwd,UserState,CreateTime";
            SqlParameter[] paras =
            {
                new SqlParameter("@UserId",id)
            };
            if (id >0)
            {
                strWhere += $" and UserId ={id} ";
            }

            return GetModel(strWhere, cols, paras);
        }

        public bool AddUserRoleList(UserInfoModel userInfo, List<UserRoleInfoModel> urList)
        {
            string colsUser = "UserId,UserName,UserPwd,UserState,Creator";
            string colsUserRole = "URId,UserId,RoleId,Creator";
            SqlModel sqlUser = CreateSql.CreateInsertSql<UserInfoModel>(userInfo, colsUser, 1);
            
            return SqlHelper.ExecuteTrans<bool>(cmd =>
            {
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sqlUser.Sql;
                    cmd.Parameters.Clear();
                    foreach (var p in sqlUser.Paras)
                    {
                        cmd.Parameters.Add(p);
                    }
                    object oId = cmd.ExecuteScalar();
                    if (oId.ToString() != "" && oId != null)
                    {
                        foreach (var ur in urList)
                        {
                            ur.UserId = oId.GetInt();
                            SqlModel sqlUR = CreateSql.CreateInsertSql<UserRoleInfoModel>(ur, colsUserRole, 0);
                            cmd.CommandText = sqlUR.Sql;
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Clear();
                            foreach (var p in sqlUR.Paras)
                            {
                                cmd.Parameters.Add(p);
                            }
                            cmd.ExecuteNonQuery();
                        }

                    }
                    cmd.Transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    cmd.Transaction.Rollback();
                    throw new Exception("添加用户异常", ex);
                }
            });
        }

        public bool UpdateUserRoleList(UserInfoModel userInfo, List<UserRoleInfoModel> urList, List<UserRoleInfoModel> urListNew)
        {
            string colsUser = "UserId,UserName,UserState";
            if (userInfo.UserPwd != "")
                colsUser += ",UserPwd";
            
            SqlModel upUser = CreateSql.CreateUpdateSql<UserInfoModel>(userInfo, colsUser,"");
            List<CommandInfo> cmdList = new List<CommandInfo>();
            cmdList.Add(new CommandInfo()
            {
                CommandText = upUser.Sql,
                IsProc = false,
                Paras = upUser.Paras,
            });
            if (urList.Count>0)
            {
                //删除数据表已存在，但目前不需要的角色关系
                string strWhereDel = $" RoleId not in ({string.Join(",", urList.Select(ur => ur.RoleId))}) and UserId = {userInfo.UserId} ";
                string sqlDelUR = CreateSql.CreateDeleteSql<UserRoleInfoModel>(strWhereDel);
                cmdList.Add(new CommandInfo()
                {
                    CommandText = sqlDelUR,
                    IsProc = false,

                }); 
            }

            if (urListNew.Count>0)
            {
                //新增的对应关系
                string colsUserRole = "URId,UserId,RoleId,Creator";
                foreach (var urNew in urListNew)
                {
                    SqlModel inUserRole = CreateSql.CreateInsertSql<UserRoleInfoModel>(urNew, colsUserRole, 0);
                    cmdList.Add(new CommandInfo()
                    {
                        CommandText = inUserRole.Sql,
                        IsProc = false,
                        Paras = inUserRole.Paras,
                    });
                }

            }
            return SqlHelper.ExecuteTrans(cmdList);
        }
    }
}
