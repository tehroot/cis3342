using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using Utilities;

namespace Project2.Classes {
    public class Drink {
        private Dictionary<String, float> priceMultipliers = new Dictionary<String, float> {
            ["Tall"] = 1.0F,
            ["Grande"]= 1.2F,
            ["Venti"] = 1.4F,
            ["Trenta"] = 1.6F
        };
        

        private int _item_id { get; set; }
        public int item_id {
            get { return _item_id; }
            set {
                if (value > 0 || value < 999999) {
                    _item_id = value;
                } else {
                    throw new ArgumentException("Invalid Item ID");
                }
            }
        }
        private String _item_title { get; set; }
        public String item_title {
            get { return _item_title; }
            set {
                if (value != "" && value != null) {
                    _item_title = value;
                } else {
                    throw new ArgumentException("Invalid Item Title");
                }
            }
        }
        private String _item_category { get; set; }
        public String item_category {
            get { return _item_category; }
            set {
                if (value != "" && value != null) {
                    _item_category = value;
                } else {
                    throw new ArgumentException("Invalid Item Category");
                }
            }
        }
        private float _item_price { get; set; }
        public float item_price {
            get { return _item_price; }
            set {
                if(value > 0 || value < 999999) {
                    _item_price = value;
                } else {
                    throw new ArgumentException("Invalid Item Price");
                }
            }
        }

        private int _item_order_amount { get; set; }
        public int item_order_amount {
            get { return _item_order_amount; }
            set {
                if(value >= 0 || value < 999999) {
                    _item_order_amount = value;
                } else {
                    throw new ArgumentException("Invalid Item Order Amount");
                }
            }
        }

        private String _item_size { get; set; }
        public String item_size {
           get { return _item_size; }
           set {
                if (value != "" && value != null) {
                    _item_size = value;
                } else {
                    throw new ArgumentException("Invalid Item Physical Size");
                }
            }
        }

        private float _item_total_sales { get; set; }
        public float item_total_sales {
            get { return _item_total_sales; }
            set {
                if (value >= 0 || value < 99999999) {
                    _item_total_sales = value;
                } else {
                    throw new ArgumentException("Invalid Item Sales Value");
                }
            }
        }

        private int _item_quantity_sold { get; set; }
        public int item_quantity_sold {
            get { return _item_quantity_sold; }
            set {
                if (value > 0 || value < 999999999) {
                    _item_quantity_sold = value;
                } else {
                    throw new ArgumentException("Invalid Item Sold");
                }
            }
        }

        private String _item_description { get; set; }
        public String item_description {
            get { return _item_description; }
            set {
                if(value != "" && value != null) {
                    _item_description = value;
                } else {
                    throw new ArgumentException("Invalid String set, description");
                }
            }
        }

        private float _item_total_price { get; set; }
        public float item_total_price {
            get { return _item_total_price; }
            set {
                if (value >= 0 || value < 999999999) {
                    _item_total_price = value;
                } else {
                    throw new ArgumentException("Invalid item total price");
                }
            }
        }

        public Drink(String id, String size, String order_amount, String category) {
            DBConnect dbConnect = new DBConnect();
            int order_item_id = 0;
            int order_item_size = 0;
            item_size = size;
            item_category = category;
            if (int.TryParse(order_amount, out order_item_size)) {
                item_order_amount = order_item_size;
            } else {
                throw new Exception("Order amount invalid");
            }
            if (int.TryParse(id, out order_item_id)) {
                item_id = order_item_id;
                String sql = $"SELECT * FROM drinks WHERE item_id LIKE '{order_item_id}'";
                DataSet set = dbConnect.GetDataSet(sql);
                DataRow x = set.Tables[0].Rows[0];
                item_title = x[1].ToString();
                item_description = x[2].ToString();
                item_price = float.Parse(x[4].ToString());
                item_total_price = (item_price * priceMultipliers[item_size]) * (item_order_amount);
            } else {
                throw new Exception("Customer_rewards invalid");
            }
        }
        public Drink() {

        }
        
    }
}