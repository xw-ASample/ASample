using ASample.Permission.Service.Models;
using ASample.Permission.Service.Repositorys;
using ASample.Permission.Service.Services;
using ASample.Permission.Service.ViewModels;
using ASmaple.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ASample.Permission.Service.Api
{
    [RoutePrefix("api/AdminRole")]
    public class AdminRoleController : ApiController
    {
        public AdminRoleService AdminRoleService { get; set; }
        public AdminRoleController()
        {
            AdminRoleService = new AdminRoleService();
        }
        
        [HttpGet]
        public async Task<List<AdminRole>> SelectRoleByAdminId(Guid adminId)
        {
            var result = await AdminRoleService.SelectAsync(c=>c.AdminId == adminId);
            return result;
        }

        [HttpPost]
        public async Task Add(AdminRoleView param)
        {
            var list = new List<AdminRole>();
            if(param == null || param.RoleIds == null )
            {
                throw new Exception("参数为空");
            }
            foreach (var roleId in param.RoleIds)
            {
                var model = new AdminRole
                {
                    AdminId = param.AdminId,
                    RoleId = roleId
                };
            }
            await AdminRoleService.AddListAsync(list);
        }
    }
}
