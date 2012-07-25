using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace mvcweb.Controllers
{
    public class HomeController : Controller
    {

        /// <summary>
        /// 首页景区列表
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {

            return View();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
