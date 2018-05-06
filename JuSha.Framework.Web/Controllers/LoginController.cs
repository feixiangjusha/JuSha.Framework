using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JuSha.Framework.Web.Controllers
{
    public class LoginController : BaseController
    {
        //
        // GET: /Login/
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        public ActionResult GetAuthCode()
        {
            return File(Common.Helper.VerifyCodeHelper.GetVerifyCodeImg(), @"image/Gif");
        }
	}
}