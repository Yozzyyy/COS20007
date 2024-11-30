using counterclass;//link references to Counter.cs
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clockclass
{
    public class Clock
    {
        private Counter _hours;
        private Counter _minutes;
        private Counter _second;

        public Clock()
        {
            _second = new Counter("seconds"); //declare second object
            _minutes = new Counter("minutes");//declare minute object
            _hours = new Counter("hours");//declare hours object
        }
            public void tick() //ticks per seconds,minute and hour
            {
                _second.increment(); //increment for second till reaches 59 then reset back to 0
                if (_second.Tick > 59) //till tick 59 
                {
                    _minutes.increment();//increment for minute till reaches 59 then reset back to 0
                    _second.Reset();//reset back value
                    if (_minutes.Tick > 59)
                    {
                        _hours.increment();//increment for hours till reaches 59 then reset back to 0
                        _minutes.Reset();//reset back value
                        if (_hours.Tick > 23) //increment hour still 23:59
                        {
                            ResetTime();//then reset back value
                        }
                    }
                }
            }

            public void ResetTime()// helps reset the time back to 0 
            {
                _hours.Reset(); //call back function from clock.cs which reset back count to 0
                _minutes.Reset();
                _second.Reset();

            }
            public void Settime(String s)
            {
                string[] array = s.Split(":"); //in between array set the : symbol 
                                               //arrange the the array into a sequenced method hh:mm:ss 

                _hours = new Counter("hours", int.Parse(array[0])); //first array value
                _minutes = new Counter("minutes", int.Parse(array[1]));//second array value
                _second = new Counter("second", int.Parse(array[2]));//third array value

            }
            public string CurrentTime()
            {
                return $"{_hours.Tick:D2}:{_minutes.Tick:D2}:{_second.Tick:D2}"; //now return all array list 
            }


        
    }


}
