using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project3.Pages {
    public partial class landing : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void create_Click(object sender, EventArgs e) {
            Response.Redirect("~/Pages/newuser.aspx");
        }

        protected void login_Click(object sender, EventArgs e) {
            Response.Redirect("~/Pages/login.aspx");
        }
    }
}