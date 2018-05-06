using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace JuSha.Framework.Common.Helper
{
    public class CacheHelper
    {
        /// <summary>
        /// 读取缓存数据
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <returns></returns>
        public static object GetCache(string cacheKey)
        {
            var objCache = HttpRuntime.Cache.Get(cacheKey);
            return objCache;
        }

        /// <summary>
        /// 设置缓存数据
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <param name="content">值</param>
        public static void SetCache(string cacheKey, object content)
        {
            var objCache = HttpRuntime.Cache;
            objCache.Insert(cacheKey, content);
        }

        /// <summary>
        /// 设置缓存数据并且设置默认过期时间
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <param name="content">值</param>
        /// <param name="timeOut">过期时间,单位：秒,默认3600s</param>
        /// <param name="deadlineType">缓存过期方式</param>
        public static void SetCache(string cacheKey, object content, int timeOut = 3600, DeadlineType deadlineType=DeadlineType.TimeSpan)
        {
            try
            {
                if (content == null)
                {
                    return;
                }
                var objCache = HttpRuntime.Cache;
                if (deadlineType == DeadlineType.DateTime)
                {
                    //绝对时间过期，TimeSpan.Zero表示不使用平滑过期策略。
                    objCache.Insert(cacheKey, content, null, System.DateTime.Now.AddSeconds(timeOut), TimeSpan.Zero);
                }
                else if (deadlineType == DeadlineType.TimeSpan)
                {
                    //相对过期，DateTime.MaxValue表示不使用绝对时间过期策略，TimeSpan.FromSeconds(10)表示缓存连续10秒没有访问就过期。
                    objCache.Insert(cacheKey, content, null, DateTime.MaxValue, TimeSpan.FromSeconds(timeOut));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 移除指定缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        public static void RemoveCache(string cacheKey)
        {
            var objCache = HttpRuntime.Cache;
            objCache.Remove(cacheKey);
        }

        /// <summary>
        /// 删除全部缓存
        /// </summary>
        public static void RemoveAllCache()
        {
            var objCache = HttpRuntime.Cache;
            var cacheEnum = objCache.GetEnumerator();
            while (cacheEnum.MoveNext())
            {
                objCache.Remove(cacheEnum.Key.ToString());
            }
        }

    }

    public enum DeadlineType
    { 
        /// <summary>
        /// 绝对时间，从设定时间开始计时
        /// </summary>
        DateTime,
        /// <summary>
        /// 相对时间，从最后一次调用开始计时
        /// </summary>
        TimeSpan
    }
}
