using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TropicalServer.BLL;

namespace TropicalServer.UI
{
    public partial class Products1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if (Cache["Every"] == null)
            {
                ProductsBLL b = new ProductsBLL();
                ds = b.GetProductByProductCategory_BLL("");
            }

            else
            {
                ds = (DataSet)Cache["Every"];
            }
            if (ds != null)
            {
                Console.WriteLine("Success");
                GridView1.DataSource = ds;
                GridView1.DataBind();
                //ds.GetXml();
                //Console.WriteLine(set.GetXml());
                //Response.Write(ds.GetXml());
                System.Diagnostics.Debug.WriteLine("---------------------------------");
                System.Diagnostics.Debug.WriteLine(ds.GetXml());
                Cache["Every"] = ds;
            }
        }

        /*
         * Button clike event
         * basing on different btn text, we can select corresponding records.
         */
        protected void  GetProductInfo(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string attri = btn.Text;

            DataSet ds = (DataSet)Cache[attri];
            if (ds != null)
            {
                Console.WriteLine("Success");
                GridView1.DataSource = ds;
                GridView1.DataBind();
                //ds.GetXml();
                //Console.WriteLine(set.GetXml());
                //Response.Write(ds.GetXml());
                System.Diagnostics.Debug.WriteLine("---------------------------------");
                System.Diagnostics.Debug.WriteLine(ds.GetXml());
            }
            else
            { 
                ProductsBLL b = new ProductsBLL();
                ds = b.GetProductByProductCategory_BLL(attri);
                
                    if (ds != null)
                    {
                        Console.WriteLine("Success");
                        GridView1.DataSource = ds;
                        GridView1.DataBind();
                        //ds.GetXml();
                        //Console.WriteLine(set.GetXml());
                        //Response.Write(ds.GetXml());
                        System.Diagnostics.Debug.WriteLine("---------------------------------");
                        System.Diagnostics.Debug.WriteLine(ds.GetXml());
                        Cache[attri] = ds;
                }
            }
            
        }
        //PageSize="5" onselectedindexchanged="GridView1_SelectedIndexChanged"
        //GridView1_SelectedIndexChanged
        protected void GridView1_IndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Use the Cancel property to cancel the paging operation.


            // Display an error message.
            //int newPageNumber = e.NewPageIndex + 1;
            //e.NewPageIndex++;

            // Set the index of the new display page.   
            GridView1.PageIndex = e.NewPageIndex;

            // Rebind the GridView control to  
            // show data in the new page. 
            Page_Load(sender, e);
        }

        protected void Page_Load(string str)
        {
            DataSet ds = new DataSet();
            if (Cache["Every"] == null)
            {
                ProductsBLL b = new ProductsBLL();
                ds = b.GetProductByProductCategory_BLL("");

            }

            else
            {
                ds = (DataSet)Cache["Every"];
            }
            if (ds != null)
            {
                Console.WriteLine("Success");
                GridView1.DataSource = ds;
                GridView1.DataBind();
                //ds.GetXml();
                //Console.WriteLine(set.GetXml());
                //Response.Write(ds.GetXml());
                System.Diagnostics.Debug.WriteLine("---------------------------------");
                System.Diagnostics.Debug.WriteLine(ds.GetXml());
                Cache["Every"] = ds;
            }
        }

    }
}