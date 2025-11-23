using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2015
{
    internal class _03 : BaseClass
    {
        char[] input;
        string path = "";

        internal void Solve()
        {
            path = @"..\..\..\input\2015-03.txt";

            Check();
            TaskA();
            TaskB();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Solve 03 End");
        }

        internal void Check()
        {
            Console.WriteLine("----------------------------------------");
            input = File.ReadAllText(path).ToCharArray();
            Console.WriteLine("Input:");
            Console.WriteLine(input);
            Console.WriteLine("Input Lenght: " + input.Length.ToString());

        }

        override internal void ResolutionTaskA()
        {
            HashSet<string> set = new HashSet<string>();
            int x = 0, y = 0;

            // Starting Location
            set.Add(x.ToString() + ":" + y.ToString());

            foreach (char c in input) {
                switch (c) {
                    case '^': { y += 1; break; }
                    case 'v': { y -= 1; break; }
                    case '>': { x += 1; break; }
                    case '<': { x -= 1; break; }
                    default: { Console.WriteLine("Error"); break; }
                }
                set.Add(x.ToString() + ":" + y.ToString());
            }
            Console.WriteLine("Count of entries in hashmap: " + set.Count().ToString());
        }

        override internal void ResolutionTaskB()
        {
            HashSet<string> set = new HashSet<string>();
            int x1 = 0, y1 = 0;
            int x2 = 0, y2 = 0;

            // Starting Location
            set.Add(x1.ToString() + ":" + y1.ToString());
            set.Add(x2.ToString() + ":" + y2.ToString());

            bool turnSwap = false;
            foreach (char c in input)
            {
                if (turnSwap)
                {
                    switch (c)
                    {
                        case '^': { y1 += 1; break; }
                        case 'v': { y1 -= 1; break; }
                        case '>': { x1 += 1; break; }
                        case '<': { x1 -= 1; break; }
                        default: { Console.WriteLine("Error"); break; }
                    }
                    set.Add(x1.ToString() + ":" + y1.ToString());
                }
                else
                {
                    switch (c)
                    {
                        case '^': { y2 += 1; break; }
                        case 'v': { y2 -= 1; break; }
                        case '>': { x2 += 1; break; }
                        case '<': { x2 -= 1; break; }
                        default: { Console.WriteLine("Error"); break; }
                    }
                    set.Add(x2.ToString() + ":" + y2.ToString());
                }
                turnSwap = !turnSwap;
            }
            Console.WriteLine("Count of entries in hashmap: " + set.Count().ToString());
        }
    }
}
