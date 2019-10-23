using Project3.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project3.Pages {
    public partial class newuser : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void checkAccount_Click(object sender, EventArgs e) {
            try {
                if (Page.IsValid) {

                } else {
                    warningdiv.InnerText = "Error in form submission, please resubmit and follow rules.";
                    warningdiv.Style.Add("visibility", "visible");
                }
            } catch (Exception ex) {

            }
        }

        protected void formValidation(object sender, ServerValidateEventArgs e) {
            try {
                User user = new User(email.Text, password.Text, firstname.Text, lastname.Text, alternateemail.Text, Request.Form["avatar"].ToString());
                e.IsValid = true;
            } catch (Exception x) {
                e.IsValid = false;
                Debug.WriteLine(x.Message + x.StackTrace);
            }
        }
    }
}