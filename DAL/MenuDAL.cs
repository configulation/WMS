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
    public class MenuDAL : BaseDAL<MenuInfoModel>
    {
        public List<MenuInfoModel> GetMenuList()
        {
            string strWhere = "";
            string cols = "MId,MName,ParentId,ParentName,MKey,MUrl,IsTop,MOrder,MDesp";

            return GetModelList(strWhere, cols, "ParentId");
        }

        public List<MenuInfoModel> GetMenuList(string Ids)
        {
            string strWhere = "";
            string cols = "MId,MName,ParentId,ParentName,MKey,MUrl,IsTop,MOrder,MDesp";
            if (!string.IsNullOrEmpty(Ids))
            {
                strWhere += $" MId in (select MId from RoleMenuInfos where RoleId in ({Ids}) )";
            }

            return GetModelList(strWhere, cols, "MOrder");
        }

        public List<MenuInfoModel> GetMenuListByKeyWords(string keyword)
        {
            string strWhere = " IsDeleted=0";
            string cols = "MId,MName,ParentId,ParentName,MKey,MUrl,IsTop,MOrder,MDesp";
            if (!string.IsNullOrEmpty(keyword))
            {
                strWhere += $"and  (MName like @keyword or ParentName like @keyword  )";
            }

            return GetModelList(strWhere, cols, "ParentId,MOrder");
        }

        /// <summary>
        /// 主要用于绑定列表或下拉框
        /// </summary>
        /// <returns></returns>
        public List<MenuInfoModel> GetAllMenus()
        {
            string strWhere = " isDeleted=0 ";
            string cols = "MId,MName,ParentId,ParentName,MKey,MUrl,IsTop,MOrder,MDesp";

            return GetModelList(strWhere, cols, "ParentId");
        }

        public MenuInfoModel GetMenuInfoById(int menuId)
        {
            string cols = "MId,MName,ParentId,ParentName,MKey,MUrl,IsTop,MOrder,MDesp";

            return GetById(menuId,cols);
        }

        public bool ExistMName(string MName)
        {
           return ExistsByName("MName", MName);
        }

        public bool AddMenuInfo(MenuInfoModel model)
        {
            string cols = "MId,MName,ParentId,ParentName,MKey,MUrl,IsTop,MOrder,MDesp,Creator";
            return Add(model, cols, 0) > 0;
        }

        public bool UpdateMenuInfo(MenuInfoModel menuInfo, bool blUpdateParentName)
        {
            List<CommandInfo> comList = new List<CommandInfo>();
            string cols = "MId,MName,ParentId,ParentName,MKey,MUrl,IsTop,MOrder,MDesp";
            SqlModel upModel = CreateSql.CreateUpdateSql<MenuInfoModel>(menuInfo, cols,"");
            comList.Add(new CommandInfo()
            {
                CommandText = upModel.Sql,
                IsProc = false,
                Paras = upModel.Paras,
            });
            if (blUpdateParentName)
            {
                string sqlUpdateParentName = "update MenuInfos set ParentName=@parentName where ParentId=@menuId";
                SqlParameter[] paras =
                {
                    new SqlParameter("@parentName",menuInfo.MName),
                    new SqlParameter("@menuId",menuInfo.MId)
                };
                comList.Add(new CommandInfo()
                {
                    CommandText = sqlUpdateParentName,
                    IsProc = false,
                    Paras = paras
                });
            }
            return SqlHelper.ExecuteTrans(comList);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Ids"></param>
        /// <param name="delType">0 update 1 delete</param>
        /// <returns></returns>
        public bool DeleteMenuInfo(List<int> Ids, int delType)
        {
            ////获取要删除的菜单编号集合
            //List<int> menuIds = new List<int>();
            //foreach (int id in Ids)
            //{
            //    menuIds = GetAllSon(menuIds, id);
            //}

            //string strWhere = $" MId in ({string.Join(",",menuIds)})";

            //return Delete(0, "", 1);

            //获取要删除的菜单编号集合
            List<string> sqlList = new List<string>();
            List<int> menuIds = new List<int>();
            foreach (int id in Ids)
            {
                if (!menuIds.Contains(id))
                    menuIds.Add(id);
                menuIds = GetAllSon(menuIds, id);
            }
            string strWhere = $" MId in ({string.Join(",", menuIds)})";
            string delMenu = "";
            string delRoleMenu = "";
            if (delType==1)
            {
                delMenu = $"delete from [MenuInfos] where {strWhere}";
                delRoleMenu = $"delete from [RoleMenuInfos] where {strWhere}";
            }
            else if(delType == 0)
            {
                delMenu = $"update [MenuInfos] set IsDeleted=1 where {strWhere}";
                delRoleMenu = $"delete from [RoleMenuInfos] set IsDeleted=1 where {strWhere}";
            }
            sqlList.Add(delMenu); 
            sqlList.Add(delRoleMenu);

            return SqlHelper.ExecuteTrans(sqlList);
        }

        public List<int> GetAllSon(List<int> menuIds, int id)
        {
            string strWhere = $" ParentId in ({id}) and IsDeleted=0";
            List<MenuInfoModel> mList = GetModelList(strWhere,"MId","");

            foreach (var m in mList)
            {
                if (!menuIds.Contains(m.MId))
                {
                    menuIds.Add(m.MId);
                    GetAllSon(menuIds,m.MId);
                }
            }

            return menuIds;
        }

        /// <summary>
        /// 获取所有菜单列表（绑定TreeView）
        /// </summary>
        /// <returns></returns>
        public List<MenuInfoModel> GetTvMenus()
        {
            return GetModelList("","MId,MName,ParentId","");
        }
    }
}
