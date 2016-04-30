using System;
using VisualAlgorithms.Business.Models;

namespace VisualAlgorithms.Business
{
    public class GraphGenerator
    {

        public UndirectedGraph<string> GenerateUndirctedGraph()
        {  
            Random rnd = new Random();

            var nodesCount = rnd.Next(2, 10);
            var graph = new UndirectedGraph<string>();

            for (int i = 0; i < nodesCount; i++)
            {
                graph.AddNode(((char)('A' + i)).ToString());
            }

            var edgeCount = rnd.Next(1, nodesCount*(nodesCount - 1)/2);

            for (int i = 0; i < edgeCount; i++)
            {
                var from = rnd.Next(0, nodesCount);
                var to = rnd.Next(0, nodesCount);

                if (from == to)
                {
                    i--;
                    continue;
                }

                graph.AddEdge(from, to);
            }

            return graph;
        }

        public Graph<string> GenerateDirectedAcyclicGraph()
        {

            Random rnd = new Random();

            var nodesCount = rnd.Next(2, 10);
            var graph = new DirectedGraph<string>();

            for (int i = 0; i < nodesCount; i++)
            {
                graph.AddNode(((char)('A' + i)).ToString());
            }

            var edgeCount = rnd.Next(1, nodesCount * (nodesCount - 1) / 2);

            for (int i = 0; i < edgeCount; i++)
            {
                var from = rnd.Next(0, nodesCount);
                var to = rnd.Next(0, nodesCount);

                if (from >= to)
                {
                    i--;
                    continue;
                }

                graph.AddEdge(from, to);
            }

            return graph;


        }

        public Graph<string> GenerateDirectedGraph()
        {
            Random rnd = new Random();

            var nodesCount = rnd.Next(2, 10);
            var graph = new DirectedGraph<string>();

            for (int i = 0; i < nodesCount; i++)
            {
                graph.AddNode(((char)('A' + i)).ToString());
            }

            var edgeCount = rnd.Next(1, nodesCount * (nodesCount - 1) / 2);

            for (int i = 0; i < edgeCount; i++)
            {
                var from = rnd.Next(0, nodesCount);
                var to = rnd.Next(0, nodesCount);

                if (from == to)
                {
                    i--;
                    continue;
                }

                graph.AddEdge(from, to);
            }

            return graph;


        }

        public UndirectedGraph<string> GetExampleGraph()
        {
            UndirectedGraph<string> graph = new UndirectedGraph<string>();

            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");
            graph.AddNode("D");
            graph.AddNode("E");
            graph.AddNode("F");

            
            graph.AddEdge("A", "B");
            graph.AddEdge("B", "D"); 
            graph.AddEdge("D", "C"); 
            graph.AddEdge("C", "E"); 
            graph.AddEdge("B", "E"); 
            graph.AddEdge("C", "F"); 
            graph.AddEdge("E", "F");

            return graph;
        }
    }
}
