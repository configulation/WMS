using Models.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinWMS;

namespace WinFModels
{
    /// <summary>
    /// 用于登录页面向主页面传递参数的实体
    /// </summary>
    public class LoginModel
    {
        public List<ViewUserRoleModel> URList { get; set; }
        public FrmLogin LoginForm { get; set; }
    }
}
