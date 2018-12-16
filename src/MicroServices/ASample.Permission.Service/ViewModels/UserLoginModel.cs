using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASample.Permission.Service.ViewModels
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "用户名不能为空！")]
        public string Username { get; set; }

        [Required(ErrorMessage = "密码不能为空！")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}