using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualAlgorithms.Business.Models;

namespace VisualAlgorithms.Business
{
    public class GraphGenerator
    {

        public Graph<string> GenerateUndirctedGraph()
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

                graph.AddEdge(from, to);
            }

            return graph;
        }

        public Graph<string> GenerateDirectedGraph()
        {

            Random rnd = new Random();
            return null;


        }
    }
}
