using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project2.Classes {
    public class Drink {
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
                }
            }
        }


        private Drink() {
            
        }


    }
}
