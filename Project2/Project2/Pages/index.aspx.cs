using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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

        public void displayOutputData(Order order, Customer customer) {
            if (customer.rewards_discount) {
                float totalCost = 0;
                gvOutput.DataSource = order.drinks;
                gvOutput.Columns[0].FooterText = "Total Cost: ";
                for (int i = 0; i < order.drinks.Count; i++) {
                    totalCost += order.drinks[i].item_total_price;
                }
                float discount = totalCost * .10F;
                totalCost = totalCost - discount;
                String formatted = String.Format(totalCost.ToString(), NumberStyles.Currency);
                gvOutput.Columns[6].FooterText = "DISCOUNT APPLIED: " + "$" + formatted;
                gvOutput.DataBind();
            } else {
                float totalCost = 0;
                gvOutput.DataSource = order.drinks;
                gvOutput.Columns[0].FooterText = "Total Cost: ";
                for (int i = 0; i < order.drinks.Count; i++) {
                    totalCost += order.drinks[i].item_total_price;
                }
                String formatted = String.Format(totalCost.ToString(), NumberStyles.Currency);
                gvOutput.Columns[6].FooterText = "$" + formatted;
                gvOutput.DataBind();
            }
        }

        protected void validateTextbox_OnServerValidate(object source, ServerValidateEventArgs e) {
            try {
                foreach (GridViewRow row in gvTea.Rows) {
                    CheckBox selected = (CheckBox)row.FindControl("checkbox");
                    if (selected.Checked) {
                        TextBox rowBox = (TextBox)row.FindControl("order_quantity");
                        if (rowBox.Text != "" && rowBox.Text != null) {
                            e.IsValid = true;
                        }
                    }
                }
            } catch (Exception ex) {
                e.IsValid = false;
            }
        }

        protected void buildOrderObject_Click(object sender, EventArgs e) {
            //required validator page validation for form information
            try {
                if (Page.IsValid) {
                    try {
                        if (rewardsnumber.Text != "" && rewardsnumber.Text != null) {
                            Order order = new Order();
                            Customer customer = new Customer(firstname.Text+" "+lastname.Text, phonenumber.Text, rewardsnumber.Text);
                            if (Customer.rewardsDiscount(customer)) {
                                foreach (GridViewRow row in gvCoffee.Rows) {
                                    CheckBox coffee_selected = (CheckBox)row.FindControl("checkbox");
                                    if (coffee_selected.Checked) {
                                        DropDownList size_list = (DropDownList)row.Cells[6].FindControl("drink_size");
                                        DropDownList temp_list = (DropDownList)row.Cells[5].FindControl("temperature_choice");
                                        TextBox order_amount = (TextBox)row.Cells[7].FindControl("order_quantity");
                                        Drink drink = new Drink(row.Cells[1].Text, size_list.SelectedValue, order_amount.Text, temp_list.SelectedValue);
                                        order.addDrink(drink);
                                    }
                                }
                                foreach (GridViewRow row in gvTea.Rows) {
                                    CheckBox tea_selected = (CheckBox)row.FindControl("checkbox");
                                    if (tea_selected.Checked) {
                                        DropDownList size_list = (DropDownList)row.Cells[6].FindControl("drink_size");
                                        DropDownList temp_list = (DropDownList)row.Cells[5].FindControl("temperature_choice");
                                        TextBox order_amount = (TextBox)row.Cells[7].FindControl("order_quantity");
                                        Drink drink = new Drink(row.Cells[1].Text, size_list.SelectedValue, order_amount.Text, temp_list.SelectedValue);
                                        order.addDrink(drink);
                                    }
                                }
                            }
                            orderform.Visible = false;
                            displayOutputData(order, customer);
                            Order.updateDrinksTable(order);
                        } else {
                            Order order = new Order();
                            Customer customer = new Customer(firstname.Text + " " + lastname.Text, phonenumber.Text);
                            foreach (GridViewRow row in gvCoffee.Rows) {
                                CheckBox coffee_selected = (CheckBox)row.FindControl("checkbox");
                                if (coffee_selected.Checked) {
                                    DropDownList size_list = (DropDownList)row.Cells[6].FindControl("drink_size");
                                    DropDownList temp_list = (DropDownList)row.Cells[5].FindControl("temperature_choice");
                                    TextBox order_amount = (TextBox)row.Cells[7].FindControl("order_quantity");
                                    Drink drink = new Drink(row.Cells[1].Text, size_list.SelectedValue, order_amount.Text, temp_list.SelectedValue);
                                    order.addDrink(drink);
                                }
                            }
                            foreach (GridViewRow row in gvTea.Rows) {
                                CheckBox tea_selected = (CheckBox)row.FindControl("checkbox");
                                if (tea_selected.Checked) {
                                    DropDownList size_list = (DropDownList)row.Cells[6].FindControl("drink_size");
                                    DropDownList temp_list = (DropDownList)row.Cells[5].FindControl("temperature_choice");
                                    TextBox order_amount = (TextBox)row.Cells[7].FindControl("order_quantity");
                                    Drink drink = new Drink(row.Cells[1].Text, size_list.SelectedValue, order_amount.Text, temp_list.SelectedValue);
                                    order.addDrink(drink);
                                }
                            }
                            orderform.Visible = false;
                            customerform.Style.Add("display", "none");
                            displayOutputData(order, customer);
                            Order.updateDrinksTable(order);
                        }
                    } catch (Exception a) {
                        //errorlabel.Text = a.Message;
                    }
                } else {
                    errorlabel.Text = "-- ERROR PROCESSING FORMS --";
                }
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

        //protected showManagementReport_Click(object sender, EventArgs e) {

        //}
    }
}