using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASample.Identity.Service.Models.User
{
    public class LoginModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        /// 
        [Required]

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]

        [DataType(DataType.Password)]

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long", MinimumLength = 6)]
        public string UserPwd { get; set; }

    }
}