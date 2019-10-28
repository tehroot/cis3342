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
                bindControls();
            } else {
                Debug.WriteLine("Test Val");
            }
            //session management to check if the user is logged in,
            //if not in the session cache we need to push the user out back
            //to the login page
            
        }

        protected void bindControls() {
            gvEmails.DataSource = emailService.getEmails(Session["Username"].ToString());
            gvEmails.DataBind();
        }

        protected void checkLogin_Click(Object sender, EventArgs e) {
            //redirect to account information page for the user
            //relies on session shit for verification
            //maybe re-authorization using password??
        }

        protected void composeEmail_Click(Object sender, EventArgs e) {
            //push to compose aspx page and deal with that binding shit for the dropdown list
            //for users, need to set default folder to inbox
        }

        protected void createFolder_Click(Object sender, EventArgs e) {
            //create folder chain, dropdown or something here, not sure about this yet
            //side pop box for folder addition, modal for adding to list?
        }

        protected void checkLogout_Click(Object sender, EventArgs e) {
            //remove session data and log user out of application
            //redirect to the landing page ->
        }

        protected void formValidation(Object sender, ServerValidateEventArgs e) {

        }

        protected void gvEmails_RowDataBound(Object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                //onclick redirect to email view
                //session shit maybe here?
                //e.Row.Attributes["onclick"] = 
            }
        }

        protected String returnEmailId() {
            throw new NotImplementedException();
        }

        protected void searchToggle_Click(object sender, EventArgs e) {

        }

        protected void searchEmails_Click(object sender, EventArgs e) {

        }
    }
}