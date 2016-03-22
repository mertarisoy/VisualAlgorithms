using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualAlgorithms.Business.Models
{
    public interface IGraph
    {
        IEnumerable<int> GetNeighbours(int v);
        void AddEdge(int src, int dst);
    }
}
