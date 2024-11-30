using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using SwinAdventure4;

namespace TestLookCommand
{
    public class Tests
    {
        private LookCommand Look;
        private Player player;
        private Bag bag;

        Item gem;
        Item gun;
        Item katana;

        [SetUp]
        public void Setup()
        {
            Look = new LookCommand();
            player = new Player("Bryan", "Bryan's player");
            gem = new Item(new string[] { "gem" }, "Bryan's gem", "This is a huge gem");
            gun = new Item(new string[] { "gun" }, "Bryan's gun", "This is a powerful gun");
            katana = new Item(new string[] { "katana" }, "Bryan's katana", "This is a sharp katana");
            bag = new Bag(new string[] { "bag" }, "Bryan's bag", "This is a big bag");

            // Add items to the player's inventory
            player.Inventory.Put(gem);
            player.Inventory.Put(bag);

            // Add items to the bag
            bag.Inventory.Put(gun);
            bag.Inventory.Put(katana);
        }

        [Test]
        public void Lookatme()
        {
            // Test looking at the player's inventory
            string Output = Look.Execute(player, new string[] { "look", "at", "inventory" });
            Assert.AreEqual(player.FullDescription, Output);
        }

        [Test]
        public void Lookatgem()
        {
            string Output = Look.Execute(player, new string[] { "look", "at", "gem" });
            Assert.AreEqual(gem.FullDescription, Output);
        }

        [Test]
        public void LookatUnk()
        {
            player.Inventory.take("gem");
            string Output = Look.Execute(player, new string[] { "look", "at", "gem" });
            Assert.AreEqual("Couldn't Find", Output);
        }

        [Test]
        public void LookatGemInMe()
        {
            
            string Output = Look.Execute(player, new string[] { "look", "at", "gem", "in", "me" });
            Assert.AreEqual (gem.FullDescription, Output);
        }

        [Test]
        public void LookatgemInBag()
        {
            bag.Inventory.Put(gem);
            string Output = Look.Execute(player, new string[] { "look", "at", "gem", "in", "bag" });
            Assert.AreEqual(gem.FullDescription, Output);
        }

        [Test]
        public void LookAtGeminNobag()
        {
            String Output = Look.Execute(player, new string[] { "look", "at", "gem", "in","bag" });
            String expected = $"Couldn't Find";
            Assert.AreEqual(expected, Output);
        }

        [Test]
        public void LookatNoGeminBag()
        {
            string Output = Look.Execute(player, new string[] { "look", "at", "gem", "in", "bag" });
            string expected = $"Couldn't Find";
            Assert.AreEqual(expected , Output);

        }

        [Test]
        public void TestInvalidLook()
        {
            Assert.AreEqual("I don't know how to look like that", Look.Execute(player, new string[] { "look", "around" }));
            Assert.AreEqual("What do you want to look at?", Look.Execute(player, new string[] { "look", "for", "gem" }));
            Assert.AreEqual("Error in look input",  Look.Execute(player, new string[] { "find", "gem" }));
        }
    }
}
