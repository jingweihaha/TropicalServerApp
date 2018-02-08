using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TropicalServer.DAL.model
{
    public class User
    {
        public string UserID { get; set; }
        public string Password { get; set; }
        public string EmailID { get; set; }

        public User(string UserID, string Password, string EmailID)
        {
            this.UserID = UserID;
            this.Password = Password;
            this.EmailID = EmailID;
        }

        public User()
        {
        }

        public string GetUserInfoToString()
        {
            return "UserID is "+this.UserID + " Password is "+this.Password + " EmailID is "+this.EmailID;
        }
    }
}
