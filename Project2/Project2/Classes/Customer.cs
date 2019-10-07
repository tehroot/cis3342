using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project2.Classes {
    public class Customer {
        public int customer_reward_id { get; set; }
        public String customer_name { get; set; }
        public String customer_phone_number { get; set; }
        public float customer_gross_sales { get; set; }
        public int customer_total_orders { get; set; }


        public Customer(String name, String phone_number) {

        }

        public Customer(String name, String phone_number, String rewards_id) {

        }

        public Customer(String name, String phone_number) {

        }
    }
}