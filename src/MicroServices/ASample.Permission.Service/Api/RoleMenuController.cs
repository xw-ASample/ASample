using ASample.Permission.Service.Models;
using ASample.Permission.Service.Services;
using ASample.Permission.Service.ViewModels;
using ASmaple.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ASample.Permission.Service.Api
{
    public class RoleMenuController : ApiController
    {
        public RoleService RoleService { get; set; }
        public RoleMenuController()
        {
            RoleService = new RoleService();
        }

        [HttpGet]
        public async Task<PagedData<Role>> SelectPaged()
        {
            var pageIndex = 1;
            var pageSize = 10;
            var searchParam = "123";
            var result = await RoleService.SelectPagedAsync(pageIndex, pageSize, c => c.Title.Contains(searchParam), c => c.CreateTime, true);
            return result;
        }

        [HttpPost]
        public async Task Add(RoleView param)
        {
            var model = new Role
            {
                Title = param.Title,
                Description = param.Description,
            };
            await RoleService.AddAsync(model);
        }

        [HttpPut]
        public async Task Update(RoleView param)
        {
            var model = new Role
            {
                Id = param.Id,
                Title = param.Title,
                Description = param.Description,
            };
            await RoleService.UpdateAsync(model);
        }

        [HttpDelete]
        public async Task Delete(RoleView param)
        {
            await RoleService.DeleteAsync(param.Id);
        }
    }
}
