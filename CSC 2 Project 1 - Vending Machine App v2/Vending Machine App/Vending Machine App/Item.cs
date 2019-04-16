using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine_App
{
    /*
     * 
     *  Initial thoughts to modularize and restructure code 
     *  
     *  Going to use structures / methods instead
     * 
     *  Just ignore this until further notice 
     * 
     * 
     *  // Version 2 -- See tab Item.cs* Class work that we cannot use (Copy/Paste into Form1.cs later)
     *      
     *           Item[] items = {new Item(1.00m, "Sprite"), new Item(1.25m, "CocaCola"), new Item(1.10m, "Lemonade"),
     *              new Item(1.10m, "Tea"), new Item(1.25m, "Pepsi"), new Item(0.95m, "Water"), new Item(0.85m, "Snickers"),
     *              new Item(1.00m, "Skittles"), new Item(0.95m, "Twix"), new Item(0.90m, "MandM"), new Item(2.00m, "Lays"),
     *              new Item(2.50m, "SaltandVinegar"), new Item(2.25m, "Pickle"), new Item(2.50m, "Doritos"), new Item(0.50m, "Gum"),
     *              new Item(1.50m, "Warheads")};
     *       
     * 
     */


    class Item
    {
        public decimal _price;
        public int _stock;
        public string _name;

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public void Reset()
        {
            Stock = 5;
        }

        public Item()
        {
            Price = 1.00m;
            Stock = 5;
            Name = "Undefined.";
        }

        public Item(decimal p, string n)
        {
            Price = p;
            Stock = 5;
            Name = n;
        }

        public Item(decimal p, int s, string n)
        {
            Price = p;
            Stock = s;
            Name = n;
        }

    }
}
