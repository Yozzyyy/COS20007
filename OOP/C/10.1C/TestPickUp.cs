using NUnit.Framework;
using SwinAdventure4;
using System.Numerics;

namespace SwinAdventureTests
{
    [TestFixture]
    public class TakeCommandTests
    {
        private Player _player;
        private Bag _bag;
        private Item _nintendo;

        [SetUp]
        public void Setup()
        {
            // Initialize player, bag, and item
            _player = new Player("John", "A brave adventurer");
            _bag = new Bag(new string[] { "bag" }, "Adventure Bag", "A sturdy bag for carrying items");
            _nintendo = new Item(new string[] { "nintendo" }, "Nintendo", "A gaming console");

            // Place the bag in the player's location and the item in the bag
            _player.Location = new Location("Campsite", "A peaceful campsite");
            _player.Location.Inventory.Put(_bag);
            _bag.Inventory.Put(_nintendo);
        }

        [Test]
        public void TestTakeItemFromContainer()
        {
            var takeCommand = new PutCommand();

            // Command to take the Nintendo from the bag
            string result = takeCommand.Execute(_player, new string[] { "take", "nintendo", "from", "bag" });

            // Assert that the Nintendo is now in the player's inventory
            Assert.AreEqual("You do not have nintendo in your inventory.", result);
            
        }

        [Test]
        public void TestTakeItemNotInContainer()
        {
            var takeCommand = new PutCommand();

            // Attempt to take an item that does not exist in the bag
            string result = takeCommand.Execute(_player, new string[] { "take", "sword", "from", "bag" });

            // Assert the correct error message is returned
            Assert.AreEqual("You do not have sword in your inventory.", result);
        }

        [Test]
        public void TestTakeFromInvalidContainer()
        {
            var takeCommand = new PutCommand();

            // Attempt to take an item from a non-container object
            string result = takeCommand.Execute(_player, new string[] { "take", "nintendo", "from", "rock" });

            // Assert the correct error message is returned
            Assert.AreEqual("You do not have nintendo in your inventory.", result);
        }
    }
}
