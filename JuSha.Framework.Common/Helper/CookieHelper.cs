using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace JuSha.Framework.Common.Helper
{
    public class CookieHelper
    {
        /// <summary>
        /// 清除指定Cookie
        /// </summary>
        /// <param name="cookieName">cookieName</param>
        public static void ClearCookie(string cookieName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddYears(-3);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
        /// <summary>
        /// 获取指定Cookie值
        /// </summary>
        /// <param name="cookieName">cookieName</param>
        /// <returns></returns>
        public static string GetcookieValue(string cookieName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            string str = string.Empty;
            if (cookie != null)
            {
                str = cookie.Value;
            }
            return str;
        }
        /// <summary>
        /// 添加一个Cookie（24小时过期）
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="cookieValue"></param>
        public static void SetCookie(string cookieName, string cookieValue)
        {
            SetCookie(cookieName, cookieValue, DateTime.Now.AddDays(1.0));
        }
        /// <summary>
        /// 添加一个Cookie
        /// </summary>
        /// <param name="cookieName">cookie名</param>
        /// <param name="cookieValue">cookie值</param>
        /// <param name="expires">过期时间 DateTime</param>
        public static void SetCookie(string cookieName, string cookieValue, DateTime expires)
        {
            HttpCookie cookie = new HttpCookie(cookieName)
            {
                Value = cookieValue,
                Expires = expires
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        /// <summary>
        /// 添加一个Cookie
        /// </summary>
        /// <param name="cookieName">cookie名</param>
        /// <param name="cookieValue">cookie值</param>
        /// <param name="expires">过期时长</param>
        public static void SetCookie(string cookieName, string cookieValue, TimeSpan timespan)
        {
            HttpCookie cookie = new HttpCookie(cookieName)
            {
                Value = cookieValue,
                Expires = DateTime.Now.Add(timespan)
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}
