using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure4
{
    public class PutCommand : Command
    {
        public PutCommand() : base(new string[] { "put", "drop" }) { }
        public override string Execute(Player player, string[] text)
        {
            if (text.Length < 2)
            {
                return "What do you want to put?";
            }

            string itemName = text[1];

            if (text.Length > 3 && text[2].ToLower() == "in")
            {
                string containerName = text[3];
                GameObject containerObj = player.Locate(containerName);

                if (containerObj is IhaveInv container)
                {
                    Item item = player.Inventory.Fetch(itemName);

                    if (item != null)
                    {
                        player.Inventory.take(itemName);
                        container.Inventory.Put(item);
                        return $"You put the {item.Name} in the {containerObj.Name}.";
                    }
                    else
                    {
                        return $"You do not have {itemName} in your inventory.";
                    }
                }
                else
                {
                    return $"{containerName} is not a container.";
                }
            }
            else
            {
                Item item = player.Inventory.Fetch(itemName);

                if (item != null)
                {
                    player.Inventory.take(itemName);
                    player.Location.Inventory.Put(item);
                    return $"You dropped the {item.Name} in the room.";
                }
                else
                {
                    return $"You do not have {itemName} in your inventory.";
                }
            }
        }
    }
}