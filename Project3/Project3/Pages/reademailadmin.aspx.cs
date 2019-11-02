using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace Project3.Pages {
    public partial class reademailadmin : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            bindControlData();
        }

        protected void bindControlData() {
            String id = Request.QueryString["emailID"];
            Email email = emailService.getEmail(id);
            timestamp.Text = email.email_datetime.ToString();
            sender.Text = email.email_sender;
            subject.Text = email.email_subject;
            recipient.Text = email.email_recipient;
            messageContent.Text = email.email_content;
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
            Response.Redirect("~/Pages/account.aspx", false);
        }

        protected void returnAdmin_Click(object sender, EventArgs e) {
            Response.Redirect("~/Pages/admin.aspx", false);
        }
    }
}