using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure4
{
    public class Move : Command
    {
        public Move() : base(new string[] { "move" })
        {

        }
        public override string Execute(Player p, string[] Text)
        {
            string error = "Error in move input";
            if (Text.Length > 2)
            {
                return "Move Where?";
            }

            String direction = Text[1].ToLower();
            GameObject path = p.Location.Locate(direction);

            if (path is Path targetPath)
            {
                if (!targetPath.IsBlocked)
                {
                    p.Move(targetPath);
                    return $"You have moved {direction} through a {targetPath.Name} to the {p.Location.Name}.\n\n{p.Location.FullDescription}";
                }

                else
                {
                    return $"The Path to the {targetPath.Name} is blocked.";
                }
            }
            return error;
        }
    }
}
