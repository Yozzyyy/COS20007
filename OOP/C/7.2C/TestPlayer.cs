
using SwinAdventure4;

namespace IdentifiableObjectTesting
{
    public class TestPlayer
    {
        Player player = new Player("Anna", "A wizard");
        Item Gun = new Item(new string[] { "Gun" }, "a gun", "this is a Gun");
        Item Katana = new Item(new string[] { "Katana" }, "a Katana", "this is a katana");




        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void IdentifiablePlayer()
        {
            Assert.IsFalse(player.AreYou("Me") && player.AreYou("Inventory"));
        }
        [Test]
        public void LocateItem()
        {
            var result = false;
            player.Inventory.Put(Gun);
            var Itemlocate = player.Locate("Gun");
            if (Gun == Itemlocate)
            {
                result = true;
            }
            Assert.IsTrue(result);
        }
        [Test]
        public void locateItself()
        {
            var Me = player.Locate("Me");
            var Invent = player.Locate("Inventory");
            var result = false;

            if (Me == player || Invent == player)
            {
                result = true;
            }
            Assert.IsTrue(result);
            ;


        }
        [Test]
        public void locateNon()
        {
            var me = player.Locate("Me");
            Assert.AreEqual(me, player);

        }
        [Test]
        public void FullDescription()
        {
            player.Inventory.Put(Gun);
            player.Inventory.Put(Katana);
            string ExpectedOutput = "You are Anna, A wizard.\nYou are carrying\na gun (gun)a Katana (katana)";
            Assert.AreEqual(player.FullDescription, ExpectedOutput);

        }
    }
}