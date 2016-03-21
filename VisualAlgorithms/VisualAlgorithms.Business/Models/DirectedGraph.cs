using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualAlgorithms.Business.Models
{
    public class DirectedGraph : IGraph
    {
        private int V = 0;
        private int E = 0;
        private List<List<Edge>> adjacencyList; 

        public IEnumerable<Vertex> GetNeighbours(int v)
        {
            throw new NotImplementedException();
        }

        public void AddEdge(int src, int dst)
        {
            throw new NotImplementedException();
        }
    }
}
