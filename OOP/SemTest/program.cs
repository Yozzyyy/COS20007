using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace SemesterTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            Sales sales = new Sales(); //Sales objects


            Batch batch1 = new Batch("2024x00001", "CompSci Books"); //batch 1 
            Batch batch2 = new Batch("2024x00002", "Fantasy Books"); //Batch 2 
            Batch batch3 = new Batch("2024x00003", "compiler"); //single order batch 
            
            Batch emptybatch = new Batch("00-00003", "Empty Order"); // empty batch
            

            Transaction trans = new Transaction("1", "Deep Learning in Python", 67.90m); // batch 1
            Transaction trans1 = new Transaction("2", "C# in Action", 54.10m);
            Transaction trans2 = new Transaction("2", "Design Patterns", 129.75m);

            Transaction trans3 = new Transaction("00-0002", "Hunger Games 1-3", 45.00m); // this is for batch 2 
            Transaction trans4 = new Transaction("00-0003", "Learning Blender", 56.90m);

            batch1.Add(trans); //adding the trans, trans 1 and 2 into batch 1
            batch1.Add(trans1);
            batch1.Add(trans2);
            sales.Add(batch1); //sales for batch1

            batch2.Add(trans3); //adding the trans 3 and 4 in to batch 2
            batch2.Add(trans4);

            batch3.Add(batch2); // nested batch by adding the batch2 into the batch3
            sales.Add(batch3); //sales for batch3

            sales.Add(emptybatch); // sales for empty batch

            Transaction singleTransaction = new Transaction("00-0001", "Compilers", 134.60m); //single transaction orders to sales object
            sales.Add(singleTransaction); //adding singletransaction into the sales

            sales.PrintOrders(); //print everything from sales


            //4 batches in total
            //Batch1/2, single transaction batch, nested batch and empty batch



        }
    }
}

