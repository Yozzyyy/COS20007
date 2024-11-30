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
    public class Location : GameObject, IhaveInv //inheritance from bag and player 
    {
        private Inventory _inventory;
        
        public Location(string name, string desc) : base(new string[] { "Location" },name,desc) //overide new info for name and description
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
                StringBuilder description = new StringBuilder();
                description.AppendLine($"You are in {Name}."); //avoid stack overflow and duplication 
                description.AppendLine("Items at this location:");
                description.AppendLine(_inventory.ItemList); // Ensure ItemList is a simple list, not calling FullDescription

                return description.ToString();
            }
        }
        public Inventory Inventory
        {
            get => _inventory;
        }
        

    }

}
