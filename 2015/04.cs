using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AdventOfCode._2015
{
    internal class _04 : BaseClass
    {
        string input;
        string path = "";

        internal void Solve()
        {
            path = @"..\..\..\input\2015-04.txt";

            Check();
            TaskA();
            TaskB();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Solve 04 End");
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

        internal string HashMD5(string stringToHash)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(stringToHash);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
                sb.Append(b.ToString("x2"));
            return sb.ToString();
        }

        override internal void ResolutionTaskA()
        {
            int seed = 0;
            bool foundCoin = false;
            while (foundCoin != true) {
                seed++;
                string stringToHash = input + seed.ToString();
                string hash = HashMD5(stringToHash);
                string firstFiveLetters = hash.Substring(0, 5);
                if (firstFiveLetters == "00000")
                    foundCoin = true;
            }
            Console.WriteLine(HashMD5(input + seed.ToString()));
            Console.WriteLine(seed.ToString());
        }

        override internal void ResolutionTaskB()
        {
            int seed = 0;
            bool foundCoin = false;
            while (foundCoin != true)
            {
                seed++;
                string stringToHash = input + seed.ToString();
                string hash = HashMD5(stringToHash);
                string firstSixLetters = hash.Substring(0, 6);
                if (firstSixLetters == "000000")
                    foundCoin = true;
            }
            Console.WriteLine(HashMD5(input + seed.ToString()));
            Console.WriteLine(seed.ToString());
        }
    }
}
