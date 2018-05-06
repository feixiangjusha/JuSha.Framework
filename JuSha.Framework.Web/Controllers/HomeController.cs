using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JuSha.Framework.Web.Controllers
{
    public class HomeController : BasePageController
    {
        public ActionResult Index()
        {
            Entities.Users user= this.LoginUser;
            return View();
        }
    }
}