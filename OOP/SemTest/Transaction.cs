using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterTest1
{
    public class Transaction : Thing
    {
       
        private float _amount;

        public Transaction(string number, string name, decimal amount) : base(number, name)
        {
            _amount = (float)amount;
        }
        public override void Print()
        {
            Console.WriteLine($"#{Number}, {Name}, ${_amount}");
            
        }
        public override Decimal Total()
        {
            
            return (decimal)_amount;
        }
        

    }
}
