﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JuSha.Framework.Web.Filter
{
    public class BaseAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 获得请求对象
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected HttpRequestBase GetHttpRequest(AuthorizationContext context)
        {
            return context.HttpContext==null ? null : context.HttpContext.Request;
        }

        /// <summary>
        /// 获得响应对象
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected HttpResponseBase GetHttpResponse(AuthorizationContext context)
        {
            return context.HttpContext==null ? null : context.HttpContext.Response;
        }

        /// <summary>
        /// 获得请求的路径
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected string GetPath(AuthorizationContext context)
        {
            if (context!=null && GetHttpRequest(context)!=null)
            {
                return GetHttpRequest(context).Url.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// 获得请求Route
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected string GetRequestPath(AuthorizationContext context)
        {
            if (context!=null)
            {
                string area = string.Empty;
                string controllerName = string.Empty;
                string action = string.Empty;
                if (context.RouteData.Values.Count > 0)
                {
                    area = context.RouteData.DataTokens["area"] != null ? context.RouteData.DataTokens["area"].ToString() : string.Empty;
                    controllerName = context.RouteData.GetRequiredString("controller");
                    action = context.RouteData.Values["action"].ToString();
                }
                else
                {
                    controllerName = "Home";
                    action = "Login";
                }
                area = "root" == area.ToLower() || string.IsNullOrEmpty(area) ? string.Empty : "/" + area;
                return area + "/" + controllerName + "/" + action;
            }
            return string.Empty;
        }

        /// <summary>
        /// 获得Route对应Value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected string GetRouteValue(string key, AuthorizationContext context)
        {
            if (context!=null && context.RouteData.DataTokens != null)
            {
                return context.RouteData.DataTokens[key].ToString();
            }
            return string.Empty;
        }
    }
}