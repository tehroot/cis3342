using System;
using System.Diagnostics;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace Project3.Pages {

    public partial class login : System.Web.UI.Page {


        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                 //not sure if any of this is actually needed, just need to redirect to the inbox page or show them that their login is invalid
                 //refresh the page? and/or add the ability to clear out all of the text in the form for submission
            }
        }

        protected void checkLogin_Click(object sender, EventArgs e) {
            //this currently works and will return true for a successful login, pretty sure. 
            //so we need to register a new session here and then redirect them to the inbox with that username token
            //get the username token for the session cache and then use that in order to
            //fire off the requisite storedprocedure for returning all of the users emails and subsequently filling in the 
            //dropdown for the labeling page.

            //if it's an admin, we need to figure out the session caching/application caching requirements in order to facilitate the transferance of 
            //that to the admin page functionality
            //in order to comply with the requirements of the project
            try {
                if (Page.IsValid) {
                    if (loginService.login(email.Text, password.Text)) {
                        Session.Add("Username", email.Text);
                        //procedure return user object from sql procedure
                        Response.Redirect("~/Pages/inbox.aspx", false);
                    }
                    } else {

                }
            } catch (Exception ex) {
                //THREADING EXCEPTIONS ARE NORMAL HERE, RESPONSE PROCS A THREADING ABORT EXCEPTION BY BREAKING THE CONTEXT BEFORE SWITCHING TO A NEW PAGE
                Debug.WriteLine(ex.StackTrace);
            }
        }

        protected void formValidation(Object sender, ServerValidateEventArgs e) {

        }
    }
}