using DAL.Base;
using Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RoleMenuDAL:BaseDAL<RoleMenuInfoModel>
    {
        /// <summary>
        /// 获取指定角色的菜单编号集合
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<RoleMenuInfoModel> GetRoleMenuList(int roleId)
        {
            string strWhere = $" roleId = {roleId} and IsDeleted=0";
            string cols = "MId";
            //这里将排序字段置空
            return GetModelList(strWhere, cols, "");
        }
    }
}
