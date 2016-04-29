using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualAlgorithms.Business.Models
{
    public class UndirectedGraph<T> : Graph<T>
    {



        public override void AddEdge(Node<T> from, Node<T> to, double weight = 0)
        {
            AddEdge(from.Id, to.Id, weight);
        }

        public new void AddEdge(int from, int to, double weight = 0)
        {
            var fromNode = GetNode(from);
            var toNode = GetNode(to);

            if (fromNode == null || toNode == null)
                return;

            toNode.AddNeigbour(fromNode.Id, weight);
            fromNode.AddNeigbour(toNode.Id, weight);
        }

        public new void AddEdge(T from, T to, double weight = 0)
        {
            var fromNode = GetNode(from);
            var toNode = GetNode(to);

            if (fromNode == null || toNode == null)
                return;

            toNode.AddNeigbour(fromNode.Id, weight);
            fromNode.AddNeigbour(toNode.Id, weight);
        }
    }
}
