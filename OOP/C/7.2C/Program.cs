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

            //setting a location
            Location Myroom = new Location("MyRoom", $"This is my Room");
            player.Location = Myroom;
            //Setting up list of items
            Location GamingRoom = new Location("GamingRoom", "Gaming Room");
            player.Location = GamingRoom;
            //set gamingroom
            Location Kitchen = new Location("Kitchen", "Kitchen");
            player.Location = Kitchen;
            //set Kitchen
            Location Porch = new Location("Porch", "Car Porch");
            player.Location= Porch;

            Item bed = new Item(new string[] { "Bed" }, "a Bed", "This is a Bed");
            Item PC = new Item(new string[] { "PC" }, "a PC", "This is a PC");
            Item Nintendo = new Item(new string[] { "Nintendo" }, "a Nintendo", "This is a Nintendo");
            Item closet = new Item(new string[] { "closet" }, "a closet", "This is a closet");
            Item Dishwasher = new Item(new string[] { "Dishwasher" }, "a Dishwasher", "This is a Dishwasher");
            Item Stove = new Item(new string[] { "Stove" }, "a stove", "This is a Stove");
            Item plants = new Item(new string[] { "plants" }, "some plants", "This is some plants");
            Item ShoeRack = new Item(new string[] { "Shoe Rack" }, "a Shoe Rack", "This is a Shoe Rack");

            Myroom.Inventory.Put(bed);//Myroom
            Myroom.Inventory.Put(closet);

            GamingRoom.Inventory.Put(PC);//gamingroom
            GamingRoom.Inventory.Put(Nintendo);

            Kitchen.Inventory.Put(Dishwasher);//kitchen
            Kitchen.Inventory.Put(Stove);

            Porch.Inventory.Put(plants); //porch
            Porch.Inventory.Put(ShoeRack);


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
                else
                {
                    LookCommandExe(l, _input, player);
                }

            }


        }


    }
}