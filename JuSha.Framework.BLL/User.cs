using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuSha.Framework.BLL
{
    public class User
    {
        public void AdminLogin(string UserName, string Password)
        {
            DataAccess.DBEntities entity = new DataAccess.DBEntities();
            Entities.Users user= entity.Users.FirstOrDefault();
        }
    }
}
