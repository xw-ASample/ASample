using ASmaple.Domain.Models;
using System;


namespace ASample.ByhShop.Model.AggregateRoots
{
    public class User:AggregateRoot
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 邮件
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDisabled { get; set; }


        public DateTime? LastLogonDate { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        public string Contact { get; set; }

        //用户的联系地址
        public Guid AddressId { get; set; }
    }
}
