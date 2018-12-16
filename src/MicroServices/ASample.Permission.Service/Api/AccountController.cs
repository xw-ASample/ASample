using ASample.Common.ApiReturnResult;
using ASample.Permission.Service.Api.Base;
using ASample.Permission.Service.Core;
using ASample.Permission.Service.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ASample.Permission.Service.Api
{
    [RoutePrefix("api/Account")]
    public class AccountController : BaseApiController
    {
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        [HttpPost, AllowAnonymous]
        [Route("Login")]
        public async Task<LoginReturnResult> Login(UserLoginModel loginModel)
        {
            var user = await UserManager.FindByNameAsync(loginModel.Username);
            if (user == null)
                return LoginReturnResult.Error( "找不到用户");
            var passwordCheckResult = await UserManager.CheckPasswordAsync(user, loginModel.Password);
            if (!passwordCheckResult)
                return LoginReturnResult.Error("密码错误");
            if (user == null)
                return LoginReturnResult.Error("用户名或者密码错误");
            //await SignInManager.SignInAsync(user, false, false);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);
            return  LoginReturnResult.Success("登陆成功，跳转中..." ,loginModel.ReturnUrl ?? "/home/index");
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<LoginReturnResult> Logout()
        {
            AuthenticationManager.SignOut();
            return LoginReturnResult.Success("注销成功，跳转中...", "/account/login");
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task ChangePassword(AdminChangePasswordViewModel model)
        {
            // ReSharper disable once PossibleInvalidOperationException
            var result = await UserManager.ChangePasswordAsync(Guid.Parse(User.Identity.GetUserId()), model.CurrentPassword, model.NewPassword);
            if (result.Errors.FirstOrDefault() == null || result.Succeeded)
            {
                AuthenticationManager.SignOut();
                throw new Redirect("修改密码成功，请重新登陆...", "/account/login", "logout_success");
            }
            else
            {
                string errorMessage;
                var error = result.Errors.FirstOrDefault();
                if (error != null && error.Contains("Incorrect password"))
                {
                    errorMessage = "原密码错误！";
                }
                else if (error != null && error.Contains("Passwords must have at least one non letter or digit character"))
                {
                    errorMessage = "修改密码失败,请确认符合密码策略";
                }
                else
                {
                    errorMessage = error;
                }
                throw new Exception(errorMessage);
            }
        }
    }
}
