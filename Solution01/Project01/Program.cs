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
            Console.WriteLine();
            sample.Task1();

            //sample.Task2();
        }
    }
}
