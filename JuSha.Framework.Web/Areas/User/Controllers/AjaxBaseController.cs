using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JuSha.Framework.Web.Areas.User.Controllers
{
    public class AjaxBaseController : Controller
    {
        // GET: User/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}