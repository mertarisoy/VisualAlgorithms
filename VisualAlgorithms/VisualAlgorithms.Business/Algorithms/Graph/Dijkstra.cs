using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualAlgorithms.Business.Models;

namespace VisualAlgorithms.Business.Algorithms.Graph
{
    //public class Dijkstra<T>
    //{
    //    private Graph<T> graph;
    //    Node<T> startNode;
    //    //private bool[] visited;
    //    //private double[] dist;
    //    //private Node<T>[] prev;

    //    private Dictionary<Node<T>, bool> visited;
    //    private Dictionary<Node<T>, double> distance;
    //    private Dictionary<Node<T>, Node<T>> previous;

    //    Node<T>[] unvisitedNodeList;
    //    List<Node<T>> neighbors;

    //    //public List<Tuple<Node<T>, double>> nodes = new List<Tuple<Node<T>, double>>();

    //    public Dijkstra(Graph<T> graph, Node<T> startNode)
    //    {
    //        this.graph = graph;
    //        this.startNode = startNode;
    //        unvisitedNodeList = new Node<T>[graph.CountNodes()];
    //        //this.visited = new bool[graph.CountNodes()];
    //        //this.dist = new double[graph.CountNodes()];
    //        //this.prev = new Node<T>[graph.CountNodes()];

    //        visited = new Dictionary<Node<T>, bool>();
    //        distance = new Dictionary<Node<T>, double>();
    //        previous = new Dictionary<Node<T>, Node<T>>();

    //        unvisitedNodeList = graph.getNodeList().ToArray();

    //        foreach (Node<T> node in graph.getNodeList())
    //        {
    //            visited.Add(node, false);
    //            distance.Add(node, double.MaxValue);
    //        }

    //        InitializeDijkstra();
    //    }

    //    public void InitializeDijkstra()
    //    {
    //        Node<T> prevNode = null;

    //        visited[startNode] = true;
    //        distance[startNode] = 0;

    //        while (true)
    //        {

    //        }

    //        previous.Add(startNode, prevNode);


    //    }

    //    public List<Node<T>> GetNeightbors(Node<T> n)
    //    {
    //        List<Node<T>> neightbors = new List<Node<T>>();
    //        foreach (Edge<T> edge in n.EdgeList)
    //        {
    //            neighbors.Add(graph.GetNode(edge.DestinationId));
    //        }
    //        return neighbors;
    //    }
    //}

    public class Dijkstra<T>
    {
        List<Node<T>> vertices = new List<Node<T>>();
        List<Edge<T>> edges = new List<Edge<T>>();

        Node<T> startNode;
        Dictionary<Node<T>, double> distance = new Dictionary<Node<T>, double>();
        Dictionary<Node<T>, Node<T>> prior = new Dictionary<Node<T>, Node<T>>();
        List<Node<T>> unvisited = new List<Node<T>>();

        public Dijkstra(Graph<T> graph, Node<T> startNode)
        {
            vertices = graph.getNodeList();

            this.startNode = startNode;

            InitializeDijkstra(graph);
        }

        public void InitializeDijkstra(Graph<T> graph)
        {
            foreach(Node<T> currentNode in vertices)
            {
                distance.Add(currentNode, double.MaxValue);
                prior.Add(currentNode, null);
            }

            distance[startNode] = 0;
            unvisited = vertices;

            while(unvisited.Count != 0)
            {
                Node<T> currentNode = GetClosestNode();
                List<Node<T>> neighbors = GetNeighbors(currentNode, graph);

                foreach(Node<T> neighborNode in neighbors)
                {
                    if (unvisited.Contains(neighborNode))
                    {
                        DistanceUpdate(currentNode, neighborNode);
                    }
                }
                if (currentNode == null)
                    return;
                unvisited.Remove(currentNode);
            }
        }

        public Node<T> GetClosestNode()
        {
            double currentDistance = double.MaxValue;
            Node<T> closestNode = null;

            foreach (Node<T> currentNode in unvisited)
            {
                if (distance[currentNode] < currentDistance)
                {
                    currentDistance = distance[currentNode];
                    closestNode = currentNode;
                }
            }
            return closestNode;
        }

        public List<Node<T>> GetNeighbors(Node<T> currentNode, Graph<T> graph)
        {
            List<Node<T>> neightbors = new List<Node<T>>();
            foreach (Edge<T> edge in currentNode.EdgeList)
            {
                neightbors.Add(graph.GetNode(edge.DestinationId));
            }
            return neightbors;
        }

        private void DistanceUpdate(Node<T> currentNode, Node<T> neighborNode)
        {
            double temp = distance[currentNode] + GetDistanceBetween(currentNode, neighborNode);
        }

        private double GetDistanceBetween(Node<T> nodeOne, Node<T> nodeTwo)
        {
            
            //foreach (Edge currentEdge in edges)
            //{
            //    if (currentEdge.GetSrcNode().Equals(nodeOne) && currentEdge.GetDstNode().Equals(nodeTwo))
            //    {
            //        return currentEdge.GetWeight();
            //    }
            //    else if (currentEdge.GetDstNode().Equals(nodeOne) && currentEdge.GetSrcNode().Equals(nodeTwo))
            //    {
            //        return currentEdge.GetWeight();
            //    }
            //}
            return 0;
        }

        public double GetTotalWeight(Node<T> destNode)
        {
            return distance[destNode];
        }

        public List<Node<T>> CreateShortestPath(Node<T> destNode)
        {
            List<Node<T>> path = new List<Node<T>>();
            path.Add(destNode);
            Node<T> currentNode = destNode;

            while(prior[currentNode]!= null)
            {
                currentNode = prior[currentNode];
                path.Add(currentNode);
            }
            return path;
        }
    }
}
