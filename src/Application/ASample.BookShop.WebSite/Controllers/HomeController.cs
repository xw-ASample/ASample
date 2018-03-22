using ASample.BookShop.Service.IService;
using ASample.BookShop.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ASample.BookShop.WebSite.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }
        IBookService BookService;
        public HomeController(IBookService bookService)
        {
            BookService = bookService;
        }
        public async Task<ActionResult> Index()
        {
            var result = await BookService.Select(c => true);
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