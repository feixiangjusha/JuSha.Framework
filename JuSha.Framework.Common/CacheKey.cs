using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuSha.Framework.Common
{
    public static class CacheKey
    {
        /// <summary>
        /// 登录用户缓存Key
        /// </summary>
        public const string LoginUser = "LoginUser";
        /// <summary>
        /// 功能类型列表缓存Key
        /// </summary>
        public const string FuncTypeList = "FuncTypeList";
        /// <summary>
        /// MD5加密默认盐值
        /// </summary>
        public const string Md5DefaultSalt = "unsalted";
        /// <summary>
        /// Cookie用户名Key
        /// </summary>
        public const string CookieUserName = "CookieUserName";
        /// <summary>
        /// Cookie加密密码信息Key
        /// </summary>
        public const string CookieUserEncrypt = "CookieUserEncrypt";
        /// <summary>
        /// Session验证码Key
        /// </summary>
        public const string VerifiyCode = "VerifiyCode";
    }
}
