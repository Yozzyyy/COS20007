using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SwinAdventure2;

namespace IdentifiableObjectTestingInv
{
    public class TestInventory
    {
        Item Gun = new Item(new string[] { "Gun" }, "a gun", "this is a Gun");
        Item Katana = new Item(new string[] { "Katana" }, "a Katana", "this is a katana");



        [SetUp]

        public void Setup()
        {

        }
        [Test]
        public void TestFindThem()
        {
            Inventory i = new Inventory();
            i.Put(Gun);
            Assert.IsTrue(i.HasItem(Gun.FirstId)); //check first object "gun" if have then is true

        }
        public void TestNotFindItem()
        {
            Inventory i = new Inventory();
            i.Put(Gun);
            Assert.IsFalse(i.HasItem(Katana.FirstId)); //check gun to compare with chosen object in this case is "katana" then IsFalse
        }

        public void TestFetchItem()
        {
            Inventory i = new Inventory();
            i.Put(Gun);
            Item fetchItem = i.Fetch(Gun.FirstId);

            Assert.IsTrue(fetchItem == Gun);
            Assert.IsTrue(i.HasItem(Gun.FirstId));
        }

        public void TestTakenIten()
        {
            Inventory i = new Inventory();
            i.Put(Gun);
            i.take(Gun.FirstId);
            Assert.IsFalse(i.HasItem(Gun.FirstId));
        }

        public void ItemList()
        {
            Inventory i = new Inventory();
            i.Put(Gun);
            i.Put(Katana);
            Assert.IsTrue(i.HasItem(Gun.FirstId));
            Assert.IsTrue(i.HasItem(Katana.FirstId));

            String expectOutput = "a Gun{Gun}" + "a Katana{Katana}";
            Assert.AreEqual(ItemList, expectOutput);
        }
    }

}