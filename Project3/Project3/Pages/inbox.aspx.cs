using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace Project3.Pages {
    public partial class inbox : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            //if statement start here
            if (!IsPostBack) {
                //issues with null fetch from intermittent session dropping, null to catch, just drops the login and redirects
                //not elegant but what can you do..
                try {
                    if (Session["Username"].ToString().Length > 0 && Session["Username"] != null) {
                        bindControls("inbox");
                    } else {
                        Session.Abandon();
                        Response.Redirect("~/Pages/login.aspx");
                        //return to login page if session is non-existent
                    }
                } catch (NullReferenceException ex) {
                    Session.Abandon();
                    Response.Redirect("~/Pages/login.aspx");
                }
            } else {
            }
            //session management to check if the user is logged in,
            //if not in the session cache we need to push the user out back
            //to the login page
            
        }

        protected void bindControls(String folder) {
            gvEmails.DataSource = emailService.getEmails(Session["Username"].ToString(), folder);
            gvEmails.DataBind();
            rblFolders.DataSource = emailService.getFolders(Session["Username"].ToString());
            rblFolders.DataBind();
            gvEmails_IDs.DataSource = emailService.getEmails(Session["Username"].ToString(), folder);
            gvEmails_IDs.DataBind();
        }

        protected void checkLogin_Click(Object sender, EventArgs e) {
            Response.Redirect("~/Pages/account.aspx", false);
            //redirect to account information page for the user
            //relies on session shit for verification
            //maybe re-authorization using password??
        }

        protected void composeEmail_Click(Object sender, EventArgs e) {
            //push to compose aspx page and deal with that binding shit for the dropdown list
            //for users, need to set default folder to inbox
            Response.Redirect("~/Pages/compose.aspx", false);
        }

        protected void createFolder_Click(Object sender, EventArgs e) {
            //create folder chain, dropdown or something here, not sure about this yet
            //side pop box for folder addition, modal for adding to list?
            if (folderName.Text.Length > 0 && folderName.Text != null) {
                if (Session["Username"] != null) {
                    if (emailService.createEmailFolder(Session["Username"].ToString(), folderName.Text)) {
                        Response.Redirect("~/Pages/inbox.aspx", false);
                    }
                } else {
                    Session.Abandon();
                    Response.Redirect("~/Pages/login.aspx");
                }
            } else {
                invalidLogin.InnerText = "Must type something into new folder textbox.";
                invalidLogin.Visible = true;
            }
        }

        protected void checkLogout_Click(Object sender, EventArgs e) {
            //remove session data and log user out of application
            //redirect to the landing page ->
            Session.Abandon();
            Response.Redirect("~/Pages/landing.aspx");
        }

        protected void formValidation(Object sender, ServerValidateEventArgs e) {

        }

        protected void gvEmails_RowDataBound(Object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                //String emailID = (e.Row.Cells[1].Text);
                e.Row.Attributes["onclick"] = String.Format("window.location = 'reademail.aspx?emailID={0}'; ",
                    DataBinder.Eval(e.Row.DataItem, "id"));
            }
        }

        protected void redirectQuery(String param) {
            Response.Redirect("~/Pages/reademail.aspx ?emailid="+param, false);
        }

        protected void searchToggle_Click(object sender, EventArgs e) {

        }

        protected void deleteEmail_Click(object sender, EventArgs e) {
            int count = 0;
            foreach (GridViewRow row in gvEmails_IDs.Rows) {
                CheckBox selectedEmail = (CheckBox)row.FindControl("select_checkbox");
                if (selectedEmail.Checked) {
                    count++;
                    emailService.deleteEmail(Session["Username"].ToString(), row.Cells[2].Text);
                }
            }
            if(count > 0) {
                invalidLogin.Visible = false;
                invalidLogin.InnerText = "";
                Response.Redirect("~/Pages/inbox.aspx", false);
            } else {
                invalidLogin.InnerText = "Must Select at least one email to delete.";
                invalidLogin.Visible = true;
            }
        }

        protected void refreshPage_Click(object sender, EventArgs e) {
            Response.Redirect("~/Pages/inbox.aspx", false);
        }

        protected void flag_email_Click(object sender, EventArgs e) {
            int count = 0;
            foreach (GridViewRow row in gvEmails_IDs.Rows) {
                CheckBox selectedEmail = (CheckBox)row.FindControl("select_checkbox");
                if (selectedEmail.Checked && Session["Username"] != null) {
                    count++;
                    emailService.flagEmail(row.Cells[2].Text, true);
                }
            }
            if (count > 0) {
                invalidLogin.Visible = false;
                invalidLogin.InnerText = "";
                Response.Redirect("~/Pages/inbox.aspx", false);
            } else {
                invalidLogin.InnerText = "Must Select at least one email to flag.";
                invalidLogin.Visible = true;
            }
        }

        protected void viewEmailsInFolder_Click(object sender, EventArgs e) {
            String currentSelection = rblFolders.SelectedValue;
            bindControls(currentSelection);
            rblFolders.SelectedValue = currentSelection;
            selectedFolder.InnerText = currentSelection;
        }

        protected void addEmailToFolder_Click(object sender, EventArgs e) {
            String currentSelection = rblFolders.SelectedValue;
            int count = 0;
            foreach (GridViewRow row in gvEmails_IDs.Rows) {
                CheckBox selectedEmail = (CheckBox)row.FindControl("select_checkbox");
                if (selectedEmail.Checked && Session["Username"] != null) {
                    count++;
                    emailService.moveEmail(row.Cells[2].Text, currentSelection, Session["Username"].ToString());
                }
            }
            if (count > 0) {
                invalidLogin.Visible = false;
                invalidLogin.InnerText = "";
                Response.Redirect("~/Pages/inbox.aspx", false);
            } else {
                invalidLogin.InnerText = "Must Select at least one email to move folders.";
                invalidLogin.Visible = true;
            }
        }
    }
}