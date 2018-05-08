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
            try
            {
                var i = 1 / int.Parse("0");
            }
            catch (Exception ex)
            {
                Common.Helper.LogHelper.WriteError("WriteError", ex);
                Common.Helper.LogHelper.WriteInfo("WriteInfo", ex);
                Common.Helper.LogHelper.WriteDebug("WriteDebug", ex);
            }
            return View();
        }
        public ActionResult GetAuthCode()
        {
            return File(Common.Helper.VerifyCodeHelper.GetVerifyCodeImg(), @"image/Gif");
        }
    }
}