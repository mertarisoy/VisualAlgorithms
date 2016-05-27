using System;
using System.IO;
using VisualAlgorithms.Business.Models;
using System.Web.Hosting;
using VisualAlgorithms.Common;

namespace VisualAlgorithms.Business
{
    public static class GraphGenerator
    {
        
        //public UndirectedGraph<string> GenerateUndirctedGraph()
        //{  
        //    Random rnd = new Random();

        //    var nodesCount = rnd.Next(2, 10);
        //    var graph = new UndirectedGraph<string>();

        //    for (int i = 0; i < nodesCount; i++)
        //    {
        //        graph.AddNode(((char)('A' + i)).ToString());
        //    }

        //    var edgeCount = rnd.Next(1, nodesCount*(nodesCount - 1)/2);

        //    for (int i = 0; i < edgeCount; i++)
        //    {
        //        var from = rnd.Next(0, nodesCount);
        //        var to = rnd.Next(0, nodesCount);

        //        if (from == to)
        //        {
        //            i--;
        //            continue;
        //        }

        //        graph.AddEdge(from, to);
        //    }

        //    return graph;
        //}

        //public Graph<string> GenerateDirectedAcyclicGraph()
        //{

        //    Random rnd = new Random();

        //    var nodesCount = rnd.Next(2, 10);
        //    var graph = new DirectedGraph<string>();

        //    for (int i = 0; i < nodesCount; i++)
        //    {
        //        graph.AddNode(((char)('A' + i)).ToString());
        //    }

        //    var edgeCount = rnd.Next(1, nodesCount * (nodesCount - 1) / 2);

        //    for (int i = 0; i < edgeCount; i++)
        //    {
        //        var from = rnd.Next(0, nodesCount);
        //        var to = rnd.Next(0, nodesCount);

        //        if (from >= to)
        //        {
        //            i--;
        //            continue;
        //        }

        //        graph.AddEdge(from, to);
        //    }

        //    return graph;


        //}

        //public Graph<string> GenerateDirectedGraph()
        //{
        //    Random rnd = new Random();

        //    var nodesCount = rnd.Next(2, 10);
        //    var graph = new DirectedGraph<string>();

        //    for (int i = 0; i < nodesCount; i++)
        //    {
        //        graph.AddNode(((char)('A' + i)).ToString());
        //    }

        //    var edgeCount = rnd.Next(1, nodesCount * (nodesCount - 1) / 2);

        //    for (int i = 0; i < edgeCount; i++)
        //    {
        //        var from = rnd.Next(0, nodesCount);
        //        var to = rnd.Next(0, nodesCount);

        //        if (from == to)
        //        {
        //            i--;
        //            continue;
        //        }

        //        graph.AddEdge(from, to);
        //    }

        //    return graph;


        //}

        //public UndirectedGraph<string> GetExampleGraph()
        //{
        //    UndirectedGraph<string> graph = new UndirectedGraph<string>();

        //    graph.AddNode("0");
        //    graph.AddNode("1");
        //    graph.AddNode("2");
        //    graph.AddNode("3");
        //    graph.AddNode("4");
        //    graph.AddNode("5");
        //    graph.AddNode("6");
        //    graph.AddNode("7");


        //    graph.AddEdge("0", "6",5);
        //    graph.AddEdge("0", "3",3); 
        //    graph.AddEdge("0", "7"); 
        //    graph.AddEdge("0", "5"); 
        //    graph.AddEdge("0", "1"); 
        //    graph.AddEdge("1", "6"); 
        //    graph.AddEdge("1", "7",2);
        //    graph.AddEdge("7", "3");
        //    graph.AddEdge("7", "4");
        //    graph.AddEdge("7", "2");
        //    graph.AddEdge("2", "5",11);
        //    graph.AddEdge("5", "6");
        //    graph.AddEdge("6", "3");
        //    graph.AddEdge("3", "4",8);

        //    return graph;
        //}


        //public DirectedGraph<string> GetExampleDirectedGraph()
        //{
        //    DirectedGraph<string> graph = new DirectedGraph<string>();

        //    var node1 = "1";
        //    var node2 = "2";
        //    var node3 = "3";
        //    var node4 = "4";
        //    var node5 = "5";
        //    var node6 = "6";


        //    graph.AddNode(node1);
        //    graph.AddNode(node2);
        //    graph.AddNode(node3);
        //    graph.AddNode(node4);
        //    graph.AddNode(node5);
        //    graph.AddNode(node6);

        //    graph.AddEdge(node1, node3, 9);
        //    graph.AddEdge(node1, node6, 14);
        //    graph.AddEdge(node1, node2, 7);
        //    graph.AddEdge(node2, node3, 10);
        //    graph.AddEdge(node2, node4, 15);
        //    graph.AddEdge(node3, node6, 2);
        //    graph.AddEdge(node3, node4, 11);
        //    graph.AddEdge(node4, node5, 6);
        //    graph.AddEdge(node5, node6, 9);

        //    return graph;

        //}

        //public DirectedGraph<string> GetExampleGraphForTarjan()
        //{
        //    DirectedGraph<string> graph = new DirectedGraph<string>();

        //    graph.AddNode("5");
        //    graph.AddNode("1");
        //    graph.AddNode("2");
        //    graph.AddNode("3");
        //    graph.AddNode("4");
        //    graph.AddNode("6");
        //    graph.AddNode("7");
        //    graph.AddNode("8");

        //    graph.AddEdge("1", "2");
        //    graph.AddEdge("2", "3");
        //    graph.AddEdge("3", "1");
        //    graph.AddEdge("4", "2");
        //    graph.AddEdge("4", "3");
        //    graph.AddEdge("4", "5");
        //    graph.AddEdge("5", "4");
        //    graph.AddEdge("5", "6");
        //    graph.AddEdge("6", "3");
        //    graph.AddEdge("6", "7");
        //    graph.AddEdge("7", "6");
        //    graph.AddEdge("8", "7");
        //    graph.AddEdge("8", "8");
        //    graph.AddEdge("8", "5");

        //    return graph;
        //}

        private static Graph<string> ConstractGraph(string filePath, GraphType graphType)
        {
            string[] lines = ReadFile(filePath);

            var nodes = Convert.ToInt32(lines[0]);
            var edges = Convert.ToInt64(lines[1]);
            Graph<string> graph;

            switch (graphType)
            {
                case GraphType.DIRECTED_GRAPH:
                    graph = new DirectedGraph<string>();
                    break;
                case GraphType.UNDIRECTED_GRAPH:
                    graph = new UndirectedGraph<string>();
                    break;
                default:
                    graph = new UndirectedGraph<string>();
                    break;
            }
            

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

        private static string[] ReadFile(string filePath)
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

        public static Graph<string> GetDirectedGraph(int start = 0, GraphSize graphSize = GraphSize.SMALL)
        {
            Graph<string> graph;

            switch (graphSize)
            {
                case GraphSize.SMALL:
                    graph = ConstractGraph(HostingEnvironment.MapPath("~/Resources/graph_small.txt"), GraphType.DIRECTED_GRAPH);
                    break;
                case GraphSize.MEDIUM:
                    graph = ConstractGraph(HostingEnvironment.MapPath("~/Resources/graph_medium.txt"), GraphType.DIRECTED_GRAPH);
                    break;
                case GraphSize.LARGE:
                    graph = ConstractGraph(HostingEnvironment.MapPath("~/Resources/graph_large.txt"), GraphType.DIRECTED_GRAPH);
                    break;
                default:
                    graph = ConstractGraph(HostingEnvironment.MapPath("~/Resources/graph_small.txt"), GraphType.DIRECTED_GRAPH);
                    break;
            }

            return graph;
            //return Json(new { graph = graph.ToJsonString(), path = animationList }, JsonRequestBehavior.AllowGet);

        }

        public static Graph<string> GetUndirectedGraph(int start = 0, GraphSize graphSize = GraphSize.SMALL)
        {
            Graph<string> graph;

            switch (graphSize)
            {
                case GraphSize.SMALL:
                    graph = ConstractGraph(HostingEnvironment.MapPath("~/Resources/graph_small.txt"), GraphType.UNDIRECTED_GRAPH);
                    break;
                case GraphSize.MEDIUM:
                    graph = ConstractGraph(HostingEnvironment.MapPath("~/Resources/graph_medium.txt"), GraphType.UNDIRECTED_GRAPH);
                    break;
                case GraphSize.LARGE:
                    graph = ConstractGraph(HostingEnvironment.MapPath("~/Resources/graph_large.txt"), GraphType.UNDIRECTED_GRAPH);
                    break;
                default:
                    graph = ConstractGraph(HostingEnvironment.MapPath("~/Resources/graph_small.txt"), GraphType.UNDIRECTED_GRAPH);
                    break;
            }


            return graph;
            //return Json(new { graph = graph.ToJsonString(), path = animationList }, JsonRequestBehavior.AllowGet);

        }




    }
}
