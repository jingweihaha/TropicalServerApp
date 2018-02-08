using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Caching;
using System.Data;
using TropicalServer.BLL;
using TropicalServer.DAL;
using System.Data.SqlClient;


namespace TropicalServer.UI
{
    public partial class Orders : System.Web.UI.Page
    {
        private SqlConnection conn = new SqlConnection("server=LAPTOP-T8BD4H2U\\SQLEXPRESS2012;database=TropicalServer;Integrated Security=true;");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //judge if cache is empty or not
                //DataSet ds = (DataSet)Cache["Orders"];
                //if (ds != null)
                //{
                //    ReadFromCache(ds);
                //    System.Diagnostics.Debug.WriteLine("Page loaded, use cache");
                //}
                //else
                //{
                    gvbind();
                //}
            }
            
        }

        //protected void ReadFromCache(DataSet ds)
        //{
        //    //throw new NotImplementedException();
        //    GridView1.DataSource = ds;
        //    GridView1.DataBind();
        //}

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get information from textbox and dropdown list
            string time = DropDownList1.Text;
            string id = TextBox1.Text;
            string name = TextBox2.Text;
        
            OrdersBLL ob = new OrdersBLL();
            DataSet ds2 = ob.GetOrders(time, id, name);
            GridView1.DataSource = ds2;
            GridView1.DataBind();
            //put the order information into cache.
            //Cache["Orders"] = ds2;
            System.Diagnostics.Debug.WriteLine("Dropdownlist changed");

            //Page_Load(sender, e);

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            //get information from textbox and dropdown list
            string time = DropDownList1.Text;
            string id = TextBox1.Text;
            string name = TextBox2.Text;

            System.Diagnostics.Debug.WriteLine("Text 1 changed");
            OrdersBLL ob = new OrdersBLL();
            DataSet ds2 = ob.GetOrders(time, id, name);
            GridView1.DataSource = ds2;
            GridView1.DataBind();
            //put the order information into cache.
            //Cache["Orders"] = ds2;

            //Page_Load(sender, e);
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            //get information from textbox and dropdown list
            string time = DropDownList1.Text;
            string id = TextBox1.Text;
            string name = TextBox2.Text;

            System.Diagnostics.Debug.WriteLine("Text2 changed");

            OrdersBLL ob = new OrdersBLL();
            DataSet ds2 = ob.GetOrders(time, id, name);
            GridView1.DataSource = ds2;
            GridView1.DataBind();
            //put the order information into cache.
            //Cache["Orders"] = ds2;

            //Page_Load(sender, e);
        }

        //itemtemplate
        //bountitem

        protected void gvbind()
        {
            string time = DropDownList1.Text;
            string id = TextBox1.Text;
            string name = TextBox2.Text;

            OrdersBLL ob = new OrdersBLL();
            DataSet ds2 = ob.GetOrders(time, id, name);

            if (ds2.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds2;
                GridView1.DataBind();
            }
            else
            {

                ds2.Tables[0].Rows.Add(ds2.Tables[0].NewRow());
                GridView1.DataSource = ds2;
                GridView1.DataBind();
                //int columncount = GridView1.Rows[0].Cells.Count;
                //GridView1.Rows[0].Cells.Clear();
                //GridView1.Rows[0].Cells.Add(new TableCell());
                //GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                //GridView1.Rows[0].Cells[0].Text = "No Records Found";
            }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            //Label lbldeleteid = (Label)row.FindControl("lblID");
            //conn.Open();
            //SqlCommand cmd = new SqlCommand("delete FROM detail where id='" + Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()) + "'", conn);
            //cmd.ExecuteNonQuery();
            //conn.Close();
            //-------------------------------
            //int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            string tmp = row.Cells[2].Text;
            //var tmp2 = tmp.Controls[0];
            //string custid = (TextBox)row.Cells[2].Text;
            //----------------------------------
            OrdersBLL ob = new OrdersBLL();
            //ob.GetOrders();
            ob.DeleteRecords(tmp);
            
            gvbind();
        }

        //---------------------------------------------------------------
        //protected void GridView1_RowDeleting2(object sender, CommandEventArgs e)
        //{
        //    //GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        //    //Label lbldeleteid = (Label)row.FindControl("lblID");
        //    //conn.Open();
        //    //SqlCommand cmd = new SqlCommand("delete FROM detail where id='" + Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()) + "'", conn);
        //    //cmd.ExecuteNonQuery();
        //    //conn.Close();
        //    //-------------------------------
        //    //int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        //    GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        //    string tmp = row.Cells[2].Text;
        //    //var tmp2 = tmp.Controls[0];
        //    //string custid = (TextBox)row.Cells[2].Text;
        //    //----------------------------------
        //    OrdersBLL ob = new OrdersBLL();
        //    //ob.GetOrders();
        //    ob.DeleteRecords(tmp);

        //    gvbind();
        //}

        //-----------------------------------------
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            gvbind();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            //Label lblID = (Label)row.FindControl("lblID");
            TextBox tracknum = (TextBox)row.Cells[0].Controls[0];
            TextBox time = (TextBox)row.Cells[1].Controls[0];
            TextBox custid = (TextBox)row.Cells[2].Controls[0];
            TextBox custname = (TextBox)row.Cells[3].Controls[0];
            TextBox custaddress = (TextBox)row.Cells[4].Controls[0];
            TextBox route = (TextBox)row.Cells[5].Controls[0];
            
            GridView1.EditIndex = -1;

            OrdersBLL ob = new OrdersBLL();
            string tr = tracknum.Text;
            ob.UpdateRecords(tracknum.Text, time.Text, custid.Text, custname.Text, custaddress.Text, route.Text);
            gvbind();
            //GridView1.DataBind();  
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            gvbind();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            gvbind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {

            /*
             OnRowCommand="GridView1_OnRowCommand" 

             */
            if (e.CommandName == "GetView")
            {
                var tmppp = e.CommandArgument;
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = (GridViewRow)GridView1.Rows[index];
                System.Diagnostics.Debug.WriteLine("The " + index + " row's View has been clicked");
                string tmp = row.Cells[2].Text;
                //row[];
                string tracknum = row.Cells[0].Text;
                string time = row.Cells[1].Text;
                string custid = row.Cells[2].Text;
                string custname = row.Cells[3].Text;
                string custaddress = row.Cells[4].Text;
                string route = row.Cells[5].Text;

                OrdersBLL ob = new OrdersBLL();

                DataSet ds = ob.GetPopUp(time, custid, custname);

                DataRow r = ds.Tables[0].Rows[0];

                string tmp0 = row.Cells[0].Text;
                string tmp1 = row.Cells[1].Text;
                string tmp2 = row.Cells[2].Text;
                string tmp3 = row.Cells[3].Text;
                string tmp4 = row.Cells[4].Text;
                string tmp5 = row.Cells[5].Text;
                System.Windows.Forms.MessageBox.Show(tmp0 + " " + tmp1 + " " + tmp2 + " " + tmp3 + " " + tmp4 + " " + tmp5);
            }
        }

        //protected void gv_RowDataBound(object sender, GridViewRowEventArgs  e)
        //{
        //    var tmp= e.Row.RowIndex;
        //    e.Row.
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        LinkButton btn = (LinkButton)sender;
        //        var tmp2 = btn.Text;
        //        ((LinkButton)e.Row.Cells[7].Controls[0]).OnClientClick = "return confirm('Are you sure you want to delete?');"; // add any JS you want here
        //    }
        //}
    }
}