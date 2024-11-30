using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure2
{
    public class Player : IdentifiableObject
    {
        private Inventory _inventory;
        public Player(string name, string desc) : base(new string[] { "Me", "Inventory " }, name, desc) //overide new info for name and description
        {
            _inventory = new Inventory();
        }



        public IdentifiableObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            return _inventory.Fetch(id);


        }
        public override string FullDescription
        {
            get
            {
                return $"{Name}, is carrying: " + _inventory.ItemList; //display our name is carrying itemlist which it varries between total list length
            }
        }
        public Inventory Inventory
        {
            get => _inventory;
        }

    }

}
