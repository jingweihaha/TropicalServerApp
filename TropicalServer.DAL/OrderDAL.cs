using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TropicalServer.DAL
{
    public class OrderDAL
    {
        private SqlConnection conn = new SqlConnection("server=LAPTOP-T8BD4H2U\\SQLEXPRESS2012;database=TropicalServer;Integrated Security=true;");
        public void Update(string tracknum, string time, string custid, string custname, string custaddress, string route)
        {
            //throw new NotImplementedException();
            conn.Open();
            //SqlCommand cmd = new SqlCommand("SELECT * FROM detail", conn);  

            //update order table
            //SqlCommand cmd = new SqlCommand("update tblOrder set OrderTrackingNumber ='" + tracknum + "',OrderDate='" + time  + "',OrderRouteNumber='" + route + "'where OrderCustomerNumber='" + custid + "'", conn);
            //cmd.ExecuteNonQuery();

            string sql2 = "update tblOrder set OrderTrackingNumber =@OrderTrackingNumber , OrderDate=@OrderDate , OrderRouteNumber=@OrderRouteNumber where OrderCustomerNumber=@OrderCustomerNumber";
            //SqlCommand cmd2 = new SqlCommand(sql,conn);


            SqlCommand comm2 = new SqlCommand(sql2, conn);
            comm2.Parameters.AddWithValue("OrderTrackingNumber", tracknum);
            comm2.Parameters.AddWithValue("OrderDate", time);
            comm2.Parameters.AddWithValue("OrderRouteNumber", route);
            comm2.Parameters.AddWithValue("OrderCustomerNumber", custid);

            comm2.ExecuteNonQuery();

            //		sql2	"update tblOrder set OrderTrackingNumber =@OrderTrackingNumber and OrderDate=@time and OrderRouteNumber=@route where OrderCustomerNumber=@custid"	string


            //		string.Concat returned	"update tblOrder set OrderTrackingNumber ='ORD_330400602_00020',OrderDate='2012/2/28 8:05:57'where OrderCustomerNumber='330400602'"	string

            //		string.Concat returned	"update tblCustomer set CustName ='King Kullen #06',CustOfficeAddress1='2660 Hylan Blvd.',CustRouteNumber='555'where CustNumber='330400602'"	string

            //		update tblCustomer set CustName ='Jack's Mini Market',CustOfficeAddress1='508 Bloomfield Avenue'where CustNumber='300070'"	string

            //"update tblCustomer set CustName ='" + custname + "',CustOfficeAddress1='" + custaddress + "'where CustNumber='" + custid + "'", 

            //update customer table


            string sql = "update tblCustomer set CustName=@CustName, CustOfficeAddress1=@CustOfficeAddress1 where CustNumber=@CustNumber";
            //SqlCommand cmd2 = new SqlCommand(sql,conn);

            
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.Parameters.AddWithValue("CustName", custname);
            comm.Parameters.AddWithValue("CustOfficeAddress1", custaddress);
            comm.Parameters.AddWithValue("CustNumber", custid);

            comm.ExecuteNonQuery();

            conn.Close();
        }

        
        public void Delete( string custid)
        {
            //throw new NotImplementedException();
            conn.Open();
            //SqlCommand cmd = new SqlCommand("SELECT * FROM detail", conn);  

            //update order table
            SqlCommand cmd = new SqlCommand("delete from tblOrder where OrderCustomerNumber='" + custid + "'", conn);
            cmd.ExecuteNonQuery();

            //update customer table
            SqlCommand cmd2 = new SqlCommand("delete from tblCustomer where CustNumber='" + custid + "'", conn);
            cmd2.ExecuteNonQuery();
            conn.Close();
        }

        public DataSet GetPopUp(string time, string id, string name)
        {
            //string sql = "SELECT * FROM tblOrder o"+
            //"JOIN tblCustomer c ON o.OrderCustomerNumber = c.CustNumber"+
            //"WHERE o.OrderDate = @OrderDate"+
            //"and c.CustName = @CustName"+
            //"and o.OrderCustomerNumber = @CustID";
            ////SqlCommand cmd2 = new SqlCommand(sql,conn);

            //SqlCommand comm = new SqlCommand(sql, conn);
            //comm.Parameters.AddWithValue("OrderDate", time);
            //comm.Parameters.AddWithValue("CustName", id);
            //comm.Parameters.AddWithValue("OrderCustomerNumber", name);

            //SqlDataReader dr = comm.ExecuteReader();

            //throw new NotImplementedException();
            SqlParameter[] parameters = new SqlParameter[3];
            DataSet ds = new DataSet();

            parameters[0] = new SqlParameter("@OrderDate", SqlDbType.NVarChar);
            parameters[1] = new SqlParameter("@CustID", SqlDbType.NVarChar);
            parameters[2] = new SqlParameter("@CustName", SqlDbType.NVarChar);

            if (time.Trim() != string.Empty)
                parameters[0].Value = time.Trim();
            if (id.Trim() != string.Empty)
                parameters[1].Value = id.Trim();
            if (name.Trim() != string.Empty)
                parameters[2].Value = name.Trim();

                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("GetPopUp", conn);
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
                    command.CommandTimeout = 6000;
                    SqlDataAdapter adp = new SqlDataAdapter(command);
                    adp.Fill(ds);
                    //connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error occured while retrieving Product Categories - " + ex.Message.ToString());
                }
                return ds;
        }
    }
}
