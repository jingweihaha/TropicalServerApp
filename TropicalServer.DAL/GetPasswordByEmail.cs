using EASendMail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TropicalServer.DAL
{
    public class GetPasswordByEmail
    {
        string sql = "";
        readonly string connString = Convert.ToString(ConfigurationManager.AppSettings["TropicalServerConnectionString"]);
        SqlConnection connection;
        /*
         check if Login_ID and Password is matchable or not
         */
        /*
         Get back UserID and Password by using EmailID
         */
        public model.User GetPasswordByEmailID(string Email)
        {
            using (connection = new SqlConnection(connString))
            {
                    connection.Open();
                    Console.WriteLine("asdf");

                    sql = "select * from tblUserLogin where EmailID=@EmailID";
                    SqlCommand comm = new SqlCommand(sql, connection);
                    comm.Parameters.AddWithValue("EmailID", Email);
                    //comm.Parameters.AddWithValue("Password", Password);
                    using (var reader = comm.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new model.User(reader.GetString(0), reader.GetString(1), reader.GetString(2));
                        }
                        //connection.Close();
                        return null;
                    }
            }
        }
    }
}
