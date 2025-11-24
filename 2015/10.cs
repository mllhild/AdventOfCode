using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2015
{
    internal class _10 : BaseClass
    {
        string input;
        string path = "";

        internal void Solve()
        {
            path = @"..\..\..\input\2015-10.txt";

            Check();
            TaskA();
            TaskB();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Solve 10 End");
            Console.WriteLine("");
        }

        internal void Check()
        {
            Console.WriteLine("----------------------------------------");
            input = File.ReadAllText(path);
            Console.WriteLine("Input:");
            Console.WriteLine(input);
            Console.WriteLine("Input Lenght: " + input.Length.ToString());

        }

        override internal void ResolutionTaskA()
        {
            List<Char> chars = input.ToCharArray().ToList<Char>();
            for(int i = 0; i < 40; i++)
            {
                chars = LookAndSay(chars);
                //Console.WriteLine(new string(chars.ToArray()));
            }
            //Console.WriteLine(chars.ToString());
            Console.WriteLine("Lenght Of Result "+chars.Count.ToString());
        }
        List<Char> LookAndSay(List<Char> chars)
        {
            List<Char> charsNew = new List<char>();
            for (int i = 0; i < chars.Count;)
            {
                char theOne = chars[i];
                int count = CountOfIgualChars(chars, theOne, i);
                charsNew.AddRange(count.ToString().ToCharArray());
                charsNew.Add(theOne);
                i += count;
            }
            return charsNew;
        }
        int CountOfIgualChars(List<Char> chars, char theOne, int startPosition)
        {
            int count = 0;
            while (chars[startPosition] == theOne)
            {
                count++;
                startPosition++;
                if (startPosition == chars.Count)
                    break;
            }
            return count;
        }

        override internal void ResolutionTaskB()
        {
            List<Char> chars = input.ToCharArray().ToList<Char>();
            for (int i = 0; i < 50; i++)
            {
                chars = LookAndSay(chars);
                //Console.WriteLine(new string(chars.ToArray()));
            }
            //Console.WriteLine(chars.ToString());
            Console.WriteLine("Lenght Of Result " + chars.Count.ToString());
        }
    }
}
