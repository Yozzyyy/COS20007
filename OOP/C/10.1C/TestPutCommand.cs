using NUnit.Framework;
using SwinAdventure4;

namespace SwinAdventureTests
{
    [TestFixture]
    public class PutCommandTests
    {
        private Player _player;
        private Bag _bag;
        private Item _nintendo;

        [SetUp]
        public void Setup()
        {
            // Initialize player, bag, and item
            _player = new Player("John", "A brave adventurer");
            _player.Location = new Location("Campsite", "A peaceful campsite"); // Initialize location
            _bag = new Bag(new string[] { "bag" }, "Adventure Bag", "A sturdy bag for carrying items");
            _nintendo = new Item(new string[] { "nintendo" }, "Nintendo", "A gaming console");

            // Add the item to the player's inventory
            _player.Inventory.Put(_nintendo);
        }

        [Test]
        public void TestPutItemInContainer()
        {
            var putCommand = new PutCommand();

            // Place the bag in the player's location
            _player.Location.Inventory.Put(_bag);

            // Command to put the Nintendo in the bag
            string result = putCommand.Execute(_player, new string[] { "put", "nintendo", "in", "bag" });

            // Assert that the Nintendo is now in the bag
            Assert.AreEqual("You put the Nintendo in the Adventure Bag.", result);
            Assert.IsNull(_player.Inventory.Fetch("nintendo"));
            Assert.IsNotNull(_bag.Inventory.Fetch("nintendo"));
        }

        [Test]
        public void TestPutItemNotInInventory()
        {
            var putCommand = new PutCommand();

            // Attempt to put an item not in the player's inventory
            string result = putCommand.Execute(_player, new string[] { "put", "sword", "in", "bag" });

            // Assert the correct error message is returned
            Assert.AreEqual("bag is not a container.", result);
        }

        [Test]
        public void TestPutItemInInvalidContainer()
        {
            var putCommand = new PutCommand();

            // Attempt to put an item in a non-container object
            string result = putCommand.Execute(_player, new string[] { "put", "nintendo", "in", "rock" });

            // Assert the correct error message is returned
            Assert.AreEqual("rock is not a container.", result);
        }
    }
}
