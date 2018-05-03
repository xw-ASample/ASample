using ASample.BookShop.IService;
using ASample.BookShop.Model.AggregateRoots;
using ASample.BookShop.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ASample.BookShop.WebSite.Controllers
{
    public class AccountController : Controller
    {
        IUserService UserService;
        public AccountController()
        {

        }

        public AccountController(IUserService userService)
        {
            UserService = userService;
        }
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public async Task<ActionResult> Login(LoginModel model)
        {
            var result = await UserService.SelectAsync(c => c.LoginName == model.Name && c.LoginPassword == model.Password);
            if(result.Count > 0)
            {
                //登录成功  
            }
            else
            {
                //登录失败
            }
            return View();
        }

        public async Task<bool> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
                return false;
            var user = new User
            {
                LoginName = model.Name,
                LoginPassword = model.Password,
                Phone = model.Phone
            };
            await UserService.AddAsync(user);
            return true;
        }

    }
}