using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            foreach (String key in Request.Form.Keys) {
                Debug.WriteLine(key);
            }
        }

        public void displayData() {
            String selectCoffeeProducts = "SELECT * FROM drinks WHERE item_category = 'Coffee'";
            String selectTeaProducts = "SELECT * FROM drinks WHERE item_category ='tea'";
            gvTea.DataSource = dBConnect.GetDataSet(selectTeaProducts);
            gvTea.DataBind();
            gvCoffee.DataSource = dBConnect.GetDataSet(selectCoffeeProducts);
            gvCoffee.DataBind();
        }

        protected void buildOrderObject_Click(object sender, EventArgs e) {
            
        }
    }
}