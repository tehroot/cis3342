using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace Project2.Pages {
    public partial class index : System.Web.UI.Page {

        DBConnect dBConnect = new DBConnect();
        protected void Page_Load(object sender, EventArgs e) {
            displayData();
        }

        public void displayData() {
            String selectProducts = "SELECT * FROM drinks";
            gvCoffee.DataSource = dBConnect.GetDataSet(selectProducts);
            gvCoffee.DataBind();
        }

    }
}