using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.PathFinding
{
    internal class MinSpanningTree
    {

        internal GraphMST graph = new GraphMST();
        List<ConnectionMST> treeBranches = new List<ConnectionMST>();
        int totalCost = 0;

        internal void BuildMinSpanningTree()
        {
            PriorityQueue<string, int> priorityQueue = new PriorityQueue<string, int>();
            foreach(string connectionID in graph.connections.Keys)
                priorityQueue.Enqueue(connectionID, graph.connections[connectionID].weight);
            Console.WriteLine("priorityQueue: " + priorityQueue.Count.ToString());
            while (priorityQueue.Count > 0)
            {
                string nextConncetionID = priorityQueue.Dequeue();
                CheckConnection(nextConncetionID);
            }

            Console.WriteLine("Total Cost: " + totalCost.ToString());
            foreach (ConnectionMST connection in treeBranches)
                Console.WriteLine(connection.id + " " + connection.weight.ToString());
        }
        
        void CheckConnection(string conncetionID)
        {
            Console.WriteLine(conncetionID);
            ConnectionMST connection = graph.connections[conncetionID];
            if(connection.from.visited && connection.to.visited) 
                return;
            connection.from.visited = true;
            connection.to.visited = true;
            connection.active = true;
            totalCost += connection.weight;
            treeBranches.Add(connection);
        }

        internal class GraphMST
        {
            internal string id;
            internal Dictionary<string, NodeMST> nodes = new Dictionary<string, NodeMST>();
            internal Dictionary<string, ConnectionMST> connections = new Dictionary<string, ConnectionMST>();
        }
        internal class NodeMST
        {
            internal NodeMST(string _id) { id = _id; }
            internal string id;
            internal bool visited = false;
            internal Dictionary<string, ConnectionMST> connections = new Dictionary<string, ConnectionMST>();
            internal ConnectionMST shortestConnection;
        }
        internal class ConnectionMST
        {
            internal ConnectionMST(string _id, NodeMST _from, NodeMST _to, int _weight)
            {
                id = _id;
                from = _from;
                to = _to;
                weight = _weight;
            }
            internal string id;
            internal int weight;
            internal NodeMST from;
            internal NodeMST to;
            internal bool active = false;
        }
    }
}
