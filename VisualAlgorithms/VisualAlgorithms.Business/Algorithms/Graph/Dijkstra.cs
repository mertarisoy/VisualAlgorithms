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
        private bool[] visited;

        public List<Tuple<Node<T>, double>> nodeList = new List<Tuple<Node<T>, double>>();


        public Dijkstra(Graph<T> graph, Node<T> startNode)
        {
            this.graph = graph;
            this.startNode = startNode;
            this.visited = new bool[graph.CountNodes()];
            InitializeDijkstra();
        }

        public void InitializeDijkstra() {
            
        }
    }
}
