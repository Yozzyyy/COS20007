using HelloWorld;

namespace Helloworld
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Message greetings;
            Message[] messages = {
                new Message("hello there Tony"),
                new Message("Wassup there Batman"),
                new Message("yoo how are you Julie!"),
                new Message("Long time no see Dio"),
                new Message("Well nice to meet you!"),
            };

            string name;
            greetings = new Message("hello");
            greetings.Print();

            while (true)
            {
                Console.WriteLine("Enter name: ");
                name = Console.ReadLine().Trim();

                if (name.ToLower() == "tony")  // Compare using lowercase
                {
                    messages[0].Print();
                }
                else if (name.ToLower() == "batman")
                {
                    messages[1].Print();
                }
                else if (name.ToLower() == "julie")
                {
                    messages[2].Print();
                }
                else if (name.ToLower() == "dio")
                {
                    messages[3].Print();
                }
                else
                {
                    messages[4].Print();
                }
            }
        }
    }
}
