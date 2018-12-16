using ASample.Permission.Service.Models.Value;
using ASmaple.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASample.Permission.Service.Models
{
    public class IdentityPassword : AggregateRoot
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        ///hash后的密码
        /// </summary>
        public string PasswordHash { get; set; }

        public string Salt { get; set; }

        public string HashMethod { get; set; }

        public PasswordStatus Status { get; set; }
    }
}