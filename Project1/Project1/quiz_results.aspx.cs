using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1 {
    public partial class Quiz_results : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            foreach (String s in Request.Form.AllKeys) {
                //lmao the collection sort shit L M A O
                Debug.WriteLine(s + ", " +Request.Form[s]);
            }
        }
    }
}