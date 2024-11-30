using SwinAdventure4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SwinAdventure4
{
    public class Program
    {
        static void LookCommandExe(Command l, string Input, Player player)
        {
            Console.WriteLine(l.Execute(player, Input.Split()));
        }

        static void Main(string[] args)
        {
            //Greeting + info
            string name, desc;
            string help = "-look\n\nGetting list of item:\n-look at me\n-look at bag\n\nGetting item description:\nlook at {item}\nlook at {item} in me\nlook at {item} in bag\n\n";
            Console.WriteLine(help);



            //Setting up player

            Console.Write("Setting up player:\nPlayer Name: ");
            name = Console.ReadLine();
            Console.Write("Player Description: ");
            desc = Console.ReadLine();
            Player player = new Player(name, desc);

            

            //Setting up list of items

            Item shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel"); // declare two items
            Item sword = new Item(new string[] { "sword" }, "a sword", "This is a sword");
            player.Inventory.Put(shovel); //put 2 item in iventory
            player.Inventory.Put(sword);

           


            Bag bag = new Bag(new string[] { $"bag" }, $"{player.Name}'s bag", $"This is {player.Name}'s bag"); //create a bag 
            player.Inventory.Put(bag); //place item in bag
            Item diamond = new Item(new string[] { "diamond" }, "a diamond", "This is a diamond");
            bag.Inventory.Put(diamond);

            string _input;
            Command l = new LookCommand();

  

            while (true)
            {
                Console.Write("Command: ");
                _input = Console.ReadLine();
                if (_input == "quit")
                {
                    break;
                }
                else if (_input == "help")
                {
                    Console.Write(help);
                }
                else if (_input == "Inventory")
                {
                    Console.WriteLine(player.Inventory.ItemList);
                }
                else
                {
                    LookCommandExe(l, _input, player);
                }
                }

            }


        }


    }
