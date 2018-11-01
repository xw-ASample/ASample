using ASample.Permission.Service.IServices;
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
    [RoutePrefix("api/Admin")]
    public class AdminController : ApiController
    {
        public AdminService AdminService { get; set; }
        public AdminController()
        {
            AdminService = new AdminService();
        }
        

        [HttpGet]
        public async Task Add()
        {
            //var model = new Admin
            //{
            //    Name = param.Name,
            //    Password = param.Password,
            //    Email = param.Email
            //};
            var model = new Admin
            {
                Name = "1",
                Password = "2",
                Email = "3"
            };
            await AdminService.AddAsync(model);
        }
    }
}
