using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualAlgorithms.Business.Models
{
    public class UndirectedGraph : Graph
    {
        public UndirectedGraph(int v) : base(v)
        {
            
        }

        public new void AddEdge(int src, int dst, double? weight)
        {
            base.AddEdge(src, dst, weight);
            base.AddEdge(dst, src, weight);
        }
    }
}
