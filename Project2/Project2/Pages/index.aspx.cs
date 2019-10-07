using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project2.Classes;
using Utilities;


namespace Project2.Pages {
    public partial class index : System.Web.UI.Page {

        DBConnect dBConnect = new DBConnect();
        protected void Page_Load(object sender, EventArgs e) {

            if (!IsPostBack) {
                displayData();
                
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
            try {
                if (Request.Form["rewardsnumber"] != "") {
                    Customer customer = new Customer(Request.Form["firstname"], Request.Form["lastname"], Request.Form["rewardsnumber"]);
                    if (Customer.rewardsDiscount(customer)) {
                        //customer.rewards_discount = true;
                    }
                } else {
                    Customer customer = new Customer(Request.Form["firstname"], Request.Form["lastname"]);
                }
            } catch (Exception a) {
                //errorlabel.Text = a.Message;
            }
            foreach (GridViewRow row in gvTea.Rows) {
                //Drink drink = new Drink();
                CheckBox selected = (CheckBox)row.FindControl("checkbox");
                Debug.WriteLine(selected.Checked.ToString());
                if (selected.Checked) {
                    for (int i = 0; i < row.Cells.Count; i++) {
                       
                    }
                }
            }
        }
    }
}