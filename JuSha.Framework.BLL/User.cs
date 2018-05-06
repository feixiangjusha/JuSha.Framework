using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;

namespace JuSha.Framework.BLL
{
    public class User:IRequiresSessionState
    {

        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="Password">密码</param>
        /// <param name="VerificationCode">验证码</param>
        public Entities.Users AdminLogin(string userName, string password)
        {
            DataAccess.DBEntities context = new DataAccess.DBEntities();
           return context.Users.Where(m => m.UserName == userName && m.Password == password && m.IsAdmin == 1).FirstOrDefault();
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="Password">密码</param>
        /// <param name="VerificationCode">验证码</param>
        public Entities.Users Login(string userName, string password, string verificationCode)
        {
            DataAccess.DBEntities context = new DataAccess.DBEntities();
            Entities.Users user = context.Users.Where(m => m.UserName == userName && m.Password == password).FirstOrDefault();
            return user;
        }
        /// <summary>
        /// 根据cookie信息获取用户登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userEncrypt">Cookie加密信息</param>
        /// <returns></returns>
        public Entities.Users CookieLogin(string userName,string userIP, string userEncrypt)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(userEncrypt))
                return null;
            DataAccess.DBEntities context = new DataAccess.DBEntities();
            Entities.Users user = context.Users.Where(m => m.UserName == userName).FirstOrDefault();
            if (user!=null&&UserCookieEncrypt(user.UserName,user.Password, userIP).Equals(userEncrypt))
                return user;
            else
                return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public string UserCookieEncrypt(string userName,string password,string ip)
        {
            string strEncrypt = string.Empty;
                string str = userName +"|"+ password+"|"+ ip;
                strEncrypt= Common.Helper.EncryptHelper.EncryptMd5(str);
            return strEncrypt;
        }
        public int UpdateLoginCount(string userName, int addCount = 1)
        {
            DataAccess.DBEntities context = new DataAccess.DBEntities();
            Entities.Users user = context.Users.Where(m => m.UserName == userName).FirstOrDefault();
            if (user != null)
            {
                user.LoginCount += addCount;
                return context.SaveChanges();
            }
            else
                return -1;
        }
    }
}
