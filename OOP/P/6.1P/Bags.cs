using SwinAdventure4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure4
{
    public class Bag : Item , IhaveInv // inherintance from Item and IhaveInv
    {
        Inventory _inventory;

        public Bag(string[] idents, string name, string description) : base(idents, name, description)
        {
            _inventory = new Inventory();// taking the the list from inventory then initilize it

        }
        public GameObject Locate(string id) //locate 
        {
            if (AreYou(id))
            {
                return this;

            }
            else if (_inventory.HasItem(id))
            {
                return (_inventory.Fetch(id));
            }
            return null;

        }

        public Inventory Inventory //read only property 
        {
            get

            { return _inventory; }
        }

    }

}
