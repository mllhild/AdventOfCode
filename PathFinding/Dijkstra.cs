using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdventOfCode.PathFinding
{
    internal class Dijkstra
    {
        internal Dictionary<string, Connection> shortestConnections = new Dictionary<string, Connection>();
        internal PriorityQueue<Node,int> priorityQueue = new PriorityQueue<Node,int>();
        internal Graph graph = new Graph();
        internal Node startNode;
        internal Node endNode;
        internal void SolveForShortesRoute(string startNodeID, string endNodeID)
        {
            startNode = graph.nodes[startNodeID];
            endNode = graph.nodes[endNodeID];

            // add all to queue
            foreach (Node node in graph.nodes.Values)
            {
                priorityQueue.Enqueue(node, int.MaxValue);
                graph.nodes[startNode.id].shortestTraveltimeToNode = int.MaxValue;
            }

            // set start node
            priorityQueue.Enqueue(startNode, 0);
            graph.nodes[startNode.id].shortestTraveltimeToNode = 0;

            CheckRoadsFromCurrentLocation(priorityQueue.Dequeue()); // gets lowest number
        }
        // Update Estimates
        void CheckRoadsFromCurrentLocation(Node currentNode)
        {
            graph.nodes[currentNode.id].visited = true;
            foreach (Connection connection in graph.nodes[currentNode.id].connections.Values)
            {
                int totalTraveltime = connection.weight + currentNode.shortestTraveltimeToNode;
                if(totalTraveltime < graph.nodes[connection.to.id].shortestTraveltimeToNode)
                {
                    graph.nodes[connection.to.id].shortestTraveltimeToNode = totalTraveltime;
                    graph.nodes[connection.to.id].shortestConnection = connection;

                    // shortest way to this node
                    if (shortestConnections.ContainsKey(connection.to.id))
                        shortestConnections[connection.to.id] = connection;
                    else
                        shortestConnections.Add(connection.to.id, connection);

                    // add to queue
                    priorityQueue.Enqueue(graph.nodes[connection.to.id], totalTraveltime);
                }
            }
            ChooseNextNode();
        }
        void ChooseNextNode()
        {
            Node nextNode = priorityQueue.Dequeue();
            // Check if node is target
            if(nextNode.id == endNode.id)
                Backtrack(nextNode);
            else
                CheckRoadsFromCurrentLocation(nextNode);
        }
        void Backtrack(Node node)
        {
            Console.WriteLine(node.shortestTraveltimeToNode.ToString() + " " + node.id.ToString());
            Node previousNode = node.shortestConnection.from;
            if(previousNode.id == startNode.id)
            { 
                Console.WriteLine(previousNode.shortestTraveltimeToNode.ToString() + " " + previousNode.id.ToString());
                return;
            }
            Backtrack(previousNode);
        }

    }

    internal class Node
    {
        internal Node(string _id) { id = _id; }
        internal string id;
        internal bool visited = false;
        internal int shortestTraveltimeToNode = int.MaxValue;
        internal Dictionary<string, Connection> connections = new Dictionary<string, Connection>();
        internal Connection shortestConnection;
    }
    internal class Connection
    {
        internal Connection(string _id, Node _from, Node _to, int _weight)
        {
            id = _id;
            from = _from;
            to = _to;
            weight = _weight;
        }
        internal string id;
        internal int weight;
        internal Node from;
        internal Node to;
    }


    internal class Graph
    {
        internal string id;
        internal Dictionary<string, Node> nodes = new Dictionary<string, Node>();
    }

}
