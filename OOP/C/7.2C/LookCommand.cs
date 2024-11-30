using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SwinAdventure4
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "Look" })
        {

        }

        public override string Execute(Player p, string[] text)
        {
            IhaveInv _container;
            string _itemid;
            string error = "Error in look input.";

            if (text[0].ToLower() != "look")
                return error;

            switch (text.Length)
            {
                case 1:
                    _container = p;
                    _itemid = "location";
                    break;

                case 3:
                    if (text[1].ToLower() != "at")
                        return "What do you want to look at?";
                    _container = p;
                    _itemid = text[2];
                    break;

                case 5:
                    _container = FetchContainer(p, text[4]);
                    if (_container == null)
                        return "Could not find " + text[4];
                    _itemid = text[2];
                    break;

                default:
                    return error;
            }
            return LookAtLn(_itemid, _container);
        }


        private IhaveInv FetchContainer(Player p, string ContainerId) //use ihaveInv fetch from thr
        {
            return p.Locate(ContainerId) as IhaveInv; 
        }

        private string LookAtLn(string thingId, IhaveInv container)
        {
            GameObject item = container.Locate(thingId) as GameObject;
            if (item != null)
            {
                if (item is Bag bag)
                {
                    StringBuilder contentsDescription = new StringBuilder(item.FullDescription);
                    contentsDescription.Append("\nIt contains:\n");
                    contentsDescription.Append(bag.Inventory.ItemList); // Use ItemList property here

                    return contentsDescription.ToString();
                }
                return item.FullDescription;
            }
            return "Couldn't find";
        }


    }
}
