using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2015
{
    internal class _02 : BaseClass
    {
        string[] input;
        string path = "";

        internal void Solve()
        {
            path = @"..\..\..\input\2015-02.txt";

            Check();
            TaskA();
            TaskB();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Solve 02 End");
        }

        internal void Check()
        {
            Console.WriteLine("----------------------------------------");
            input = File.ReadAllLines(path);
            Console.WriteLine("Input:");
            Console.WriteLine(input);
            Console.WriteLine("Input Lenght: " + input.Length.ToString());

        }

        public struct Present
        {
            int l,w,h;
            public Present(int _l, int _w, int _h) { l = _l; w = _w; h = _h; }
            public int wrapPaperNeeded()
            {
                int bonusPaper = Math.Min(l * w, Math.Min(w*h, h * l));
                int basePaper = 2*(l * w + w * h + h * l);
                return bonusPaper + basePaper;
            }
            public int ribbonNeeded()
            {
                int smallestPerimeter = Math.Min(2 * (l + w), Math.Min(2 * (h + l), 2 * (w + h)));
                int ribbon = l * h * w;
                return smallestPerimeter + ribbon;
            }
        }

        override internal void ResolutionTaskA()
        {
            int totalWrappingPaper = 0;
            List<Present> presents = new List<Present>();
            foreach (string line in input)
            {
                string[] split = line.Split('x');
                try { presents.Add(
                    new Present(
                        Int32.Parse(split[0]),
                        Int32.Parse(split[1]),
                        Int32.Parse(split[2])
                        )); }
                catch { Console.WriteLine("Parse Error: " + line); }
            }
            Console.WriteLine("Presents Count: " + presents.Count);
            foreach (Present present in presents)
                totalWrappingPaper += present.wrapPaperNeeded();
            Console.WriteLine("WrappingPaper Needed: " + totalWrappingPaper.ToString());
        }

        override internal void ResolutionTaskB()
        {
            int ribbon = 0;
            List<Present> presents = new List<Present>();
            foreach (string line in input)
            {
                string[] split = line.Split('x');
                try
                {
                    presents.Add(
                    new Present(
                        Int32.Parse(split[0]),
                        Int32.Parse(split[1]),
                        Int32.Parse(split[2])
                        ));
                }
                catch { Console.WriteLine("Parse Error: " + line); }
            }
            Console.WriteLine("Presents Count: " + presents.Count);
            foreach (Present present in presents)
                ribbon += present.ribbonNeeded();
            Console.WriteLine("Ribbon Needed: " + ribbon.ToString());
        }
    }
}
