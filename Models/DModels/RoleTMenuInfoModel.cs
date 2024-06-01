using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Common.CustAttributes;

namespace Models.DModels
{
    /// <summary>
    /// 角色工具菜单关系信息实体
    /// </summary>
    [Serializable]
    [Table("RoleTMenuInfos")]
    [PrimaryKey("RTMenuId",autoIncrement =true)]
    public class RoleTMenuInfoModel
    {
        /// <summary>
        /// RTMenuId
        /// </summary>		
        public int RTMenuId { get; set; }
        /// <summary>
        /// RoleId
        /// </summary>		
        public int RoleId { get; set; }
        /// <summary>
        /// TMenuId
        /// </summary>		
        public int TMenuId { get; set; }
        /// <summary>
        /// Creator
        /// </summary>		
        public string Creator { get; set; }
        /// <summary>
        /// CreateTime
        /// </summary>		
        public DateTime CreateTime { get; set; }
    }
}
