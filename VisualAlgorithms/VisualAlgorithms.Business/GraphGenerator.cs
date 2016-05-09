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

            graph.AddNode("0");
            graph.AddNode("1");
            graph.AddNode("2");
            graph.AddNode("3");
            graph.AddNode("4");
            graph.AddNode("5");
            graph.AddNode("6");
            graph.AddNode("7");

            
            graph.AddEdge("0", "6");
            graph.AddEdge("0", "3"); 
            graph.AddEdge("0", "7"); 
            graph.AddEdge("0", "5"); 
            graph.AddEdge("0", "1"); 
            graph.AddEdge("1", "6"); 
            graph.AddEdge("1", "7");
            graph.AddEdge("7", "3");
            graph.AddEdge("7", "4");
            graph.AddEdge("7", "2");
            graph.AddEdge("2", "5");
            graph.AddEdge("5", "6");
            graph.AddEdge("6", "3");
            graph.AddEdge("3", "4");

            return graph;
        }


        public DirectedGraph<string> GetExampleDirectedGraph()
        {
            DirectedGraph<string> graph = new DirectedGraph<string>();

            graph.AddNode("1");
            graph.AddNode("2");
            graph.AddNode("3");
            graph.AddNode("4");
            graph.AddNode("5");
            graph.AddNode("6");
            graph.AddNode("7");
            graph.AddNode("8");

            graph.AddEdge("1", "2");
            graph.AddEdge("2", "3");
            graph.AddEdge("3", "1");
            graph.AddEdge("4", "2");
            graph.AddEdge("4", "3");
            graph.AddEdge("4", "5");
            graph.AddEdge("5", "4");
            graph.AddEdge("5", "6");
            graph.AddEdge("6", "3");
            graph.AddEdge("6", "7");
            graph.AddEdge("7", "6");
            graph.AddEdge("8", "5");
            graph.AddEdge("8", "8");

            return graph;

        }

    }
}
