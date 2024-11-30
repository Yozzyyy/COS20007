using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SwinAdventure2;

namespace IdentifiableObjectTesting
{
    public class TestItem
    {
        Item Gun = new Item(new string[] { "Gun" }, "a gun", "this is a Gun");
        Item Katana = new Item(new string[] { "Katana" }, "a Katana", "this is a katana");


        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestItemIdentifiable()
        {
            var result = Gun.AreYou("Gun");
            Assert.IsTrue(result);

            var result1 = Katana.AreYou("Katana");
            Assert.IsTrue(result1);


        }

        public void ShortDescription()
        {
            Assert.AreEqual(Gun.ShortDescription, "This is a legendary gun");
            Assert.AreNotEqual(Katana.ShortDescription, "This is a legendary Katana");
        }

        public void FullDescription()
        {
            Assert.AreEqual(Gun.FullDescription, "This gun is crafted with the finest Gun powder in the market");
            Assert.AreNotEqual(Katana.FullDescription, "This Katana is forged by the finest swordsmiths");
        }
    }
}