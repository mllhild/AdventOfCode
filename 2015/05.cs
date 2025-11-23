using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2015
{
    internal class _05 :BaseClass
    {
        string[] input;
        string path = "";

        internal void Solve()
        {
            path = @"..\..\..\input\2015-05.txt";

            Check();
            TaskA();
            TaskB();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Solve 05 End");
        }

        internal void Check()
        {
            Console.WriteLine("----------------------------------------");
            input = File.ReadAllLines(path);
            Console.WriteLine("Input:");
            Console.WriteLine(input);
            Console.WriteLine("Input Lenght: " + input.Length.ToString());

        }

        bool IsNiceV1(char[] chars) { 
            // Test 1
            int counter = 0;
            foreach (char c in chars)
                if(c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                    counter++;
            if(counter < 3)
                return false;

            // Test 2
            bool repeatChar = false;
            for(int i = 0; i<chars.Length - 1; i++)
                if (chars[i] == chars[i+1])
                    repeatChar = true;
            if(!repeatChar)
                return false;

            // Test 3
            string line = new string(chars);
            if(line.Contains("ab") || line.Contains("cd") || line.Contains("pq") || line.Contains("xy")) 
                return false;

            return true;
        }

        bool IsNiceV2(char[] chars)
        {
            // Test 1
            bool repeatPair = false;
            for (int i = 0; i < chars.Length - 1; i++)
            {
                for(int j = 0; j < chars.Length - 1; j++)
                {
                    if (j == i || j == i + 1 || j == i - 1)
                        continue;
                    if (chars[i] == chars[j] && chars[i + 1] == chars[j + 1])
                        repeatPair = true;
                }
            }
            if (!repeatPair)
                return false;

            // Test 2
            bool repeatCharSpaced = false;
            for (int i = 0; i < chars.Length - 2; i++)
                if (chars[i] == chars[i + 2])
                    repeatCharSpaced = true;
            if (!repeatCharSpaced)
                return false;

            return true;
        }

        override internal void ResolutionTaskA()
        {
            int counter = 0;
            foreach (string line in input)
            {
                char[] chars = line.ToCharArray();
                if(IsNiceV1(chars))
                    counter++;
                
            }
            Console.WriteLine("Number of Nice strings: " + counter);
        }

        override internal void ResolutionTaskB()
        {
            Console.WriteLine("-------------------------");
            int counter = 0;
            foreach (string line in input)
            {
                char[] chars = line.ToCharArray();
                if (IsNiceV2(chars))
                {
                    counter++;
                }
                    
            }
            Console.WriteLine("Number of Nice strings: " + counter);
        }
    }
}
