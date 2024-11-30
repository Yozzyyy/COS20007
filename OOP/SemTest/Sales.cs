using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterTest1
{
    public class Sales
    {
        private List<Thing> _orders;
     
        public Sales()
        {
            _orders = new List<Thing>();
        }
        public void Add(Thing thing) //merge of Addbatch and AddTransaction
        {
            _orders.Add(thing);
        }
        public void PrintOrders()
        {
            decimal totalSales = 0;
            Console.WriteLine("Sales: ");

            foreach (var item in _orders)
            {
                item.Print();
                totalSales += item.Total();

            }
            Console.WriteLine($"Total: ${totalSales}");

        }

    }
}
