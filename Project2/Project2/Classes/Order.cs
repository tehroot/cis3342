using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Utilities;

namespace Project2.Classes {
    public class Order {

        public List<Drink> drinks = new List<Drink>();

        public Order() {
            
        }

        public void addDrink(Drink drink) {
            drinks.Add(drink);
        }

        public static bool updateDrinkGrossSales(Order order) {
            DBConnect dBConnect = new DBConnect();
            List<Drink> initialList = order.drinks;
            float current_total = 0;
            float total = 0;
            foreach (Drink drink in initialList) {
                String sql_get = $"SELECT item_total_sales FROM drinks WHERE drink_id LIKE '{drink.item_id}'";
                DataSet set = dBConnect.GetDataSet(sql_get);
                DataRow x = set.Tables[0].Rows[0];
                if (x.ToString() != null || x.ToString() != "") {
                    current_total = float.Parse(x.ToString());
                } else {
                    current_total = 0;
                }
                current_total += drink.item_price * drink.item_order_amount;
                String sql = $"UPDATE drink SET item_gross_sales = '{current_total}' WHERE drink_id LIKE '{drink.item_id}'";
                int rows = dBConnect.DoUpdate(sql);
                if(rows == 1) {
                    return true;
                } else {
                    return false;
                }
            }
            return false;
        }

        public static bool updateDrinkTotalOrders(Order order) {
            DBConnect dBConnect = new DBConnect();
            int current_total = 0;
            int total = 0;
            List<Drink> initialList = order.drinks;
            foreach (Drink drink in initialList) {
                String sql_get = $"SELECT item_quantity_sold FROM drinks WHERE drink_id LIKE '{drink.item_id}'";
                DataSet set = dBConnect.GetDataSet(sql_get);
                DataRow x = set.Tables[0].Rows[0];
                if (x.ToString() != null || x.ToString() != "") {
                    current_total = int.Parse(x.ToString());
                } else {
                    current_total = 0;
                }
                current_total += drink.item_order_amount;
                String sql = $"UPDATE drink SET item_total_orders = '{current_total}' WHERE drink_id LIKE '{drink.item_id}'";
                int rows = dBConnect.DoUpdate(sql);
                if (rows == 1) {
                    return true;
                } else {
                    return false;
                }
            }
            return false;
        }
    }
}