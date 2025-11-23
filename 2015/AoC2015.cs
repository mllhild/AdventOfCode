using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2015
{
    internal class AoC2015
    {
        internal static void SelectTask()
        {
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Select task via number:");
            Console.WriteLine(" 0. Return");
            Console.WriteLine("Task  1 to 25");
            Console.WriteLine("---------------------");
            string input = Console.ReadLine();
            Console.WriteLine("----------------------------------------");

            input = input.Trim();

            switch (input)
            {
                case "0":
                    Console.WriteLine("Bye");
                    return;
                    break;

                case "1": new _01().Solve(); break;
                case "2": new _02().Solve(); break;
                case "3": new _03().Solve(); break;
                case "4": new _04().Solve(); break;
                case "5": new _05().Solve(); break;
                case "6": new _06().Solve(); break;
                case "7": new _07().Solve(); break;
                case "8": new _08().Solve(); break;
                case "9": ToDo(); break;
                case "10": ToDo(); break;
                case "11": ToDo(); break;
                case "12": ToDo(); break;
                case "13": ToDo(); break;
                case "14": ToDo(); break;
                case "15": ToDo(); break;
                case "16": ToDo(); break;
                case "17": ToDo(); break;
                case "18": ToDo(); break;
                case "19": ToDo(); break;
                case "20": ToDo(); break;
                case "21": ToDo(); break;
                case "22": ToDo(); break;
                case "23": ToDo(); break;
                case "24": ToDo(); break;
                case "25": ToDo(); break;

                default:
                    Console.WriteLine("No valid input");
                    SelectTask();
                    break;
            }
            SelectTask();
        }

        static void ToDo() { }
        
    }
}

