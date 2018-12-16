using ASmaple.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASample.Permission.Service.Models
{
    /// <summary>
    /// 管理员 角色关联表
    /// </summary>
    public class AdminRole : Entity
    {
        /// <summary>
        /// 管理员编号
        /// </summary>
        public Guid AdminId { get; set; }

        /// <summary>
        /// 角色编号
        /// </summary>
        public Guid RoleId { get; set; }

    }
}