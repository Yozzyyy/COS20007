using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure4
{
    public interface IhaveInv
    {
        GameObject Locate(string id);  //From GameObject to be used by LookCommand by creating dependency 
        string Name //read only name
        {
            get; 
        }

    }
}
