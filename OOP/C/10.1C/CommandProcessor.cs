using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure4
{
    public class CommandProcessor : Command
    {
        List<Command> _commands;

        public CommandProcessor() : base(new string[] { "command" })
        {
            _commands = new List<Command>();
            _commands.Add(new LookCommand());
            _commands.Add(new Move());
            _commands.Add(new PickUpCommand());
            _commands.Add(new PutCommand());
        }

        public override string Execute(Player p, string[] text)
        {
            foreach (Command cmd in _commands)
            {
                if (cmd.AreYou(text[0].ToLower()))
                {
                    return cmd.Execute(p, text);
                }
            }
            return "Error in command input. ";
        }
    }
}
