using ASmaple.Domain.Models;
using System;
namespace ASample.BookShop.Model.AggregateRoots
{
    /// <summary>
    /// 会员
    /// </summary>
    public class User : AggregateRoot
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string LoginPassword { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 用户地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 用户手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 用户等级编号
        /// </summary>
        public Guid UserLevelId { get; set; }
    }
}
