using Common.CustAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DModels
{
    [Table("UserInfos")]
    [Serializable]
    [PrimaryKey("UserId")]
    public class UserInfoModel
    {
        /// <summary>
        /// UserId
        /// </summary>		
        public int UserId { get; set; }
        /// <summary>
        /// UserName
        /// </summary>		
        public string UserName { get; set; }
        /// <summary>
        /// UserPwd
        /// </summary>		
        public string UserPwd { get; set; }

        public int UserState { get; set; }

        public string Creator { get; set; }

        public DateTime CreateTime { get; set; }

        public int IsDeleted { get; set; }
    }
}
