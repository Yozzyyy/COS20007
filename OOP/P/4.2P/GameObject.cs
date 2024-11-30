using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure2
{
    public class IdentifiableObject : Identifiable_Object
    {
        private string _description, _name;

        public IdentifiableObject(string[] idents) : base(idents)
        {
        }

        public IdentifiableObject(string[] idents, string name, string desc) : base(idents)
        {
            _name = name;
            _description = desc;

        }
        public string Name
        {
            get { return _name; }

        }
        virtual public string FullDescription
        {
            get
            {
                return _description;
            }
        }
        public string ShortDescription
        {
            get
            {
                return $"{_name} ({FirstId})";

            }


        }
    }
}

