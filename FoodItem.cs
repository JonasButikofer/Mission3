using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Mission2
{
    public class FoodItem
    {

        // the item properties initialized
        public string ItemName { get; set; }
        public string ItemCategory { get; set; }
        public int ItemQuantity { get; set; }
        public DateTime ItemDate { get; set; }



        // Constructor
        public FoodItem(string itemName, string itemCategory, int itemQuantity, DateTime date)
        {
            ItemName = itemName;
            ItemCategory = itemCategory;
            ItemQuantity = itemQuantity;
            ItemDate = date;
        }
    }
}
