using AdventOfCode.PathFinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdventOfCode._2015._09;
using static AdventOfCode.PathFinding.MinSpanningTree;

namespace AdventOfCode._2015
{
    internal class _09 : BaseClass
    {
        // Notes:
        // My Orignal solution gave 719 (said too high)
        // ChatGpT made one that also got 719
        // Then I permitted to go on paths in both directions
        // ChatGpt's one worked and found 183. (said too low) I double checked it and its correct. So solution has an error.


        string[] input;
        string path = "";

        internal void Solve()
        {
            path = @"..\..\..\input\2015-09.txt";

            Check();
            TaskA();
            TaskB();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Solve 09 End");
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
            int counter = 0;


            //Dijkstra dijkstra = new Dijkstra();
            
            //foreach (string line in input)
            //{
            //    string[] parts = line.Split(' ');

            //    if (!dijkstra.graph.nodes.ContainsKey(parts[0]))
            //        dijkstra.graph.nodes.Add(parts[0], new Node(parts[0]));

            //    if (!dijkstra.graph.nodes.ContainsKey(parts[2]))
            //        dijkstra.graph.nodes.Add(parts[2], new Node(parts[2]));

            //    int dist = Int32.Parse(parts[4]);

            //    Connection forward = new Connection(
            //        counter++.ToString(), 
            //        dijkstra.graph.nodes[parts[0]], 
            //        dijkstra.graph.nodes[parts[2]], 
            //        dist);
            //    dijkstra.graph.nodes[parts[0]].connections.Add(forward.id, forward);
            //}
            //dijkstra.SolveForShortesRoute("Faerun", "Straylight");


            MinSpanningTree minSpanningTree = new MinSpanningTree();
            foreach (string line in input)
            {
                string[] parts = line.Split(' ');

                if (!minSpanningTree.graph.nodes.ContainsKey(parts[0]))
                    minSpanningTree.graph.nodes.Add(parts[0], new NodeMST(parts[0]));

                if (!minSpanningTree.graph.nodes.ContainsKey(parts[2]))
                    minSpanningTree.graph.nodes.Add(parts[2], new NodeMST(parts[2]));

                int dist = Int32.Parse(parts[4]);

                ConnectionMST forward = new ConnectionMST(
                    counter++.ToString(),
                    minSpanningTree.graph.nodes[parts[0]],
                    minSpanningTree.graph.nodes[parts[2]],
                    dist);
                minSpanningTree.graph.nodes[parts[0]].connections.Add(forward.id, forward);
                minSpanningTree.graph.connections.Add(forward.id, forward);
            }

            minSpanningTree.BuildMinSpanningTree();

        }

        override internal void ResolutionTaskB()
        {
           
        }
    }
}
