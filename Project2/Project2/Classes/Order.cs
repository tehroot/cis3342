using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project2.Classes {
    public class Order {
        public List<Drink> drinks = new List<Drink>();

        public Order() {
            
        }

        public void addDrink(Drink drink) {
            drinks.Add(drink);
        }
    }
}