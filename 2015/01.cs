using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2015
{
    internal class _01 : BaseClass
    {
        char[] input;
        string path = "";

        internal void Solve()
        {
            path = @"..\..\..\input\2015-01.txt";
        
            Check();
            TaskA();
            TaskB();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Solve 01 End");
        }

        internal void Check() {
            Console.WriteLine("----------------------------------------");
            input = File.ReadAllText(path).ToCharArray();
            Console.WriteLine("Input:");
            Console.WriteLine(input);
            Console.WriteLine("Input Lenght: " + input.Length.ToString());
            
        }

        override internal void ResolutionTaskA() {
            int floor = 0;
            foreach (char c in input)
            {
                if (c == '(')
                    floor++;
                else if (c == ')')
                    floor--;
            }
            Console.WriteLine(floor);
        }

        override internal void ResolutionTaskB()
        {
            int floor = 0;
            int counter = 0;
            foreach (char c in input)
            {
                counter++;
                if (c == '(')
                    floor++;
                else if (c == ')')
                    floor--;

                if (floor == -1) 
                    break; 
            }
            Console.WriteLine(counter);
        }
    }
}
