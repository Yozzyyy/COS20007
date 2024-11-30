using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    internal class Message
    {
        private string _text;

        public Message(string text)
        {
            _text = text; //we intialize our text to _text so from a public to private
        }
        public void Print()
        {
            Console.WriteLine(_text); //to display _text from private string
        }
    }
}
