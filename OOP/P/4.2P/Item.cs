using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SwinAdventure2
{
    public class Item : IdentifiableObject
    {
        public Item(string[] idents, string name, string desc) : base(idents, name, desc) //initialise the item lists
        {

        }
    }
}
