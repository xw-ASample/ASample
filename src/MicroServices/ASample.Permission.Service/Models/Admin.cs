using ASmaple.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASample.Permission.Service.Models
{
    /// <summary>
    /// 管理员
    /// </summary>
    public class Admin : AggregateRoot
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string Email { get; set; }
    }
}