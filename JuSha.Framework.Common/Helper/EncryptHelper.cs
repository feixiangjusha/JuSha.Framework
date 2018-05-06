using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using JuSha.Framework.Common.Helper;

namespace JuSha.Framework.Common.Helper
{
   public class EncryptHelper
    {
       /// <summary>
       /// 32位MD5加密
       /// </summary>
       /// <param name="strToEncrypt">待加密字符串</param>
       /// <param name="salt">盐</param>
       /// <param name="encode">编码方式</param>
       /// <returns></returns>
       public static string EncryptMd5(string strToEncrypt, string salt,Encoding encode)
       {
           string pwd = string.Empty;
           MD5 md5 = MD5.Create();//实例化一个md5对像
           // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
           byte[] s = md5.ComputeHash(encode.GetBytes(strToEncrypt+"salt:"+salt));
           // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
           for (int i = 0; i < s.Length; i++)
           {
               // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
               pwd = pwd + s[i].ToString("X2");

           }
           return pwd;
       }
       /// <summary>
       /// 32位MD5加密
       /// </summary>
       /// <param name="strToEncrypt">待加密字符串</param>
       /// <param name="salt">盐</param>
       /// <returns></returns>
       public static string EncryptMd5(string strToEncrypt, string salt)
       {
           return EncryptMd5(strToEncrypt, salt, Encoding.UTF8);
       }
       /// <summary>
       /// 32位MD5加密
       /// </summary>
       /// <param name="strToEncrypt">待加密字符串</param>
       /// <param name="encode">编码方式</param>
       /// <returns></returns>
       public static string EncryptMd5(string strToEncrypt, Encoding encode)
       {
           return EncryptMd5(strToEncrypt, CacheKey.Md5DefaultSalt, encode);
       }
       /// <summary>
       /// 32位MD5加密
       /// </summary>
       /// <param name="strToEncrypt">待加密字符串</param>
       /// <returns></returns>
       public static string EncryptMd5(string strToEncrypt)
       {
           return EncryptMd5(strToEncrypt, CacheKey.Md5DefaultSalt, Encoding.UTF8);
       }
    }
}
