using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SemesterTest1
{
    public class Batch : Thing
    {
        
        private List<Thing> _items;

        public Batch(string number,string name) :base(number,name)
        {
            
            _items = new List<Thing>();
        }

        public void Add(Thing thing)
        {
            _items.Add(thing);
        }
        public override void Print()
        {
            Console.WriteLine($"Batch Sales: #{Number}, {Name}");

            decimal batchTotal = 0;

            if (_items.Count == 0)
            {
                Console.WriteLine("Empty Orders.");
            }
            else
            {
                foreach (var item in _items)
                {
                    item.Print(); //print each line from items
                    batchTotal += item.Total();
                }
                Console.WriteLine($"Total: ${batchTotal}");
            }

        }
        public override Decimal Total()
        {
            Decimal result = 0;
            foreach (Thing thing in _items)
            {
                result += thing.Total(); //calling the thing.cs total() function             
            }
            return result;
            
        }
        

    }
}
