using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASample.Permission.Service.ViewModels
{
    public class RoleView
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string Description { get; set; }

        
    }
}