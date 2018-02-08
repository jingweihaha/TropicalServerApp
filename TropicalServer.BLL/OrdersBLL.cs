using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TropicalServer.DAL;
namespace TropicalServer.BLL
{
    public class OrdersBLL
    {
        public DataSet GetOrders(string time, string id, string name)
        {
            ReportsDAL r = new ReportsDAL();
            DataSet ds = r.spGetOrdersByTimeIdName(time, id, name);
            return ds;
        }
        //		$exception	{"A connection was successfully established with the server, but then an error occurred during the pre-login handshake. (provider: Shared Memory Provider, error: 0 - The handle is invalid.)"}
    //System.Data.SqlClient.SqlException

        public void UpdateRecords(string tracknum, string time, string custid, string custname, string custaddress, string route)
        {
            OrderDAL od = new OrderDAL();
            od.Update(tracknum,time,custid,custname,custaddress,route);
        }

        public void DeleteRecords(string custid)
        {
            OrderDAL od = new OrderDAL();
            od.Delete(custid);
        }

        public DataSet GetPopUp(string time, string id, string name)
        {
            OrderDAL rd = new OrderDAL();
            DataSet ds = rd.GetPopUp(time, id, name);
            return ds;
        }

    }
}
