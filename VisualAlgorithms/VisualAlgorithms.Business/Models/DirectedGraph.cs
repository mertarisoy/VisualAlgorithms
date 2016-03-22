using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualAlgorithms.Business.Models
{
    public class DirectedGraph : IGraph
    {
        private static int _maxNodes;
        private int E = 0;
        private List<List<int>> adjacencyList;

        public DirectedGraph(int v)
        {
            _maxNodes = v;
            adjacencyList = new List<List<int>>(v);
            for (int i = 0; i < v; i++)
            {
                adjacencyList.Add(new List<int>());
            }
        }
        public IEnumerable<int> GetNeighbours(int v)
        {
            if (v < _maxNodes)
            {
                return adjacencyList[v].AsEnumerable();
            }
            return null;
        }

        public void AddEdge(int src, int dst)
        {
            if (src < _maxNodes && dst < _maxNodes)
            {
                adjacencyList[src].Add(dst);
                adjacencyList[dst].Add(src);
            }
        }
    }
}
