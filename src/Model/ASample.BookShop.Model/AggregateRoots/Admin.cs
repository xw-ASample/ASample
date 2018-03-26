using ASmaple.Domain.Models;
using System;

namespace ASample.BookShop.Model.AggregateRoots
{
    /// <summary>
    /// 管理员
    /// </summary>
    public class Admin:AggregateRoot
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
        /// 注册时间
        /// </summary>
        public DateTime RegisterTime { get; set; }
        
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string Email { get; set; }
    }
}
