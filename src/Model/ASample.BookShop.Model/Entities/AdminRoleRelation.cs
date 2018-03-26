using ASmaple.Domain.Models;
using System;

namespace ASample.BookShop.Model.Entities
{
    /// <summary>
    /// 管理员 角色关联表
    /// </summary>
    public class AdminRoleRelation : Entity
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
