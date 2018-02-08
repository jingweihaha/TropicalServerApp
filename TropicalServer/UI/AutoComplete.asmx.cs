using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace TropicalServer
{
    /// <summary>
    /// Summary description for AutoComplete
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AutoComplete : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<string> AutoCompleteIt2(string prefixText)
        {
            List<string> res = new List<string>();

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection("server=LAPTOP-T8BD4H2U\\SQLEXPRESS2012;database=TropicalServer;Integrated Security=true;");

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@CustName", SqlDbType.NVarChar);
            if (prefixText.Trim() != string.Empty)
                parameters[0].Value = prefixText.Trim();
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand("GetMyProc", conn);
                command.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    SqlParameter p = null;
                    foreach (SqlParameter sqlP in parameters)
                    {
                        p = sqlP;
                        if (p != null)
                        {
                            if (p.Direction == ParameterDirection.InputOutput ||
                               p.Direction == ParameterDirection.Input && p.Value == null)
                            {
                                p.Value = DBNull.Value;
                            }
                            command.Parameters.Add(p);
                        }
                    }
                }
                //command.CommandTimeout = 6000;
               
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        res.Add(reader.GetString(0));
                }
                conn.Close();
            }
            catch(Exception ex)
            {
                throw new Exception("Error occured while retrieving Product Categories - " + ex.Message.ToString());
            }
            return res;
        }

        [WebMethod]
        public string[] AutoCompleteIt(string prefixText)
        {
            List<string> res = new List<string>();
            using (SqlConnection cn = new SqlConnection("Server=LAPTOP-T8BD4H2U\\SQLEXPRESS2012;Database=TropicalServer;Integrated Security=true;"))
            {
                //cn.Open();
                //string str = prefixText;
                ////str = null;
                //SqlCommand cmd = new SqlCommand("GetMyProc", cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                //DataTable dt = new DataTable();
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //da.SelectCommand.Parameters.Add("@CustName", SqlDbType.NVarChar).Value = str;
                //da.Fill(dt);
                //Debug.Assert(dt.Rows.Count > 0);
                ////GridView1.DataSource = dt;
                ////GridView1.Bind();
                //cn.Close();

                DataSet sqldataset = new DataSet();

                SqlConnection sqlconn = new SqlConnection("server=LAPTOP-T8BD4H2U\\SQLEXPRESS2012;database=TropicalServer;Integrated Security=true;");
                sqlconn.Open();
                string str = "SELECT distinct CustName FROM tblOrder o JOIN tblCustomer c ON o.OrderCustomerNumber = c.CustNumber WHERE c.CustName LIKE '%" + prefixText + "%'; ";

                SqlDataAdapter sqladapter = new SqlDataAdapter(str, sqlconn);

                sqladapter.Fill(sqldataset, "spt_values");

                foreach (DataRow dr in sqldataset.Tables["spt_values"].Rows)
                {    //Console.WriteLine("number:" + dr["CustName"].ToString());
                    Debug.WriteLine("CustName"+dr["CustName"].ToString());
                    res.Add(dr["CustName"].ToString());
                }
                return res.ToArray();
            }
        }
    }
}

//		str	"SELECT CustName FROM tblOrder o JOIN tblCustomer c ON o.OrderCustomerNumber = c.CustNumber WHERE c.CustName LIKE '%'M'%'; "	string

