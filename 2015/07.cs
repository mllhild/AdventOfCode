using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2015
{
    internal class _07 : BaseClass
    {
        string[] input;
        string path = "";

        internal void Solve()
        {
            path = @"..\..\..\input\2015-07.txt";
            Check();
            TaskA();

            path = @"..\..\..\input\2015-07b.txt";
            Check();
            TaskB();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Solve 07 End");
        }

        internal void Check()
        {
            Console.WriteLine("----------------------------------------");
            input = File.ReadAllLines(path);
            Console.WriteLine("Input:");
            Console.WriteLine(input);
            Console.WriteLine("Input Lenght: " + input.Length.ToString());

        }


        struct Wire()
        {
            
        }
        enum OperationType
        {
            Copy,
            RSHIFT,
            LSHIFT,
            AND,
            OR,
            XOR,
            NOT
        }

        override internal void ResolutionTaskA()
        {


            // option 1
            // get definition of a
            // recursive backwards to build list of instructions

            // option 2
            // build network
            // execute each step

            // option 3
            // sort
            // get primary inputs
            // execute until no lines are left

            Dictionary<string, Int32> wires = new Dictionary<string, Int32>();
            List<string> currentInput = input.ToList<string>();
            //currentInput.Sort();

            Console.Clear();
            int lineCount = 10000;
            while (currentInput.Count > 0) {
                //Console.Clear();
                
                //foreach (KeyValuePair<string, Int32> wire in wires)
                //    Console.WriteLine(wire.Key + "\t" + wire.Value);
                
                if(lineCount > currentInput.Count)
                {
                    Console.WriteLine(currentInput.Count.ToString());
                    lineCount = currentInput.Count;
                }
                else
                {
                    Console.WriteLine(currentInput.Count.ToString());
                    foreach (var cur in currentInput)
                        Console.WriteLine(cur);
                    break;
                }
                for (int i = currentInput.Count - 1; i >= 0; i--)
                    {

                        string[] parts = currentInput[i].Trim().Split(' ');
                    //Console.WriteLine(parts[0]);
                    //Console.WriteLine(parts[1]);
                    //Console.WriteLine(parts[2]);
                    //Console.WriteLine(currentInput[i]);
                    //Console.WriteLine(Int32.Parse(parts[0].Trim()) *2);
                    //Console.WriteLine(Int32.Parse(parts[0].Trim()) - 1);
                    

                        if (parts[1].Trim() == "->")
                        {
                            int x = -1;
                            try { x = Int32.Parse(parts[0].Trim()); }
                            catch { }

                            

                            if (x == -1)
                                if (wires.ContainsKey(parts[0].Trim()))
                                {
                                    wires.Add(parts[2].Trim(), (wires[parts[0].Trim()]));
                                    Console.WriteLine(currentInput[i] + " this 1");
                                    currentInput.Remove(currentInput[i]);
                                    continue;
                                }
                            if (x != -1)
                            {
                                wires.Add(parts[2].Trim(), (x));
                                Console.WriteLine("Value: " + x.ToString());
                                Console.WriteLine(currentInput[i] + " this 2");
                                currentInput.Remove(currentInput[i]);
                                continue;
                            }
                            if(parts[0] == "0")
                            {
                                wires.Add(parts[2].Trim(), 0);
                                Console.WriteLine(currentInput[i] + " this 3");
                                currentInput.Remove(currentInput[i]);
                                continue;
                            }
                        }

                    if (parts[1].Trim() == "RSHIFT")
                            if (wires.ContainsKey(parts[0].Trim()))
                            {
                                wires.Add(parts[4].Trim(), (wires[parts[0].Trim()] >> Int32.Parse(parts[2].Trim())));
                                Console.WriteLine(currentInput[i]);
                                currentInput.Remove(currentInput[i]);
                                continue;
                            }
                        if (parts[1].Trim() == "LSHIFT")
                            if (wires.ContainsKey(parts[0].Trim()))
                            {
                                wires.Add(parts[4].Trim(), (wires[parts[0].Trim()] << Int32.Parse(parts[2].Trim())));
                                Console.WriteLine(currentInput[i]);
                                currentInput.Remove(currentInput[i]);
                                continue;
                            }


                        if (parts[1].Trim() == "AND")
                        {
                            int x = -1; int y = -1;
                            try { x = Int32.Parse(parts[0].Trim()); }
                            catch { }
                            try { y = Int32.Parse(parts[2].Trim()); }
                            catch { }

                            if (x == -1 && y == -1)
                                if (wires.ContainsKey(parts[0].Trim()) && wires.ContainsKey(parts[2].Trim()))
                                {
                                    wires.Add(parts[4].Trim(), (wires[parts[0].Trim()] & wires[parts[2].Trim()]));
                                    Console.WriteLine(currentInput[i]);
                                    currentInput.Remove(currentInput[i]);
                                    continue;
                                }
                            if (x == -1 && y != -1)
                                if (wires.ContainsKey(parts[0].Trim()))
                                {
                                    wires.Add(parts[4].Trim(), (wires[parts[0].Trim()] & y));
                                    Console.WriteLine(currentInput[i]);
                                    currentInput.Remove(currentInput[i]);
                                    continue;
                                }
                            if (x != -1 && y == -1)
                                if (wires.ContainsKey(parts[2].Trim()))
                                {
                                    wires.Add(parts[4].Trim(), (x & wires[parts[2].Trim()]));
                                    Console.WriteLine(currentInput[i]);
                                    currentInput.Remove(currentInput[i]);
                                    continue;
                                }
                            if (x != -1 && y != -1)
                                if (true)
                                {
                                    wires.Add(parts[4].Trim(), (x & y));
                                    Console.WriteLine(currentInput[i]);
                                    currentInput.Remove(currentInput[i]);
                                    continue;
                                }
                        }

                        if (parts[1].Trim() == "OR")
                        {
                            int x = -1; int y = -1;
                            try { x = Int32.Parse(parts[0].Trim()); }
                            catch { }
                            try { y = Int32.Parse(parts[2].Trim()); }
                            catch { }

                            if (x == -1 && y == -1)
                                if (wires.ContainsKey(parts[0].Trim()) && wires.ContainsKey(parts[2].Trim()))
                                {
                                    wires.Add(parts[4].Trim(), (wires[parts[0].Trim()] | wires[parts[2].Trim()]));
                                    Console.WriteLine(currentInput[i]);
                                    currentInput.Remove(currentInput[i]);
                                    continue;
                                }
                            if (x == -1 && y != -1)
                                if (wires.ContainsKey(parts[0].Trim()))
                                {
                                    wires.Add(parts[4].Trim(), (wires[parts[0].Trim()] | y));
                                    Console.WriteLine(currentInput[i]);
                                    currentInput.Remove(currentInput[i]);
                                    continue;
                                }
                            if (x != -1 && y == -1)
                                if (wires.ContainsKey(parts[2].Trim()))
                                {
                                    wires.Add(parts[4].Trim(), (x | wires[parts[2].Trim()]));
                                    Console.WriteLine(currentInput[i]);
                                    currentInput.Remove(currentInput[i]);
                                    continue;
                                }
                            if (x != -1 && y != -1)
                                if (true)
                                {
                                    wires.Add(parts[4].Trim(), (x | y));
                                    Console.WriteLine(currentInput[i]);
                                    currentInput.Remove(currentInput[i]);
                                    continue;
                                }
                        }
                        if (parts[1].Trim() == "XOR")
                        {
                            int x = -1; int y = -1;
                            try { x = Int32.Parse(parts[0].Trim()); }
                            catch { }
                            try { y = Int32.Parse(parts[2].Trim()); }
                            catch { }

                            if (x == -1 && y == -1)
                                if (wires.ContainsKey(parts[0].Trim()) && wires.ContainsKey(parts[2].Trim()))
                                {
                                    wires.Add(parts[4].Trim(), (wires[parts[0].Trim()] ^ wires[parts[2].Trim()]));
                                    Console.WriteLine(currentInput[i]);
                                    currentInput.Remove(currentInput[i]);
                                    continue;
                                }
                            if (x == -1 && y != -1)
                                if (wires.ContainsKey(parts[0].Trim()))
                                {
                                    wires.Add(parts[4].Trim(), (wires[parts[0].Trim()] ^ y));
                                    Console.WriteLine(currentInput[i]);
                                    currentInput.Remove(currentInput[i]);
                                    continue;
                                }
                            if (x != -1 && y == -1)
                                if (wires.ContainsKey(parts[2].Trim()))
                                {
                                    wires.Add(parts[4].Trim(), (x ^ wires[parts[2].Trim()]));
                                    Console.WriteLine(currentInput[i]);
                                    currentInput.Remove(currentInput[i]);
                                    continue;
                                }
                            if (x != -1 && y != -1)
                                if (true)
                                {
                                    wires.Add(parts[4].Trim(), (x ^ y));
                                    Console.WriteLine(currentInput[i]);
                                    currentInput.Remove(currentInput[i]);
                                    continue;
                                }
                        }
                        if (parts[0].Trim() == "NOT")
                        {
                            int x = -1;
                            try { x = Int32.Parse(parts[1].Trim()); }
                            catch { }

                            if (x == -1)
                                if (wires.ContainsKey(parts[1].Trim()))
                                {
                                    wires.Add(parts[3].Trim(), (~wires[parts[1].Trim()]));
                                    Console.WriteLine(currentInput[i]);
                                    currentInput.Remove(currentInput[i]);
                                    continue;
                                }
                            if (x != -1)
                            {
                                wires.Add(parts[3].Trim(), (~x));
                                Console.WriteLine(currentInput[i]);
                                currentInput.Remove(currentInput[i]);
                                continue;
                            }
                        }
                        //i--;
                    }
            }

            Console.WriteLine("");
            foreach (KeyValuePair<string, Int32> wire in wires) { 
                Console.WriteLine(wire.Key + "\t" + wire.Value); 
            }

            
        }


        override internal void ResolutionTaskB()
        {
            // changed file to 2015-07b.txt
            ResolutionTaskA();
        }

    }
}
