using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TropicalServer.UserControls
{
    public partial class LoginUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void LoginButton_Click(object sender, EventArgs e)
        {
            //get the Login Id and Password
            string UserID = useridtextbox.Text;
            string Password = passwordtextbox.Text;
            BLL.LoginBLL bll = new BLL.LoginBLL();
            Boolean tmp = bll.UserLogin(UserID, Password);
            if (tmp == true)
            {
                Session["UserID"] = UserID;
                //Response.Redirect("/UI/Index.aspx");
                Response.Redirect("/UI/Products.aspx");

            }
            else
            {
                Session["UserID"] = "WRONG";
                //Response.Redirect("/UI/Products.aspx");
            }
        }
    }
}