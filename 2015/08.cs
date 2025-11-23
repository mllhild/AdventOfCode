using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2015
{
    internal class _08 : BaseClass
    {
        string[] input;
        string path = "";

        internal void Solve()
        {
            path = @"..\..\..\input\2015-08.txt";

            Check();
            TaskA();
            TaskB();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Solve 08 End");
        }

        internal void Check()
        {
            Console.WriteLine("----------------------------------------");
            input = File.ReadAllLines(path);
            Console.WriteLine("Input:");
            Console.WriteLine(input);
            Console.WriteLine("Input Lenght: " + input.Length.ToString());

        }


        override internal void ResolutionTaskA()
        {
            
        }

        override internal void ResolutionTaskB()
        {
           
        }
    }
}
