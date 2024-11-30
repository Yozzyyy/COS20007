using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using clockclass;

namespace Testing
{
    public class TestClock
    {
        Clock _clock;

        [SetUp]
        public void Setup()
        {
            _clock = new Clock();
        }
        [Test]
        public void TestClockStart()
        {
            Assert.That(_clock.CurrentTime(), Is.EqualTo("00:00:00"));


        }
        [Test]
        public void TestReset()
        {
            int i;
            for (i = 0; i < 86400; i++)
            {
                _clock.tick();
            }
            _clock.ResetTime();
            Assert.That(_clock.CurrentTime(), Is.EqualTo("00:00:00"));

        }
        [TestCase(0, "00:00:00")]
        [TestCase(60, "00:01:00")]
        [TestCase(120, "00:02:00")]
        [TestCase(86340, "23:59:00")]

        public void TestRunning(int tick, string currenttime)
        {
            int i;
            for (i = 0; i < tick; i++)
            {
                _clock.tick();
            }
            Assert.That(_clock.CurrentTime(), Is.EqualTo(currenttime));
        }

        [TestCase("00:01:00", "00:00:59")] //Roll to 1 min
        [TestCase("01:00:00", "00:59:59")] //Roll to 1 hr
        [TestCase("00:00:00", "23:59:59")] //Roll to 1 day

        public void TestClockRollover(string exp, string settime)
        {
            _clock.Settime(settime);
            _clock.tick();
            Assert.That(_clock.CurrentTime(), Is.EqualTo(exp));
        }
    }

}
