using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2015
{
    internal class _06 : BaseClass
    {
        string[] input;
        string path = "";

        internal void Solve()
        {
            path = @"..\..\..\input\2015-06.txt";

            Check();
            TaskA();
            TaskB();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Solve 06 End");
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
            bool[,] grid = new bool[1000, 1000]; // all lights are off (off = false)
            foreach(string line in input)
            {
                string[] parts = line.Split(' ');
                if(parts.Length < 2 ) 
                    continue;
                if (parts[0] == "toggle")
                    ToggleOnOff(parts[1], parts[3], grid);
                if(parts[1] == "on")
                    TurnOn(parts[2], parts[4], grid);
                if (parts[1] == "off")
                    TurnOff(parts[2], parts[4], grid);
            }
            int lightsOn = CountLights(grid);
            Console.WriteLine("Nr. of ON lights: " + lightsOn.ToString());
        }

        void TurnOn(string xy1, string xy2, bool[,] grid)
        {
            int x1 = Int32.Parse(xy1.Split(',')[0]);
            int y1 = Int32.Parse(xy1.Split(',')[1]);
            int x2 = Int32.Parse(xy2.Split(',')[0]);
            int y2 = Int32.Parse(xy2.Split(',')[1]);

            int xStart = Math.Min(x1, x2);
            int xEnd = Math.Max(x1, x2);
            int yStart = Math.Min(y1, y2);
            int yEnd = Math.Max(y1, y2);

            for (int x = xStart; x <= xEnd; x++)
                for (int y = yStart; y <= yEnd; y++)
                    grid[x, y] = true;
        }
        void TurnOff(string xy1, string xy2, bool[,] grid)
        {
            int x1 = Int32.Parse(xy1.Split(',')[0]);
            int y1 = Int32.Parse(xy1.Split(',')[1]);
            int x2 = Int32.Parse(xy2.Split(',')[0]);
            int y2 = Int32.Parse(xy2.Split(',')[1]);

            int xStart = Math.Min(x1, x2);
            int xEnd = Math.Max(x1, x2);
            int yStart = Math.Min(y1, y2);
            int yEnd = Math.Max(y1, y2);

            for (int x = xStart; x <= xEnd; x++)
                for (int y = yStart; y <= yEnd; y++)
                    grid[x, y] = false;
        }
        void ToggleOnOff(string xy1, string xy2, bool[,] grid)
        {
            int x1 = Int32.Parse(xy1.Split(',')[0]);
            int y1 = Int32.Parse(xy1.Split(',')[1]);
            int x2 = Int32.Parse(xy2.Split(',')[0]);
            int y2 = Int32.Parse(xy2.Split(',')[1]);

            int xStart = Math.Min(x1, x2);
            int xEnd = Math.Max(x1, x2);
            int yStart = Math.Min(y1, y2);
            int yEnd = Math.Max(y1, y2);

            for (int x = xStart; x <= xEnd; x++)
                for (int y = yStart; y <= yEnd; y++)
                    grid[x, y] = !grid[x, y];
        }

        int CountLights(bool[,] grid)
        {
            int xSize = grid.GetLength(0);
            int ySize = grid.GetLength(1);
            int counter = 0;
            for (int x = 0; x < xSize; x++)
                for (int y = 0; y < ySize; y++)
                    if (grid[x, y])
                        counter++;
            return counter;
        }

        override internal void ResolutionTaskB()
        {
            int[,] grid = new int[1000, 1000]; // all lights are off (off = false)
            foreach (string line in input)
            {
                string[] parts = line.Split(' ');
                if (parts.Length < 2)
                    continue;
                if (parts[0] == "toggle")
                    ToggleOnOffV2(parts[1], parts[3], grid);
                if (parts[1] == "on")
                    TurnOnV2(parts[2], parts[4], grid);
                if (parts[1] == "off")
                    TurnOffV2(parts[2], parts[4], grid);
            }
            int lightsOn = CountLightsV2(grid);
            Console.WriteLine("Total brightness: " + lightsOn.ToString());
        }

        void TurnOnV2(string xy1, string xy2, int[,] grid)
        {
            int x1 = Int32.Parse(xy1.Split(',')[0]);
            int y1 = Int32.Parse(xy1.Split(',')[1]);
            int x2 = Int32.Parse(xy2.Split(',')[0]);
            int y2 = Int32.Parse(xy2.Split(',')[1]);

            int xStart = Math.Min(x1, x2);
            int xEnd = Math.Max(x1, x2);
            int yStart = Math.Min(y1, y2);
            int yEnd = Math.Max(y1, y2);

            for (int x = xStart; x <= xEnd; x++)
                for (int y = yStart; y <= yEnd; y++)
                    grid[x, y]++;
        }

        void TurnOffV2(string xy1, string xy2, int[,] grid)
        {
            int x1 = Int32.Parse(xy1.Split(',')[0]);
            int y1 = Int32.Parse(xy1.Split(',')[1]);
            int x2 = Int32.Parse(xy2.Split(',')[0]);
            int y2 = Int32.Parse(xy2.Split(',')[1]);

            int xStart = Math.Min(x1, x2);
            int xEnd = Math.Max(x1, x2);
            int yStart = Math.Min(y1, y2);
            int yEnd = Math.Max(y1, y2);

            for (int x = xStart; x <= xEnd; x++)
                for (int y = yStart; y <= yEnd; y++)
                    { 
                        grid[x, y]--; 
                        if(grid[x, y]<0)
                            grid[x, y] = 0;
                    }
        }
        void ToggleOnOffV2(string xy1, string xy2, int[,] grid)
        {
            int x1 = Int32.Parse(xy1.Split(',')[0]);
            int y1 = Int32.Parse(xy1.Split(',')[1]);
            int x2 = Int32.Parse(xy2.Split(',')[0]);
            int y2 = Int32.Parse(xy2.Split(',')[1]);

            int xStart = Math.Min(x1, x2);
            int xEnd = Math.Max(x1, x2);
            int yStart = Math.Min(y1, y2);
            int yEnd = Math.Max(y1, y2);

            for (int x = xStart; x <= xEnd; x++)
                for (int y = yStart; y <= yEnd; y++)
                    grid[x, y] += 2;
        }

        int CountLightsV2(int[,] grid)
        {
            int xSize = grid.GetLength(0);
            int ySize = grid.GetLength(1);
            int counter = 0;
            for (int x = 0; x < xSize; x++)
                for (int y = 0; y < ySize; y++)
                    counter += grid[x, y];
            return counter;
        }
    }
}
