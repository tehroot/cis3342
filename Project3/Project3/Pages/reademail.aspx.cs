using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project3.Pages {
    public partial class reademail : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void bindControlData() {
            
        }

        protected void checkLogout_Click(Object sender, EventArgs e) {
            //remove session data and log user out of application
            //redirect to the landing page ->
            Session.Abandon();
            Response.Redirect("~/Pages/landing.aspx");
        }

        protected void checkLogin_Click(Object sender, EventArgs e) {
            //redirect to account information page for the user
            //relies on session shit for verification
            //maybe re-authorization using password??
            Response.Redirect("~/Pages/admin.aspx", false);
        }

        protected void checkInbox_Click(Object sender, EventArgs e) {
            Response.Redirect("~/Pages/inbox.aspx", false);
        }
    }
}