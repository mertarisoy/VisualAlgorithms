using System;
using System.Dynamic;
using System.IO;
using System.Threading.Tasks;
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

            
            graph.AddEdge("0", "6",5);
            graph.AddEdge("0", "3",3); 
            graph.AddEdge("0", "7"); 
            graph.AddEdge("0", "5"); 
            graph.AddEdge("0", "1"); 
            graph.AddEdge("1", "6"); 
            graph.AddEdge("1", "7",2);
            graph.AddEdge("7", "3");
            graph.AddEdge("7", "4");
            graph.AddEdge("7", "2");
            graph.AddEdge("2", "5",11);
            graph.AddEdge("5", "6");
            graph.AddEdge("6", "3");
            graph.AddEdge("3", "4",8);

            return graph;
        }


        public DirectedGraph<string> GetExampleDirectedGraph()
        {
            DirectedGraph<string> graph = new DirectedGraph<string>();

            var node1 = "1";
            var node2 = "2";
            var node3 = "3";
            var node4 = "4";
            var node5 = "5";
            var node6 = "6";


            graph.AddNode(node1);
            graph.AddNode(node2);
            graph.AddNode(node3);
            graph.AddNode(node4);
            graph.AddNode(node5);
            graph.AddNode(node6);

            graph.AddEdge(node1, node3, 9);
            graph.AddEdge(node1, node6, 14);
            graph.AddEdge(node1, node2, 7);
            graph.AddEdge(node2, node3, 10);
            graph.AddEdge(node2, node4, 15);
            graph.AddEdge(node3, node6, 2);
            graph.AddEdge(node3, node4, 11);
            graph.AddEdge(node4, node5, 6);
            graph.AddEdge(node5, node6, 9);

            return graph;

        }

        public Graph<string> ConstractGraph(string filePath)
        {
            string[] lines = ReadFile(filePath);

            var nodes = Convert.ToInt32(lines[0]);
            var edges = Convert.ToInt64(lines[1]);

            Graph<string> graph = new UndirectedGraph<string>();

            for (int i = 0; i < nodes; i++)
            {
                graph.AddNode(i.ToString());
            }


            // Parallel.For(0L,edges, index => graph.AddEdge(1, 2));

            for (long i = 0; i < edges; i++)
            {

                var e = lines[i + 2].Split();
                graph.AddEdge(e[0], e[1]);
                //graph.AddEdge(1, 2);
            }

            return graph;
        }

        public string[] ReadFile(string filePath)
        {
            var AllLines = new string[7586067]; //only allocate memory here

            using (StreamReader sr = File.OpenText(filePath))
            {
                ulong x = 0;
                while (!sr.EndOfStream)
                {
                    AllLines[x] = sr.ReadLine();
                    x += 1;
                }
                sr.Close();
            } //Finished. Close the file

              //Now parallel process each line in the fil
            return AllLines;

        }


    }
}
