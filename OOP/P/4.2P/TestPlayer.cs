using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using SwinAdventure2;

namespace IdentifiableObjectTesting
{
    public class Testplayer
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

        public void locateNon()
        {
            var me = player.Locate("Me");
            Assert.IsNull(me);

        }
        public void FullDescription()
        {
            player.Inventory.Put(Gun);
            player.Inventory.Put(Katana);
            string ExpectedOutput = "Anna you are carrying a {Gun}" + "Bryan you using a {Katana}";
            Assert.AreEqual(player,FullDescription, ExpectedOutput);

        }
    }
}
