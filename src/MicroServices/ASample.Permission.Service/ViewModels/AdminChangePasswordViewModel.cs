using System;
using System.ComponentModel.DataAnnotations;

namespace ASample.Permission.Service.ViewModels
{
    public class AdminChangePasswordViewModel
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string CurrentPassword { get; set; }

        /// <summary>
        /// 新密码
        /// </summary>
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string NewPassword { get; set; }


        /// <summary>
        /// 重复证新密码
        /// </summary>
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string ConfirmPassword { get; set; }
    }
}