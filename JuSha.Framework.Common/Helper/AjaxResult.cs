using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace JuSha.Framework.Common.Helper
{

    /// <summary>
    /// 前台Ajax请求的统一返回结果类
    /// </summary>
    public class AjaxResult
    {
        private AjaxResult()
        {
        }

        private AjaxResultType _state = AjaxResultType.success;

        /// <summary>
        /// Ajax请求结果
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public AjaxResultType State
        {
            get { return _state; }
            set { _state = value; }
        }

        /// <summary>
        /// 成功或者错误附加信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 需要返回的数据
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// Ajax请求结果
        /// </summary>
        /// <param name="state">请求状态</param>
        /// <param name="message">附加信息</param>
        /// <param name="data">需要返回的数据</param>
        /// <returns></returns>
        public static AjaxResult Result(AjaxResultType state, string message, object data)
        {
            AjaxResult result = new AjaxResult();
            result.State = state;
            result.Message = message;
            result.Data = data;
            return result;
        }
        /// <summary>
        /// Ajax请求结果
        /// </summary>
        /// <param name="state">请求状态</param>
        /// <param name="message">附加信息</param>
        /// <returns></returns>
        public static AjaxResult Result(AjaxResultType state, string message)
        {
            return Result(state, message, null);
        }
        /// <summary>
        /// Ajax请求结果
        /// </summary>
        /// <param name="state">请求状态</param>
        /// <param name="data">需要返回的数据</param>
        /// <returns></returns>
        public static AjaxResult Result(AjaxResultType state, object data)
        {
            return Result(AjaxResultType.success, string.Empty, data);
        }
        /// <summary>
        /// Ajax请求结果，默认状态为success
        /// </summary>
        /// <param name="message">附加信息</param>
        /// <param name="data">需要返回的数据</param>
        /// <returns></returns>
        public static AjaxResult Result(string message, object data)
        {
            return Result(AjaxResultType.success, message, data);
        }
        /// <summary>
        /// Ajax请求结果，默认状态为success
        /// </summary>
        /// <param name="message">附加信息</param>
        /// <returns></returns>
        public static AjaxResult Result(string message)
        {
            return Result(AjaxResultType.success, message, null);
        }
        /// <summary>
        /// Ajax请求结果，默认状态为success
        /// </summary>
        /// <param name="data">需要返回的数据</param>
        /// <returns></returns>
        public static AjaxResult Result(object data)
        {
            return Result(AjaxResultType.success, string.Empty, data);
        }
        /// <summary>
        /// Ajax请求结果，默认状态为success
        /// </summary>
        /// <returns></returns>
        public static AjaxResult Result()
        {
            return Result(AjaxResultType.success, string.Empty, null);
        }
      
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
            //return new JavaScriptSerializer().Serialize(this);
        }
    }
    public enum AjaxResultType
    {
        /// <summary>
        /// 成功结果类型
        /// </summary>
        success,
        /// <summary>
        /// 消息结果类型
        /// </summary>
        info,
        /// <summary>
        /// 警告结果类型
        /// </summary>
        warning,
        /// <summary>
        /// 异常结果类型
        /// </summary>
        error
    }
}