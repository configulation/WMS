﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Common.CustAttributes;

namespace Models.DModels
{
    /// <summary>
    /// 角色信息实体
    /// </summary>
    [Serializable]
    [Table("RoleInfos")]
    [PrimaryKey("RoleId",autoIncrement =true)]
    public class RoleInfoModel
    {
        /// <summary>
        /// RegionId
        /// </summary>		
        
        public int RoleId { get; set; }
        /// <summary>
        /// RegionName
        /// </summary>		
        public string RoleName { get; set; }
        /// <summary>
        /// Remark
        /// </summary>		
        public string Remark { get; set; }
        /// <summary>
        /// IsAdmin
        /// </summary>		
        public int IsAdmin { get; set; }
        /// <summary>
        /// IsDeleted
        /// </summary>		
        public int IsDeleted { get; set; }
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
