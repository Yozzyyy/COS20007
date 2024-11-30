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
    public class Path : GameObject
    {
       private bool _isblocked;

        Location _source, _destination;

        public Path(string[] idents, string name, string desc, Location source, Location destination) : base(idents, name, desc)
        {
            _source = source;
            _destination = destination;
            _isblocked = false;

            AddIdentifier("path");
            foreach (string s in name.Split(" "))
            {
                AddIdentifier(s);
            }

        }

        public Location Destination
        {
            get { return _destination; }
        }

        public override string ShortDescription
        {
            get { return Name; }
        }

        public bool IsBlocked
        {
            get { return _isblocked; }
            set { _isblocked = value; }
        }

    }
}
