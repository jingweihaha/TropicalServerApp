using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace TropicalServer.DAL
{
    public class LoginDAL
    {
        string sql = "";
        readonly string connString = Convert.ToString(ConfigurationManager.AppSettings["TropicalServerConnectionString"]);
        SqlConnection connection;
        /*
         check if Login_ID and Password is matchable or not
         */
        public model.User GetUser(string UserID, string Password)
        {
            using (connection = new SqlConnection(connString))
            {
                connection.Open();
                Console.WriteLine("asdf");

                sql = "select * from tblUserLogin where UserID=@UserID and Password=@Password";
                SqlCommand comm = new SqlCommand(sql, connection);
                comm.Parameters.AddWithValue("UserID", UserID);
                comm.Parameters.AddWithValue("Password", Password);

                using (var reader = comm.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new model.User(reader.GetString(0), reader.GetString(1), reader.GetString(2));
                    }
                    //connection.Close();
                    return null;
                }
                    //SqlDataReader reader = comm.ExecuteReader();
                //Session operation is in the UI part, here we just return boolean result
            }
        }
    }
}
