using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using JuSha.Framework.Entities;
using JuSha.Framework.Common;
using JuSha.Framework.Common.Helper;

namespace JuSha.Framework.Web.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            this.InitPath(requestContext);
        }

        private void InitPath(RequestContext requestContext)
        {
            this.Url = requestContext.HttpContext.Request.Url.ToString();
            this.ReferrerUrl = (requestContext.HttpContext.Request.UrlReferrer != null) ? requestContext.HttpContext.Request.UrlReferrer.ToString() : string.Empty;
            this.ServerPath = requestContext.HttpContext.Request.AppRelativeCurrentExecutionFilePath;
            this.Path = requestContext.HttpContext.Request.FilePath;
            this.PhysicPath = requestContext.HttpContext.Request.PhysicalPath;
            this.DomainPath = requestContext.HttpContext.Request.PhysicalApplicationPath;
            this.FileDirectory = this.PhysicPath;
            //this.FileDirectory = FileManager.GetFileDirectory(this.PhysicPath);
            this.IP = base.Request.UserHostAddress;
            this.HostName = base.Request.UserHostName;
            //string str = string.Empty;
            //string requiredString = string.Empty;
            //string str3 = string.Empty;
            //if (requestContext.RouteData.Values.Count > 0)
            //{
            //    if (requestContext.RouteData.Values.ContainsKey("area"))
            //    {
            //        str = requestContext.RouteData.Values["area"].ToString();
            //    }
            //    if (string.IsNullOrEmpty(str))
            //    {
            //        str = requestContext.RouteData.DataTokens["area"].ToString();
            //    }
            //    requiredString = requestContext.RouteData.GetRequiredString("controller");
            //    str3 = requestContext.RouteData.Values["action"].ToString();
            //}
            //else
            //{
            //    requiredString = "Home";
            //    str3 = "Index";
            //}
            //str = (("root" == str.ToLower()) || string.IsNullOrEmpty(str)) ? string.Empty : ("/" + str);
            //this.RequestPath = string.Concat((string[])new string[] { str, "/", requiredString, "/", str3 });
        }

        /// <summary>
        /// 登录用户
        /// </summary>
        public Users LoginUser
        {
            get
            {
                if (Session[CacheKey.LoginUser] == null)
                {
                    Users entityUser = null;
                    string userName = Common.Helper.CookieHelper.GetcookieValue(Common.CacheKey.CookieUserName);
                    string userEncrypt = Common.Helper.CookieHelper.GetcookieValue(Common.CacheKey.CookieUserEncrypt);
                    if (!userName.IsEmpty() && !userEncrypt.IsEmpty())
                    {
                        BLL.User bllUser = new BLL.User();
                        entityUser = bllUser.CookieLogin(userName, this.IP, userEncrypt);
                        if (entityUser != null)
                            Session[CacheKey.LoginUser] = entityUser;
                    }
                }
                if (Session[CacheKey.LoginUser] != null)
                    return (Session[CacheKey.LoginUser] as Users);
                else
                    return null;
            }
            set
            {
                Session[CacheKey.LoginUser] = value;
            }
        }
        /// <summary>
        /// 登录用户名
        /// </summary>
        public string LoginUserName
        {
            get
            {
                if (this.LoginUser != null)
                {
                    return this.LoginUser.UserName;
                }
                return string.Empty;
            }
        }
        /// <summary>
        /// 登录用户Id
        /// </summary>
        public int? LoginUserId
        {
            get
            {
                if (this.LoginUser != null)
                {
                    return this.LoginUser.ID;
                }
                return null;
            }
        }
        /// <summary>
        /// 判断用户是否登录 登录返回true 未登录返回false
        /// </summary>
        /// <returns></returns>
        public bool IsLogin()
        {
            return this.LoginUser != null;
        }
        /// <summary>
        /// 用户添加Cookie免登陆信息
        /// </summary>
        /// <returns></returns>
        public bool UserAddCookie(Entities.Users entityUser)
        {
            if (entityUser != null && UserAddSession(entityUser))
            {
                BLL.User bllUser = new BLL.User();
                Common.Helper.CookieHelper.SetCookie(Common.CacheKey.CookieUserName, entityUser.UserName,new TimeSpan(7,0,0,0));
                Common.Helper.CookieHelper.SetCookie(Common.CacheKey.CookieUserEncrypt, bllUser.UserCookieEncrypt(entityUser.UserName, entityUser.Password, this.IP),new TimeSpan(7,0,0,0));
                return true;
            }
            else
                return false;
        }
        public bool UserAddSession(Entities.Users entityUser)
        {
            if (entityUser != null)
            {
                Session[CacheKey.LoginUser] = entityUser;
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// 设置用户信息
        /// </summary>
        private void SetUserInfo()
        {
            if (IsLogin())
            {
                ViewBag.LoginUser = this.LoginUser;
                ViewBag.LoginUserName = this.LoginUserName;
                ViewBag.LoginUserId = this.LoginUserId;
            }
        }
        /// <summary>
        /// 退出系统
        /// </summary>
        protected void LoginOut()
        {
            Session.Remove(CacheKey.LoginUser);
        }
        /// <summary>
        /// 获得当前程序运行的物理路径
        /// </summary>
        public string DomainPath { get; set; }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string FileDirectory { get; set; }
        /// <summary>
        /// 主机名
        /// </summary>
        public string HostName { get; set; }
        /// <summary>
        /// 访客IP
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// FilePath
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 获得当前页面的完整物理路径
        /// </summary>
        public string PhysicPath { get; set; }
        /// <summary>
        /// 前一页Url
        /// </summary>
        public string ReferrerUrl { get; set; }
        /// <summary>
        /// 请求路径
        /// </summary>
        public string RequestPath { get; set; }
        /// <summary>
        /// 主机路径
        /// </summary>
        public string ServerPath { get; set; }
        /// <summary>
        /// 当前请求Url
        /// </summary>
        public new string Url { get; set; }
    }
}