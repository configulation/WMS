using DAL;
using Models.VModels;
using Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
