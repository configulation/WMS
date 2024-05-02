using DAL.Base;
using Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ToolMenuDAL:BaseDAL<ToolMenuInfoModel>
    {
        public List<ToolMenuInfoModel> GetToolMenuList(string Ids)
        {
            string strWhere = "IsDeleted=0";
            string cols = "TMenuId,TMenuName,TMPic,TMOrder,TGroupId,TMUrl,IsTop,TMDesp";
            if (!string.IsNullOrEmpty(Ids))
            {
                strWhere += $" and TMenuId in ( select TMenuId from [RoleTMenuInfos] where RoleId in ({Ids}) )";
            }
            strWhere += " order by TGroupId";
            //这里将排序字段置空
            return GetModelList(strWhere, cols, null);
        }
    }
}
