using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JuSha.Framework.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            BLL.User user = new BLL.User();
            user.AdminLogin("admin1", "admin","");
            user.UpdateLoginCount("jusha");
            return View();
        }
    }
}