using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TropicalServer.DAL;
using TropicalServer.DAL.model;

namespace TropicalServer.BLL
{
    public class LoginBLL
    {
        //User user = new User();
        public Boolean UserLogin(string UserID, string Password)
        {
            LoginDAL dal = new LoginDAL();
            User u = dal.GetUser(UserID, Password);
            if (u == null)
                return false;
            return true;
        }
    }
}
