using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualAlgorithms.Business.Models;

namespace VisualAlgorithms.Business.Algorithms.Graph
{
    public class Dijkstra<T>
    {
        private Graph<T> graph;
        Node<T> startNode;
        //private bool[] visited;
        //private double[] dist;
        //private Node<T>[] prev;

        private Dictionary<Node<T>, bool> visited;
        private Dictionary<Node<T>, double> distance;
        private Dictionary<Node<T>, Node<T>> previous;

        List<Node<T>> nodeList;

        //public List<Tuple<Node<T>, double>> nodes = new List<Tuple<Node<T>, double>>();

        public Dijkstra(Graph<T> graph, Node<T> startNode)
        {
            this.graph = graph;
            this.startNode = startNode;
            //this.visited = new bool[graph.CountNodes()];
            //this.dist = new double[graph.CountNodes()];
            //this.prev = new Node<T>[graph.CountNodes()];

            visited = new Dictionary<Node<T>, bool>();
            distance = new Dictionary<Node<T>, double>();
            previous = new Dictionary<Node<T>, Node<T>>();

            foreach (Node<T> node in graph.getNodeList())
            {
                visited.Add(node, false);
                distance.Add(node, double.MaxValue);
                previous.Add(node, null);
            }

           
        }
    }
}
