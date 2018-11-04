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
    public class MenuController : ApiController
    {
        public MenuService MenuService { get; set; }
        public MenuController()
        {
            MenuService = new MenuService();
        }

        [HttpGet]
        public async Task<PagedData<Menu>> SelectPaged()
        {
            var pageIndex = 1;
            var pageSize = 10;
            var searchParam = "123";
            var result = await MenuService.SelectPagedAsync(pageIndex, pageSize, c => c.Name.Contains(searchParam), c => c.CreateTime, true);
            return result;
        }

        [HttpPost]
        public async Task Add(MenuView param)
        {
            var model = new Menu
            {
                Code = param.Code,
                ParentCode = param.ParentCode,
                Name = param.Name,
                Url = param.Url
            };
            await MenuService.AddAsync(model);
        }

        [HttpPut]
        public async Task Update(MenuView param)
        {
            var model = new Menu
            {
                Id = param.Id,
                Code = param.Code,
                ParentCode = param.ParentCode,
                Name = param.Name,
                Url = param.Url
            };
            await MenuService.UpdateAsync(model);
        }

        [HttpDelete]
        public async Task Delete(RoleView param)
        {
            await MenuService.DeleteAsync(param.Id);
        }
    }
}
