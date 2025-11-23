using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    abstract internal class BaseClass
    {

        internal void TaskA()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Part A");
            Console.WriteLine("---------------------");
            Console.WriteLine("Output:");
            ResolutionTaskA();
        }

        internal void TaskB()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Part B");
            Console.WriteLine("---------------------");
            Console.WriteLine("Output:");
            ResolutionTaskB();
        }

        abstract internal void ResolutionTaskA();
        abstract internal void ResolutionTaskB();
    }
}
