using ASample.Permission.Service.Infrastructure;
using ASample.Permission.Service.Models;
using ASample.Permission.Service.Services;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ASample.Permission.Service.Api.Base
{
    [Authorize]
    public class BaseApiController : ApiController
    {
        public AdminService AdminService { get; set; }
        public ASamplePermissionUserManager UserManager { get; set; }
        public ASamplePermissionSignInManage SignInManage { get; set; }
        public ASamplePermissionUserStore UserStore { get; set; }
        public IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.Current.GetOwinContext().Authentication; }
        }
        public BaseApiController()
        {
            AdminService = new AdminService();
            UserManager = new ASamplePermissionUserManager(new ASamplePermissionUserStore());
            SignInManage = new ASamplePermissionSignInManage(UserManager);
        }
        /// <summary>
        /// 如果ModelBuilding验证错误，则抛出客户端友好异常
        /// </summary>
        protected void ThrowIfModelInvalid()
        {
            if (ModelState.IsValid)
                return;

            var firstState = ModelState.FirstOrDefault();
            if (!firstState.Key.IsNullOrWhiteSpace())
            {
                var message = AjaxMinExtensions.IfNotNull(firstState.Value.Errors.FirstOrDefault(), i => i.ErrorMessage);
                throw new Exception(message = message != null ? message : "请输入完整信息");
            }
        }

        /// <summary>
        /// 获取当前管理员
        /// </summary>
        /// <returns></returns>
        protected async Task<Admin> GetCurrentAdminAsync()
        {
            var result = await AdminService.GetByIdAsync(Guid.Parse(User.Identity.GetUserId()));
            return result;
        }

        /// <summary>
        /// 判断是不是超级用户
        /// </summary>
        /// <returns></returns>
        protected async Task<bool> IsSuperAdmin()
        {
            var superAdminAccount = ConfigurationManager.AppSettings["SuperAdmin"];
            var admin = await GetCurrentAdminAsync();
            return admin.Name == superAdminAccount;
        }
    }
}
