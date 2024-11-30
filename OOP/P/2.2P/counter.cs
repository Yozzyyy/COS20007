using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace counterclass
{
    public class counter
    {
        private int _count;
        private string _name; //declare as private class here


        public counter(string name) //intialize the variable _name and _count set value 
        {
            _name = name;
            _count = 0;

        }
        public void increment() //this code of line helps to do increment to our counter +1 per tick
        {
            _count++; //+1
        }
        public void Reset() //this code meanwhile helps reset the counter to 0 
        {
            _count = 0;//set 0
        }
        public string Name //declare the variable as public class so we are able to call the variable
        {
            get 
            {
                return _name; //call the variable _name to use for set value below
            }
            set
            {
                _name = value; //transfer the value to our _name
            }

        }
        public int Tick
        {
            get
            {
                return _count; //per tick is based on our increment in _count++ so now we call the variable again to be used
            }
        }


    }

}
