using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery_System.Class
{
    public class Item
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int ItemQuantity { get; set; }

        public static Item CreateItem(string itemName, decimal itemPrice, int itemQuantity)
        {
            Item[] items = ItemManager.Items;
            int nextID = 1;
            if (items != null && items.Any())
            {
                nextID = items.OrderBy(x => x.ItemID).Last().ItemID + 1;
            }
            Item item = new Item();
            item.ItemID = nextID;
            item.ItemName = itemName;
            item.ItemPrice = itemPrice;
            item.ItemQuantity = itemQuantity;
            return item;
        }
    }
}
