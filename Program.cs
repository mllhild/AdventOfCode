using System;

namespace YourProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SelectYear();
        }

        static void SelectYear() {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Select Year via number:");
            Console.WriteLine("---------------------");
            Console.WriteLine(" 0. Quit");
            Console.WriteLine(" 1. 2015");
            Console.WriteLine(" 2. 2016");
            Console.WriteLine(" 3. 2017");
            Console.WriteLine(" 4. 2018");
            Console.WriteLine(" 5. 2019");
            Console.WriteLine(" 6. 2020");
            Console.WriteLine(" 7. 2021");
            Console.WriteLine(" 8. 2022");
            Console.WriteLine(" 9. 2023");
            Console.WriteLine("10. 2024");
            Console.WriteLine("11. 2025");
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
                case "1":
                    Console.WriteLine("Selected 2015");
                    AdventOfCode._2015.AoC2015.SelectTask();
                    break;

                default:
                    Console.WriteLine("No valid input");
                    SelectYear();
                    break;
            }
            SelectYear();
        }
    }
}
