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

            Location GamingRoom = new Location("GamingRoom", "Gaming Room");
            Path MyroomtoGamingRoom = new Path(new string[] { "north" }, "Door", "Travel through door", Myroom, GamingRoom); //create a link from Myroom to GamingRoom (north of MyRoom)
            Path GamingRoomtoMyroom = new Path(new string[] { "south" }, "Door", "Travel through door", GamingRoom, Myroom);
            Myroom.AddPath(MyroomtoGamingRoom);// add the path
            GamingRoom.AddPath(GamingRoomtoMyroom);

            Location Kitchen = new Location("Kitchen", "Kitchen");
            Path MyRoomToKitchen = new Path(new string[] { "east" }, "Door", "Travel through door", Myroom, Kitchen); //create a link from Myroom to GamingRoom (north of MyRoom)
            Path KitchenToMyRoom = new Path(new string[] { "west" }, "Door", "Travel through door", Kitchen, Myroom);
            Myroom.AddPath(MyRoomToKitchen);
            Kitchen.AddPath(KitchenToMyRoom);// add the path

            Location Porch = new Location("Porch", "Car Porch");
            Path KitchenToPorch = new Path(new string[] { "north" }, "Door", "Travel through door", Kitchen, Porch); //create a link from Myroom to GamingRoom (north of MyRoom)
            Path PorchToKitchen = new Path(new string[] { "south" }, "Door", "Travel through door", Porch, Kitchen); //way back to kitchen
            Kitchen.AddPath(KitchenToPorch);
            Porch.AddPath(PorchToKitchen);// add the path



            //Setting up list of items

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

            Bag bag1 = new Bag(new string[] { $"potatobag" }, $"potato's bag", $"This is bag in the garden"); //create a bag 
            Porch.Inventory.Put(bag1); //place item in bag

            Item potato = new Item(new string[] { "potato" }, "some potato", "This is potato");
            bag1.Inventory.Put(potato);

            Item diamond = new Item(new string[] { "diamond" }, "a diamond", "This is a diamond");
            Item Phone = new Item(new string[] { "Phone" }, "a phone", "This is a phone");
            bag.Inventory.Put(Phone);
            bag.Inventory.Put(diamond);

            
            Command c = new CommandProcessor();
           

            while (true)
            {
                Console.Write("Command: ");
                string _input = Console.ReadLine();
                string[] split;
                split = _input.Split(' ');

       
                if (_input.ToLower() != "quit")
                {
                    Console.WriteLine(c.Execute(player, _input.Split()));
                }

                else if (_input == "Inventory")
                {
                    Console.WriteLine(player.Inventory.ItemList);
                }

                else
                {
                    Console.WriteLine("Bye");
                    Console.ReadLine();
                    break;
                }

            }


        }


    }
}