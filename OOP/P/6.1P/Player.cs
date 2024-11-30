using SwinAdventure4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SwinAdventure4
{
    public class Player : GameObject , IhaveInv //inheritance from bag and player 
    {
        private Inventory _inventory;
        public Player(string name, string desc) : base(new string[] { "Me", "Inventory " }, name, desc) //overide new info for name and description
        {
            _inventory = new Inventory();
        }



        public GameObject Locate(string id)
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
                return $"You are {Name}, " + base.FullDescription + ".\nYou are carrying\n" + _inventory.ItemList; //display our name is carrying itemlist which it varries between total list length
            }
        }
        public Inventory Inventory
        {
            get => _inventory;
        }

    }

}
