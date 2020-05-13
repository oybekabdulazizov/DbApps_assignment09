using System;
using System.Linq;

namespace Project01
{
    class Program
    {
        public static void Main(string[] args)
        {
            var sample = new LinqSamples();
            var list = LinqSamples.Emps.ToList();
            list.ForEach(i => Console.WriteLine(i));
            Console.WriteLine("======================================================================");
            //sample.Task1();
            //sample.Task2();
            //sample.Task3();
            //sample.Task4();
            //sample.Task5();
            //sample.Task6();
            //sample.Task7();
            // sample.Task8();
            // sample.Task9();
            sample.Task10();
            sample.Task11();
            sample.Task12();
        }
    }
}
