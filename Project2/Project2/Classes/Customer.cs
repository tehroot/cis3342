using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using Utilities;
using System.Data;
using System.Data.SqlClient;

namespace Project2.Classes {
    public class Customer {

        //field backing stuff here
        //all of it
        private int _customer_reward_id { get; set; }
        public int customer_reward_id {
            get { return _customer_reward_id; }
            set {
                if (value > 0 || value < 999999) {
                    _customer_reward_id = value;
                } else {
                    throw new ArgumentException("Invalid Customer Reward ID");
                }
            }
        }
        private String _customer_name { get; set; }
        public String customer_name {
            get { return _customer_name; }
            set {
                if(value != "" && value != null) {
                    _customer_name = value;
                } else {
                    throw new ArgumentException("Invalid Customer Name");
                }
            }
        }
        private String _customer_phone_number { get; set; }
        public String customer_phone_number {
            get { return _customer_phone_number; }
            set {
                if(value != "" && value != null) {
                    _customer_phone_number = value;
                } else {
                    throw new ArgumentException("Invalid Customer Phone Number");
                }
            }
        }
        private float _customer_gross_sales { get; set; }
        public float customer_gross_sales {
            get { return _customer_gross_sales; }
            set {
                if (value >= 0) {
                    _customer_gross_sales = value;
                } else {
                    throw new ArgumentException("Invalid Gross Sales");
                }
            }
        }
        private int _customer_total_orders { get; set; }
        public int customer_total_orders {
            get { return _customer_total_orders; }
            set {
                if (value >= 0) {
                    _customer_total_orders = value;
                } else {
                    throw new ArgumentException("Invalid Total Orders");
                }
            }
        }

        private bool _rewards_discount { get; set; }
        public bool rewards_discount {
            get { return _rewards_discount; }
            set {
                _rewards_discount = value;
            }
        }
        //constructor
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
        
        //verify that the reward number is right
        public static bool rewardsDiscount(Customer customer) {
            DBConnect dBConnect = new DBConnect();
            int recordsReturned = 0;
            String sql = $"SELECT * FROM reward_accounts WHERE customer_reward_id LIKE '{customer.customer_reward_id}'";
            dBConnect.GetDataSet(sql, out recordsReturned);
            if (recordsReturned == 1) {
                customer.rewards_discount = true;
                return true;
            } else {
                customer.rewards_discount = false;
                return false;
            }
        }

        //update reward members total gross sales
        protected static bool updateCustomerGrossSales(Customer customer, Order order) {
            DBConnect dBConnect = new DBConnect();
            float current_total = 0;
            float total = 0;
            String sql_get = $"SELECT customer_gross_sales FROM reward_accounts WHERE customer_reward_id LIKE '{customer.customer_reward_id}'";
            if (customer.rewards_discount == true) {
                DataSet set = dBConnect.GetDataSet(sql_get);
                DataRow x = set.Tables[0].Rows[0];
                if(x[0].ToString() != "" && x[0].ToString() != null) {
                    current_total = float.Parse(x[0].ToString());
                } else {
                    current_total = 0;
                }
                foreach(Drink drink in order.drinks) {
                    total += drink.item_total_price;
                }
                total += current_total;
                String sql = $"UPDATE reward_accounts SET customer_gross_sales = '{total}' WHERE customer_reward_id LIKE '{ customer.customer_reward_id }'";
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

        //update reward members total orders
        protected static bool updateCustomerTotalOrders(Customer customer, Order order) {
            DBConnect dBConnect = new DBConnect();
            int current_total = 0;
            int total = 0;
            String sql_get = $"SELECT customer_total_orders FROM reward_accounts WHERE customer_reward_id LIKE '{customer.customer_reward_id}'";
            if (customer.rewards_discount == true) {
                DataSet set = dBConnect.GetDataSet(sql_get);
                DataRow x = set.Tables[0].Rows[0];
                if (x[0].ToString() != "" && x[0].ToString() != null) {
                    current_total = int.Parse(x[0].ToString());
                } else {
                    current_total = 0;
                }
                foreach (Drink drink in order.drinks) {
                    total += drink.item_order_amount;
                }
                total += current_total;
                String sql = $"UPDATE reward_accounts SET customer_total_orders = '{total}' WHERE customer_reward_id LIKE '{ customer.customer_reward_id }'";
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
        //public method to perform above two methods externally easily
        public static void updateCustomerRewardsTable(Customer customer, Order order) {
            bool confirmedGross = updateCustomerGrossSales(customer, order);
            bool confirmedTotal = updateCustomerTotalOrders(customer, order);
            if (!confirmedTotal || !confirmedGross) {
                throw new Exception("Error updating Customer Tables");
            }
        }
    }
}
