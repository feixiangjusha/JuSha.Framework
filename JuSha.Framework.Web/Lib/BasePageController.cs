using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JuSha.Framework.Web.Lib
{
    public class BasePageController : Controller
    {
        // GET: BasePage
        public ActionResult Index()
        {
            return View();
        }
    }
}