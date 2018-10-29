using ASmaple.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASample.Permission.Service.Models
{
    /// <summary>
    /// 角色
    /// </summary>
    public class Role : AggregateRoot
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 角色描述
        /// </summary>
        public string Description { get; set; }
    }
}