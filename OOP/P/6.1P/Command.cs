using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure4
{
    public abstract class Command : Identifiable_Object //inherit directly from identifiableObject
    {

        public Command(string[] idents) : base(idents)
        {

        }
        public abstract string Execute(Player p, string[] Text); // abstract to override in LookCommand




    }
}
