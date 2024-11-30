using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SwinAdventure4;


namespace IdentifiableObjectTestingLocation
{

    public class TestLocation
    {
        Player p = new Player("Anh", "This is Anh");
        Location l = new Location("MyRoom", "This is my room");
        Item sword = new Item(new string[] { "sword" }, "a sword", "this is a sword");

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestLookCommand()
        {
            p.Location = l;
            bool actual = l.AreYou("Location");
            Assert.IsTrue(actual);
        }
        [Test]
        public void TestNotLookCommand()
        {
            p.Location = l;
            bool actual = l.AreYou("hi");
            Assert.IsFalse(actual);
        }

        [Test]
        public void TestPlayerHasLocation()
        {
            p.Location = l;
            GameObject expect = l;
            GameObject actual = p.Locate("location");
            Assert.AreEqual(expect, actual);
        }

        [Test]
        public void TestLocationLocateTest()
        {
            l.Inventory.Put(sword);
            GameObject expect = sword;
            GameObject actual = l.Locate("sword");
            Assert.AreEqual (expect, actual);
        }

    }
}