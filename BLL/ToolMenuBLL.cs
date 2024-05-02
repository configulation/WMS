using DAL;
using Models.DModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ToolMenuBLL
    {
        ToolMenuDAL toolMenuDAL = new ToolMenuDAL();
        public List<ToolMenuInfoModel> GetToolMenuList(List<int> roleIds)
        {
            string Ids = string.Join(",", roleIds);

            return toolMenuDAL.GetToolMenuList(Ids);
        }
    }
}
