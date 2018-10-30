using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASample.Permission.Service.ViewModels
{
    public class AdminView
    {
        public Guid Id { get; set; }

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