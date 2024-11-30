using SwinAdventure4;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SwinAdventure4
{
    public class Player : GameObject , IhaveInv //inheritance from bag and player 
    {
        private Inventory _inventory;
        private Location _location;
        public Player(string name, string desc) : base(new string[] { "Me", "Inventory " }, name, desc) //overide new info for name and description
        {
            _inventory = new Inventory();
            
        }



        public GameObject Locate(string id)
        {
            if (AreYou(id)) //first checking locate 
            {
                return this;
            }
            GameObject obj = _inventory.Fetch(id);
            if (obj != null) //second checking for object
            {
                return obj;
            }
            if (_location != null) //third checking for location
            {
                obj = _location.Locate(id);
                return obj;
            }
            else
            {
                return null;
            }
            


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
        public Location Location
        {
            get => _location;
            set => _location = value; //get and set value into _location
        }

    }

}
