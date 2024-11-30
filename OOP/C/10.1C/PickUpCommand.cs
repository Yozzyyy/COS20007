using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure4
{
    public class PickUpCommand : Command
    {
        public PickUpCommand() : base(new string[] { "pickup", "take" }) { }

        public override string Execute(Player player, string[] text)
        {
            // Validate command format
            if (text.Length < 2)
            {
                return "What do you want to take?";
            }

            string itemName = text[1];

            // Handle "take [item] from [container]"
            if (text.Length > 3 && text[2].ToLower() == "from")
            {
                string containerName = text[3];
                GameObject containerObj = player.Locate(containerName);

                if (containerObj is IhaveInv container)
                {
                    Item item = container.Inventory.Fetch(itemName);

                    if (item != null)
                    {
                        container.Inventory.take(itemName); // Remove item from the container
                        player.Inventory.Put(item); // Add item to the player's inventory
                        return $"You took the {item.Name} from the {containerObj.Name}.";
                    }
                    else
                    {
                        return $"The {itemName} is not in the {containerName}.";
                    }
                }
                else
                {
                    return $"{containerName} is not a container.";
                }
            }
            else if (text.Length == 2) // Handle "take [item]" directly from the current location
            {
                Item item = player.Location.Inventory.Fetch(itemName);

                if (item != null)
                {
                    player.Location.Inventory.take(itemName); // Remove item from the location
                    player.Inventory.Put(item); // Add item to the player's inventory
                    return $"You took the {item.Name}.";
                }
                else
                {
                    return $"The {itemName} is not here.";
                }
            }
            else
            {
                return "Invalid command format. Use: take [item] or take [item] from [container].";
            }
        }
    }
}
