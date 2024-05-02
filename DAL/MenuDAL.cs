using DAL.Base;
using Models.DModels;
using System;
using System.Collections.Generic;
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
    }
}
