using SwinAdventure2;
using NUnit.Framework;


namespace IdentifiableObjectTesting
{
    public class Objecttesting
    {
        private IdentifiableObject _testObject;
        private string _teststring;
        private string[] _teststringArray;

        private IdentifiableObject _testObject_emp;
        private string _teststring_emp;
        private string[] _teststringArray_emp;


       

        [SetUp]
        public void Setup()
        {
            _teststring = "Anna";
            string[] _teststringArray = new string[] { "Anna", "Bryan" };
            _testObject = new IdentifiableObject(_teststringArray);
            _testObject.AddIdentifier(_teststring);

            _teststring_emp = "";
            _teststringArray_emp = new string[] { };
            _testObject_emp = new IdentifiableObject(_teststringArray_emp);
            _testObject_emp.AddIdentifier(_teststring_emp);

        }

        [Test]
        public void TestAreYou()
        {

            Assert.IsTrue(_testObject.AreYou(_teststring));

        }

        [Test]
        public void TestNotAreYou()
        {
            Assert.IsFalse(_testObject.AreYou("Jack"));

        }

        [Test]
        public void TestCaseSensitive()
        {
            Assert.IsTrue(_testObject.AreYou("Anna"));
        }

        [Test]
        public void TestFirstId()
        {
            Assert.AreEqual("anna", _testObject.FirstId);
            Assert.AreNotEqual("Jack", _testObject.FirstId);
        }

        [Test]
        public void TestFirstIdWithNoId()
        {

            Assert.AreEqual("", _testObject_emp.FirstId);  //assert that firstId is equal to ""(null) if no id
        }

        [Test]
        public void TestAddId()
        {
            _testObject.AddIdentifier("Max");
            _testObject.AddIdentifier("Andrew");
            Assert.IsTrue(_testObject.AreYou("Max"));
            Assert.IsTrue(_testObject.AreYou("Andrew"));
        }
    }
}
