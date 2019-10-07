using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using Utilities;
using System.Data;

namespace Project2.Classes {
    public class Customer {
        [Range (0, 999999, ErrorMessage = "Rewards ID not valid")]
        public int customer_reward_id { get; set; }
        public String customer_name { get; set; }
        public String customer_phone_number { get; set; }
        [Range (0, 9999999, ErrorMessage = "Integer non-conformant to sales, gross_sales")]
        public float customer_gross_sales { get; set; }
        [Range (0, 9999999, ErrorMessage = "Integer non-conformant to sales, total_orders")]
        public int customer_total_orders { get; set; }
        public bool rewards_discount { get; set; }

        public Customer(String name, String phone_number) {
            customer_phone_number = phone_number;
            customer_name = name;
        }

        public Customer(String name, String phone_number, String rewards_id) {
            int customer_rewards = 0;
            if(int.TryParse(rewards_id, out customer_rewards)) {
                customer_reward_id = customer_rewards;
            } else {
                throw new Exception("Customer_rewards invalid");
            }
            customer_phone_number = phone_number;
            customer_name = name;
        }
        
        public static bool rewardsDiscount(Customer customer) {
            DBConnect dBConnect = new DBConnect();
            int recordsReturned = 0;
            String sql = $"SELECT * FROM rewards_account WHERE customer_reward_id LIKE '{customer.customer_reward_id}'";
            dBConnect.GetDataSet(sql, out recordsReturned);
            if (recordsReturned == 1) {
                customer.rewards_discount = true;
                return true;
            } else {
                customer.rewards_discount = false;
                return false;
            }
        }

        public static bool updateCustomerGrossSales(Customer customer, Order order) {
            DBConnect dBConnect = new DBConnect();
            float current_total = 0;
            float total = 0;
            String sql_get = $"SELECT customer_gross_sales FROM rewards_account WHERE customer_reward_id like '{customer.customer_reward_id}'";
            if (customer.rewards_discount == true) {
                DataSet set = dBConnect.GetDataSet(sql_get);
                DataRow x = set.Tables[0].Rows[0];
                if(x.ToString() != "") {
                    current_total = float.Parse(x.ToString());
                } else {
                    current_total = 0;
                }
                foreach(Drink drink in order.drinks) {
                    total += drink.item_price;
                }
                total += current_total;
                String sql = $"UPDATE rewards_account SET customer_gross_sales = '{total}' WHERE customer_reward_id LIKE '{ customer.customer_reward_id }'";
                int rowsUpdated = dBConnect.DoUpdate(sql);
                if (rowsUpdated == 1) {
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }

        public bool updateCustomerTotalOrders(Customer customer, Order order) {
            DBConnect dBConnect = new DBConnect();
            int current_total = 0;
            int total = 0;
            String sql_get = $"SELECT customer_total_orders FROM rewards_account WHERE customer_reward_id LIKE '{customer.customer_reward_id}'";
            if (customer.rewards_discount == true) {
                DataSet set = dBConnect.GetDataSet(sql_get);
                DataRow x = set.Tables[0].Rows[0];
                if (x.ToString() != "") {
                    current_total = int.Parse(x.ToString());
                } else {
                    current_total = 0;
                }
                foreach (Drink drink in order.drinks) {
                    total += drink.item_order_amount;
                }
                total += current_total;
                String sql = $"UPDATE rewards_account SET customer_total_orders = '{total}' WHERE customer_reward_id LIKE '{ customer.customer_reward_id }'";
                int rows = dBConnect.DoUpdate(sql);
                if (rows == 1) {
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
            
        }
    }
}