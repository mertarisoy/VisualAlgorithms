using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualAlgorithms.Business.Models
{
    public class UndirectedGraph<T> : Graph<T>
    {

        public new void AddEdge(int from, int to, double weight = 0)
        {
            var fromNode = GetNode(from);
            var toNode = GetNode(to);

            if (fromNode == null || toNode == null)
                return;

            toNode.AddNeigbour(fromNode, weight);
            fromNode.AddNeigbour(toNode, weight);
        }
    }
}
