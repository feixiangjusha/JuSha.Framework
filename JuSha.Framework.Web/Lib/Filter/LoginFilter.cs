using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JuSha.Framework.Common;
using JuSha.Framework.Entities;
namespace JuSha.Framework.Web.Filter
{
    public class LoginFilter : BaseAuthorizeAttribute
    {
        private bool ValidateLogin = true;

        private bool ValidateRequest = true;

        private bool ValidateAdmin = false;
        public LoginFilter()
            : base()
        {

        }
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="_validateLogin">是否验证登录</param>
        public LoginFilter(bool _validateLogin)
            : base()
        {
            this.ValidateLogin = _validateLogin;
        }
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="_validateLogin">是否验证登录</param>
        /// <param name="_validateAdmin">是否验证管理员</param>
        public LoginFilter(bool _validateLogin, bool _validateAdmin)
            : base()
        {
            this.ValidateLogin = _validateLogin;
            this.ValidateAdmin = _validateAdmin;
        }
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="_validateLogin">是否验证登录</param>
        /// <param name="_validateAdmin">是否验证管理员</param>
        /// <param name="_validateRequest">是否验证请求</param>
        public LoginFilter(bool _validateLogin,bool _validateAdmin,bool _validateRequest)
            : base()
        {
            this.ValidateLogin = _validateLogin;
            this.ValidateAdmin = _validateAdmin;
            this.ValidateRequest = _validateRequest;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (this.ValidateLogin)
            {
                //获取用户session信息
                Entities.Users LoginUser = filterContext.HttpContext.Session[Common.CacheKey.LoginUser] as Entities.Users;
                string path = filterContext.HttpContext.Request.Path;
                if (LoginUser==null)//未登录或已退出
                {
                    string url = "/Login/"+(ValidateAdmin?"AdminLogin":"Login");
                    if (!string.IsNullOrEmpty(path))
                    {
                        path = filterContext.HttpContext.Server.UrlEncode(path);
                        url =url+ "?returnurl=" + path;
                    }
                    filterContext.Result = new RedirectResult(url);
                }
                else
                {
                    if (ValidateAdmin && LoginUser.IsAdmin == 0)//管理员身份验证
                    {
                        string url = "/Login/AdminLogin";
                        if (!string.IsNullOrEmpty(path))
                        {
                            path = filterContext.HttpContext.Server.UrlEncode(path);
                            url = url + "?returnurl=" + path;
                        }
                        filterContext.Result = new RedirectResult(url);
                    }
                    if (ValidateRequest && path != "/")
                    {
                        //PowerProvider provider = new PowerProvider();
                        //bool hasPower = provider.HasPower(path,LoginUser.RoleNum);
                        //if (!hasPower)
                        //{
                        //    string url = "/Home/Error";
                        //    filterContext.Result = new RedirectResult(url);
                        //}
                    }
                }
            }
        }
    }
}