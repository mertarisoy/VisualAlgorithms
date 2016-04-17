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

        public Graph GenerateUndirctedGraph()
        {  
            Random rnd = new Random();

            int nodesCount = rnd.Next(2, 10);
            DirectedGraph g = new DirectedGraph(nodesCount);

            int edgesCount = rnd.Next(0, (nodesCount * (nodesCount -1)) / 2);
            for (int i = 0; i < nodesCount; i++)
            {
                var vertex = new Vertex()
                {
                    Name = ((char)('A' + i)).ToString(),
                    Position = new Point() {X = rnd.Next(-300, 300), Y = rnd.Next(-300, 300)}
                };
                g.AddVertex(vertex);
            }

            for (int i = 0; i < edgesCount; i++)
            {
                g.AddEdge(rnd.Next(0, nodesCount), rnd.Next(0, nodesCount),rnd.Next(0,50));
            }
            return g;
        }

        public Graph GenerateDirectedGraph()
        {

            Random rnd = new Random();

            int nodesCount = rnd.Next(2, 10);
            DirectedGraph g = new DirectedGraph(nodesCount);

            return g;
        }
    }
}
