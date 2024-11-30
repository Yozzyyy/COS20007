using counterclass;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using System.Reflection;
using clockclass;

namespace counterclass
{
    public class program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            int i;

            for (i = 0; i < 86400; i++)//86400 is the total seconds in a day 
            {
                Thread.Sleep(100);// value inside is the millieseconds 
                Console.Clear();//erase previous value and display new value 
                clock.tick(); //tick with clock.cs
                Console.WriteLine(clock.CurrentTime());//write the currenttime function from clock.cs

            }
        }

    }
}
    


//printing counter values 
//PrintCounter(myCounters); 
//prints the current state of all counters. 
//Since myCounters[0] and myCounters[2] are the same object, 
//they will have the same Tick value (10). myCounters[1] will
//have a Tick value of 15.

//PrintCounter(myCounters);
//prints the current state of all counters. 
//Since myCounters[0] and myCounters[2] are the same object, 
//they will have the same Tick value (10). myCounters[1] will have a Tick value of 15.

//Printing the Counter Values Again:
//PrintCounter(myCounters); prints the updated state. 
//Now, myCounters[0] and myCounters[2] will show a Tick value of 0, 
//while myCounters[1] remains at 15.Printing the Counter Values Again:


// Counter[] myCounters = new Counter[3]; we first call a new array list which is myCounters
//myCounters[0] = new Counter("Counter 1"); new object which is to store "Counter 1"
//myCounters[1] = new Counter("Counter 2"); new object which is to store "counter 2"
//myCounters[2] = myCounters[0]; each object created will be stored within the array since our current array is empty 



