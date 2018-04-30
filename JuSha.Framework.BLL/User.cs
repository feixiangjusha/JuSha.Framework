using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuSha.Framework.BLL
{
    public class User
    {
       

        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="Password">密码</param>
        /// <param name="VerificationCode">验证码</param>
        public Entities.Users AdminLogin(string userName, string password,string verificationCode)
        {
            DataAccess.DBEntities context = new DataAccess.DBEntities();
            Entities.Users user = context.Users.Where(m => m.UserName == userName && m.PassWord == password && m.IsAdmin == 1).FirstOrDefault();
            return user;
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
            Entities.Users user = context.Users.Where(m => m.UserName == userName && m.PassWord == password).FirstOrDefault();
            return user;
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
