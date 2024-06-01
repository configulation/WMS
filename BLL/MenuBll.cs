using DAL;
using Models.VModels;
using Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Base;
using Helper;
using System.Data.SqlClient;

namespace BLL
{
    public class MenuBLL
    {
        MenuDAL menuDAL = new MenuDAL();
        public List<MenuInfoModel> GetMenuList(List<int> roleIds)
        {
            string Ids = string.Join(",", roleIds);
            return menuDAL.GetMenuList(Ids);
        }

        public List<MenuInfoModel> GetMenuListByKeyWords(string keyword)
        {
            return menuDAL.GetMenuListByKeyWords(keyword);
        }

        public List<MenuInfoModel> GetAllMenus()
        {
            return menuDAL.GetAllMenus();
        }

        public MenuInfoModel GetMenuInfoById(int menuId)
        {
            return menuDAL.GetMenuInfoById(menuId);
        }

        public bool ExistMName(string MName)
        {
            return menuDAL.ExistMName(MName);
        }

        public bool AddMenuInfo(MenuInfoModel menuInfo)
        {
           return menuDAL.AddMenuInfo(menuInfo);
        }

        public bool UpdateMenuInfo(MenuInfoModel menuInfo, bool blUpdateParentName)
        {

            return menuDAL.UpdateMenuInfo(menuInfo, blUpdateParentName);
        }

        public bool DeleteMenuInfo(List<int> Ids, int delType)
        {
            return menuDAL.DeleteMenuInfo(Ids, delType);
        }

        /// <summary>
        /// 获取所有菜单列表（绑定TreeView）
        /// </summary>
        /// <returns></returns>
        public List<MenuInfoModel> GetTvMenus()
        {
            return menuDAL.GetTvMenus();
        }
    }
}
