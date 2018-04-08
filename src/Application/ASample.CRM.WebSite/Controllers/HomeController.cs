using ASample.Crm.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ASample.CRM.WebSite.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }
        private IUserService UserService { get; set; }
        public HomeController(IUserService userService)
        {
            UserService = userService;
        }
        public async Task<ActionResult> Index()
        {
            var result =await UserService.Select(c => true);
            return View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}