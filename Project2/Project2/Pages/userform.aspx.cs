using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace Project2.Pages {
    public partial class userform : System.Web.UI.Page {
        DBConnect dBConnect = new DBConnect();
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                displayManagementData();
            }
        }

        public void displayManagementData() {
            String sql_report = "SELECT * FROM drinks ORDER BY item_total_sales DESC";
            String sql_rewards = "SELECT * FROM reward_accounts ORDER BY customer_gross_sales DESC";
            gvManagementReport.DataSource = dBConnect.GetDataSet(sql_report);
            gvManagementRewards.DataSource = dBConnect.GetDataSet(sql_rewards);
            gvManagementReport.DataBind();
            gvManagementRewards.DataBind();
        }

        protected void resetForm_Click(object sender, EventArgs e) {
            Response.Redirect("~/Pages/index.aspx");
        }
    }
}