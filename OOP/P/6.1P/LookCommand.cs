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
            // Check "look" first, convert to lowercase
            if (text[0].ToLower() != "look")
            {
                return "Error in look input";
            }

            if (text.Length != 3 && text.Length != 5)
            {
                return "I don't know how to look like that";
            }

            if (text[1].ToLower() != "at")
            {
                return "What do you want to look at?";
            }

            if (text.Length == 5 && text[3].ToLower() != "in")
            {
                return "What do you want to look in?";
            }

            // Determine the container (Player or another object)
            IhaveInv container;
            if (text.Length == 3) // "Look at [thing]"
            {
                // Handle "look at me" or "look at inventory"
                if (text[2].ToLower() == "me" || text[2].ToLower() == "inventory")
                {
                    return p.FullDescription; // Return the player's full description
                }
                container = p;
            }
            else // "Look at [thing] in [container]"
            {
                container = FetchContainer(p, text[4]);
                if (container == null)
                {
                    return $"I can't find the {text[4]}";
                }
            }
            return LookAtLn(text[2], container);
        }


        private IhaveInv FetchContainer(Player p, string ContainerId) //use ihaveInv fetch from thr
        {
            return p.Locate(ContainerId) as IhaveInv; 
        }

    private string LookAtLn(string thingId, IhaveInv container)
        {
            GameObject item = container.Locate(thingId) as GameObject; // uses depency from GameObject
            if (item != null)
            {
                return item.FullDescription;
            }
            return "Couldn't Find";

        }
    }
}
