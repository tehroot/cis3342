using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace Project3.Pages {
    public partial class account : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            bindData();
        }

        protected void bindData() {
            String id = Request.QueryString["username"];
            User user = loginService.returnUser(id);
            username.Text = user.username;
            firstName.Text = user.firstname;
            lastName.Text = user.lastname;
            alternateEmail.Text = user.alternateemail;
            userbanStatus.Text = user.banflag.ToString();
        }

        protected void checkLogout_Click(Object sender, EventArgs e) {
            Session.Abandon();
            Response.Redirect("~/Pages/landing.aspx");
        }

        protected void returnPage_Click(Object sender, EventArgs e) {

        }
    }
}