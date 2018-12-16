using ASample.Permission.Service.Api.Base;
using ASample.Permission.Service.Models;
using ASample.Permission.Service.Repositorys;
using ASample.Permission.Service.Services;
using ASample.Permission.Service.ViewModels;
using ASample.Utility.Hash;
using ASmaple.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace ASample.Permission.Service.Api
{
    [RoutePrefix("api/Admin")]
    public class AdminController : BaseApiController
    {
        public AdminService AdminService { get; set; }

        public AdminController()
        {
            AdminService = new AdminService();
        }
        
        [HttpGet]
        public async Task<PagedData<Admin>> SelectPaged()
        {
            var pageIndex = 1;
            var pageSize = 10;
            var searchParam = "123";
            var result = await AdminService.SelectPagedAsync(pageIndex,pageSize,c => c.Name.Contains(searchParam),c => c.CreateTime,true);
            return result;
        }

        [HttpPost]
        public async Task Add(AdminView param)
        {
            var user = new IdentityUser
            {
                //IdentityUser 表中的Id 必须为Admin表中的Id
                Id = param.Id,
                CreateTime = DateTime.Now,
                UserName = param.Name
            };
           
            var result = await SignInManage.UserManager.CreateAsync(user, param.Password);
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.FirstOrDefault());
            }
            else
            {
                //var salt = Guid.NewGuid().ToString().ToLower();
                //var hashPwd = new MD5Hasher(MD5Hasher.MD5HashMode.Lower).Hash(param.Password + salt);
                var model = new Admin
                {
                    Name = param.Name,
                    Password = param.Password,
                    Email = param.Email
                };
                await AdminService.AddAsync(model);
            }
            await AdminService.CurrentRepository.Commit();
        }

        [HttpPut]
        public async Task Update(AdminView param)
        {
            var model = new Admin
            {
                Id=param.Id,
                Name = param.Name,
                Password = param.Password,
                Email = param.Email,
            };
            await AdminService.UpdateAsync(model);
        }

        [HttpDelete]
        public async Task Delete(AdminView param)
        {
            await AdminService.DeleteAsync(param.Id);
        }
    }
}
