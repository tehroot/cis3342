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
            if (Request.QueryString["username"] == null || Request.QueryString["username"].Length < 1 && Session["Username"] != null) {
                String id = Session["Username"].ToString();
                User user = loginService.returnUser(id);
                username.Text = user.username;
                firstName.Text = user.firstname;
                lastName.Text = user.lastname;
                alternateEmail.Text = user.alternateemail;
                userbanStatus.Text = user.banflag.ToString();
            } else if (Request.QueryString["username"] != null && Session["Username"].ToString() != Request.QueryString["username"]) {
                String id = Request.QueryString["username"];
                String user_string = emailService.returnUserFromEmailId(id);
                User user = loginService.returnUser(user_string);
                username.Text = user.username;
                firstName.Text = user.firstname;
                lastName.Text = user.lastname;
                alternateEmail.Text = user.alternateemail;
                userbanStatus.Text = user.banflag.ToString();
            }
        }

        protected void checkLogout_Click(Object sender, EventArgs e) {
            Session.Abandon();
            Response.Redirect("~/Pages/landing.aspx");
        }

        protected void returnPage_Click(Object sender, EventArgs e) {
            if (Request.QueryString["username"] == null || Request.QueryString["username"].Length < 1 && Session["Username"] != null) {
                Response.Redirect("~/Pages/inbox.aspx");
            } else if (Request.QueryString["username"] != null && Session["Username"].ToString() != Request.QueryString["username"]) {
                Response.Redirect("~/Pages/admin.aspx");
            }
        }
    }
}