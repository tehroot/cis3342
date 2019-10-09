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

        //update drink gross sales individual, order by order
        protected static bool updateDrinkGrossSales(Order order) {
            DBConnect dBConnect = new DBConnect();
            List<Drink> initialList = order.drinks;
            float current_total = 0;
            float total = 0;
            foreach (Drink drink in initialList) {
                String sql_get = $"SELECT item_total_sales FROM drinks WHERE item_id LIKE '{drink.item_id}'";
                DataSet set = dBConnect.GetDataSet(sql_get);
                DataRow x = set.Tables[0].Rows[0];
                if (x[0].ToString() != null || x[0].ToString() != "") {
                    current_total = float.Parse(x[0].ToString());
                } else {
                    current_total = 0;
                }
                current_total += drink.item_total_price;
                String sql = $"UPDATE drinks SET item_total_sales = '{current_total}' WHERE item_id LIKE '{drink.item_id}'";
                int rows = dBConnect.DoUpdate(sql);
                if(rows == 1) {
                    return true;
                } else {
                    return false;
                }
            }
            return false;
        }
        //update drink total orders, sql query stuff
        protected static bool updateDrinkTotalOrders(Order order) {
            DBConnect dBConnect = new DBConnect();
            int current_total = 0;
            int total = 0;
            List<Drink> initialList = order.drinks;
            foreach (Drink drink in initialList) {
                String sql_get = $"SELECT item_quantity_sold FROM drinks WHERE item_id LIKE '{drink.item_id}'";
                DataSet set = dBConnect.GetDataSet(sql_get);
                DataRow x = set.Tables[0].Rows[0];
                if (x[0].ToString() != null || x[0].ToString() != "") {
                    current_total = int.Parse(x[0].ToString());
                } else {
                    current_total = 0;
                }
                current_total += drink.item_order_amount;
                String sql = $"UPDATE drinks SET item_quantity_sold = '{current_total}' WHERE item_id LIKE '{drink.item_id}'";
                int rows = dBConnect.DoUpdate(sql);
                if (rows == 1) {
                    return true;
                } else {
                    return false;
                }
            }
            return false;
        }

        //public method to perform above two methods externally easily
        public static void updateDrinksTable(Order order) {
            bool confirmedTotal = updateDrinkTotalOrders(order);
            bool confirmedGross = updateDrinkGrossSales(order);
            if(!confirmedTotal || !confirmedGross) {
                throw new Exception("Error updating Drink Tables");
            }
        }
    }
}