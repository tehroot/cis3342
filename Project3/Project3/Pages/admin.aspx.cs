using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace Project3.Pages {
    public partial class admin : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                try {
                    if (Session["Username"].ToString().Length > 0 && Session["Username"] != null) {
                        bindControls();
                    } else {
                        Session.Abandon();
                        Response.Redirect("~/Pages/login.aspx");
                    }
                } catch (NullReferenceException ex) {
                    Session.Abandon();
                    Response.Redirect("~/Pages/login.aspx");
                }
            }
        }

        protected void bindControls() {
            gvFlaggedEmails_IDs.DataSource = emailService.getFlaggedEmails();
            gvFlaggedEmails_IDs.DataBind();
            gvFlaggedEmails.DataSource = emailService.getFlaggedEmails();
            gvFlaggedEmails.DataBind();
            gvAccountsList.DataSource = emailService.returnUsersList();
            gvAccountsList.DataBind();
        }

        protected void checkLogout_Click(Object sender, EventArgs e) {
            Session.Abandon();
            Response.Redirect("~/Pages/landing.aspx");
        }

        protected void checkAccount_Click(Object sender, EventArgs e) {
            Response.Redirect("~/Pages/account.aspx", false);
        }

        protected void gvFlaggedEmails_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                //String emailID = (e.Row.Cells[1].Text);
                e.Row.Attributes["onclick"] = String.Format("window.location = 'reademailadmin.aspx?emailID={0}'; ",
                    DataBinder.Eval(e.Row.DataItem, "id"));
            }
        }

        protected void view_user_account_Click(object sender, EventArgs e) {
            try {
                String id = "";
                int count = 0;
                foreach (GridViewRow row in gvFlaggedEmails_IDs.Rows) {
                    CheckBox selectedEmail = (CheckBox)row.FindControl("select_checkbox");
                    if (selectedEmail.Checked && Session["Username"] != null) {
                        count++;
                        id = row.Cells[4].Text;
                    }
                }
                if (count > 0) {
                    invalidLogin.Visible = false;
                    invalidLogin.InnerText = "";
                    Response.Redirect("~/Pages/account.aspx?emailID=" + id, false);
                } else {
                    invalidLogin.InnerText = "Must Select at least one email to view accounts.";
                    invalidLogin.Visible = true;
                }
            } catch(Exception ex) {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        protected void banUserAccount_Click(object sender, EventArgs e) {
            try {
                int count = 0;
                foreach (GridViewRow row in gvFlaggedEmails_IDs.Rows) {
                    CheckBox selectedEmail = (CheckBox)row.FindControl("select_checkbox");
                    if (selectedEmail.Checked && Session["Username"] != null) {
                        count++;
                        emailService.banUsername(row.Cells[4].Text, true);
                    }
                }
                if (count > 0) {
                    invalidLogin.Visible = false;
                    invalidLogin.InnerText = "";
                    Response.Redirect("~/Pages/admin.aspx", false);
                } else {
                    invalidLogin.InnerText = "Must Select at least one email to ban the user.";
                    invalidLogin.Visible = true;
                }
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        protected void unFlagEmail_Click(object sender, EventArgs e) {
            try {
                int count = 0;
                foreach (GridViewRow row in gvFlaggedEmails_IDs.Rows) {
                    CheckBox selectedEmail = (CheckBox)row.FindControl("select_checkbox");
                    if (selectedEmail.Checked && Session["Username"] != null) {
                        count++;
                        emailService.flagEmail(row.Cells[4].Text, false);
                    }
                }
                if (count > 0) {
                    invalidLogin.Visible = false;
                    invalidLogin.InnerText = "";
                    Response.Redirect("~/Pages/admin.aspx", false);
                } else {
                    invalidLogin.InnerText = "Must Select at least one email to unflag it.";
                    invalidLogin.Visible = true;
                }
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        protected void gvAccountsList_RowDataBound(object sender, GridViewRowEventArgs e) {

        }

        protected void unbanUser_Click(object sender, EventArgs e) {
            try {
                String id = "";
                Button btn = (Button)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                id = row.Cells[1].Text;
                if (emailService.unbanUser(id, false)) {
                    invalidLogin.InnerText = "User unbanned";
                    invalidLogin.Visible = true;
                    bindControls();
                } else {
                    invalidLogin.InnerText = "SQL error, try again later";
                    invalidLogin.Visible = true;
                    bindControls();
                }
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        protected void viewUserAccount_Click(object sender, EventArgs e) {
            try {
                String id = "";
                Button btn = (Button)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                id = row.Cells[1].Text;
                Response.Redirect("~/Pages/account.aspx?username=" + id, false);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }
    }
}