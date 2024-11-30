using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SwinAdventure4;

namespace IdentifiableObjectTestingPath

{
    public class PathTest
    {
        Player _testPlayer;
        Location _testRoomA;
        Location _testRoomB;
        SwinAdventure4.Path _testPath;

        [Test]
        public void TestPathLocation()
        {
            _testPlayer = new Player("Danny", "The Player!");

            _testRoomA = new Location("Room A", "Room A");
            _testRoomB = new Location("Room B", "Room B");

            _testPlayer.Location = _testRoomA;
            _testPath = new SwinAdventure4.Path(new string[] { "north" }, "Door", "A test door", _testRoomA, _testRoomB);
            _testRoomA.AddPath(_testPath);

            Location _expected = _testRoomB;
            Location _actual = _testPath.Destination;

            Assert.AreEqual(_expected, _actual);
        }

        [Test]
        public void TestPathName()
        {
            _testPlayer = new Player("Danny", "The Player!");

            _testRoomA = new Location("Room A", "Room A");
            _testRoomB = new Location("Room B", "Room B");

            _testPlayer.Location = _testRoomA;
            _testPath = new SwinAdventure4.Path(new string[] { "north" }, "Door", "A test door", _testRoomA, _testRoomB);
            _testRoomA.AddPath(_testPath);

            string _expected = "A test door";
            string _actual = _testPath.FullDescription;

            Assert.AreEqual(_expected, _actual);
        }

        [Test]
        public void TestLocatePath()
        {
            _testPlayer = new Player("Danny", "The Player!");

            _testRoomA = new Location("Room A", "Room A");
            _testRoomB = new Location("Room B", "Room B");

            _testPlayer.Location = _testRoomA;
            _testPath = new SwinAdventure4.Path(new string[] { "north" }, "Door", "A test door", _testRoomA, _testRoomB);
            _testRoomA.AddPath(_testPath);

            GameObject _expected = _testRoomA.Locate("north");
            GameObject _actual = _testPath;

            Assert.AreEqual(_expected, _actual);
        }
    }
}