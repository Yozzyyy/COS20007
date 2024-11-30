using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure2
{
    public class Inventory
    {
        private List<Item> _items;
        private string listitm;

        public Inventory()
        {
            _items = new List<Item>(); //call and intialize the list to be executed by the Item.cs
        }

        public bool HasItem(String id)
        {
            foreach (Item i in _items)
            {
                if (i.AreYou(id))
                {
                    return true;
                }
            }
            return false;
        }
        public void Put(Item itm) //add an item
        {

            _items.Add(itm);

        }
        public Item take(String id) //remove and item
        {
            Item takeItem = this.Fetch(id);
            _items.Remove(takeItem);
            return takeItem;
        }


        public Item Fetch(String id) //get the item 
        {
            foreach (Item i in _items)
            {
                if (i.AreYou(id))
                {
                    return i;
                }
            }
            return null;
        }

        public string ItemList
        {
            get
            {
                string Listitm = "";
                foreach (Item i in _items)
                {
                    Listitm = Listitm + i.ShortDescription;
                }
                return listitm;
            }


        }
    }
}
