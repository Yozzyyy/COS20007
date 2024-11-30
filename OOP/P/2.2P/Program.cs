using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;

namespace counterclass
{
    public class program
    {
        private static void PrintCounter(counter[] counters)//we call the counter.cs into a new variable counters
        {
            foreach (counter c in counters) 
            {
                //Console.WriteLine(c.Name + " is " +c.Tick);
                Console.WriteLine("{0} is {1}", c.Name, c.Tick); //replace {0},{1} and c.Name,c.Tick 

            }
        }

        public static void Main(string[] args)
        {
            counter[] myCounters = new counter[3];
            myCounters[0] = new counter("Counter 1"); //first counter display as gievn
            myCounters[1] = new counter("Counter 2"); //second counter display as given
            myCounters[2] = myCounters[0]; //when myCounters[2] it will call back to counter[0]

            for (int i = 0; i <= 9; i++) //set i till reaches 9 then display next value above the set i value
            {
                myCounters[0].increment(); //use the increment value from counter.cs to increase the i value
            }
            for (int i = 0; i <= 14; i++) //set i till reaches 14 then display next value above the set i value
            {
                myCounters[1].increment(); //use the increment value from counter.cs to increase the i value
            }

            PrintCounter(myCounters); //print the console.WriteLine from the line above
            Console.ReadLine();//read the myCounter input 
            myCounters[2].Reset(); //use the reset function from counter.cs 
            PrintCounter(myCounters); //print again the PrintCounter
            Console.ReadLine(); //read the myCounter input

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


