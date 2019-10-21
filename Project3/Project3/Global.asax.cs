using System;
using System.Web;

namespace Project3 {
    public class Global : HttpApplication {
        protected void Application_Start() {
        }

        protected void Session_Start(object sender, EventArgs e) {
            //new session here on user login, not on just loading the login page, so on inbox.aspx redirect, register new session
            //move session caching out to the inbox.aspx page
        }
    }
}
