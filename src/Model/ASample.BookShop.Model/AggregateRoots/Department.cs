using ASmaple.Domain.Models;
using System;

namespace ASample.BookShop.Model.AggregateRoots
{
    /// <summary>
    /// 部门
    /// </summary>
    public class Department : AggregateRoot
    {
        /// <summary>
        /// 部门名称
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 部门描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 角色编号
        /// </summary>
        public Guid RoleId { get; set; }
    }
}
