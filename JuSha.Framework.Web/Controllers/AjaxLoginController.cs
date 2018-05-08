using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JuSha.Framework.Web.Controllers
{
    public class AjaxLoginController : AjaxBaseController
    {
        // GET: AjaxLogin
        [HttpPost]
        public ActionResult AdminLogin(string username, string password, string verificationCode,bool rememberMe=false)
        {
            if (!Common.Helper.VerifyCodeHelper.CheckVerifyCode(verificationCode))
            {
                return Content(Common.Helper.AjaxResult.Result(Common.Helper.AjaxResultType.error, "验证码错误").ToString());
            }
            BLL.User bllUser = new BLL.User();
            Entities.Users user= bllUser.AdminLogin(username, password);     
            if (user != null)
            {
                if (rememberMe)
                    this.UserAddCookie(user);
                else
                    this.UserAddSession(user);
                bllUser.UpdateLoginCount(user.UserName);//更新登录次数
                return Content(Common.Helper.AjaxResult.Result("登录成功").ToString());
            }
            else
            {
                return Content(Common.Helper.AjaxResult.Result(Common.Helper.AjaxResultType.error, "用户名或密码不存在").ToString());
            }          
        }
    }
}