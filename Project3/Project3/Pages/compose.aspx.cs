using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace Project3.Pages {
    public partial class compose : System.Web.UI.Page {
        Email email;
        protected void Page_Load(object sender, EventArgs e) {
            bindList();
        }

        protected void bindList() {
            try {
                sender.Text = Session["Username"].ToString() + "@fmail.io";
                recipientList.DataSource = emailService.returnUsersList(Session["username"].ToString());
                recipientList.DataBind();
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        protected void checkInbox_Click(Object sender, EventArgs e) {
            Response.Redirect("~/Pages/inbox.aspx", false);
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
        }

        protected void formValidation(Object sender, ServerValidateEventArgs e) {
            try {
                email = new Email(emailService.getID(), Session["Username"].ToString(), recipientList.SelectedValue.Split('@')[0],
                    messageContent.Text, subject.Text, DateTime.Now);
            } catch (Exception x) {
                e.IsValid = false;
                Debug.WriteLine(x.Message + x.StackTrace);
            }
        }

        protected void sendEmail_Click(Object sender, EventArgs e) {
            try {
                if (Page.IsValid) {
                    if (emailService.createNewEmail(email)) {
                        Response.Redirect("~/Pages/Inbox.aspx", false);
                    } else {
                        warningDiv.Visible = true;
                        warningDiv.InnerText = "Error in form submission, please resubmit and follow rules (SQL ERROR)";
                    }
                } else {
                    warningDiv.Visible = true;
                    warningDiv.InnerText = "Error in form submission, please resubmit and follow rules.";
                }
            } catch (Exception ex) {
                Debug.WriteLine(ex.StackTrace + ex.Message);
            }
        }
    }
}