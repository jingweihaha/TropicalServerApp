using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TropicalServer.BLL;

namespace TropicalServer.UI
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GetPasswordBack(object sender, EventArgs e)
        {
            string Email = (string)EmailID.Text;
            //GetPasswordBack g = new BLL.GetPasswordBack();
            GetPasswordBack g = new GetPasswordBack();
            g.GetPasswordByEmail(Email);
        }
    }
}