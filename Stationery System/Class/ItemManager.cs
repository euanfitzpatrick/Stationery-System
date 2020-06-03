using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery_System.Class
{
    public class ItemManager
    {
        public static Item[] Items
        {
            get
            {
                string path = $"{AppDomain.CurrentDomain.BaseDirectory}Items.csv";
                if (!File.Exists(path)) return null;
                List<Item> items = new List<Item>();
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    Item item = new Item();
                    string[] parts = line.Split(';');
                    item.ItemID = int.Parse(parts[0]);
                    item.ItemName = parts[1];
                    item.ItemPrice = decimal.Parse(parts[2]);
                    item.ItemQuantity = int.Parse(parts[3]);
                    items.Add(item);
                }
                return items.ToArray();
            }
            set
            {
                string path = $"{AppDomain.CurrentDomain.BaseDirectory}Items.csv";
                StringBuilder stringBuilder = new StringBuilder();
                foreach (Item item in value)
                {
                    string line = $"{item.ItemID};{item.ItemName};{item.ItemPrice};{item.ItemQuantity}";
                    stringBuilder.AppendLine(line);
                }
                File.WriteAllText(path, stringBuilder.ToString());
            }
        }

        public void AddItem(string itemName, decimal itemPrice)
        {
            Item[] itemsArray = Items;
            List<Item> items = itemsArray != null ? itemsArray.ToList() : new List<Item>();
            if (items.Any(x => x.ItemName == itemName))
            {
                Item currentItem = items.First(x => x.ItemName == itemName);
                currentItem.ItemQuantity += 1;
            }
            else
            {
                Item newItem = Item.CreateItem(itemName, itemPrice, 1);
                items.Add(newItem);
            }
            Items = items.ToArray();
        }

        public void GetInventoryReport()
        {

        }

        public Item[] GetFinancialReport()
        {
            return null;
        } 
    }
}
