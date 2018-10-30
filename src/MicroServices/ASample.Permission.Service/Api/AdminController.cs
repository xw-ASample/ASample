using ASample.Permission.Service.Models;
using ASample.Permission.Service.Services;
using ASample.Permission.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ASample.Permission.Service.Api
{
    public class AdminController : ApiController
    {
        public AdminController()
        {

        }
        AdminService AdminService;
        public AdminController(AdminService adminService)
        {
            AdminService = adminService;
        }
        public async Task Add(AdminView param)
        {
            var model = new Admin
            {
                Name = param.Name,
                Password = param.Password,
                Email = param.Email
            };
            await AdminService.AddAsync(model);
        }
    }
}
