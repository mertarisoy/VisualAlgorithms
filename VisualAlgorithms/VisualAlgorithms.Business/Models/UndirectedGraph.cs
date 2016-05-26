using System;

namespace VisualAlgorithms.Business.Models
{
    public class UndirectedGraph<T> : Graph<T> where T : IComparable<T>
    {   
        public override void AddEdge(Node<T> from, Node<T> to, double weight = 0)
        {

            AddEdge(from.Id, to.Id, weight);
        }

        public override void AddEdge(int from, int to, double weight = 0)
        {
            var fromNode = GetNode(from);
            var toNode = GetNode(to);

            if (fromNode == null || toNode == null)
                return;

            Edge edgeTo = new Edge(to, weight);
            edgeTo.Id = "e" +  from + to;

            Edge edgeFrom = new Edge(from, weight);
            edgeFrom.Id = edgeTo.Id;
            fromNode.AddNeigbour(edgeTo);
            toNode.AddNeigbour(edgeFrom);
        }

        public override void AddEdge(T from, T to, double weight = 0)
        {
            var fromNode = GetNode(from);
            var toNode = GetNode(to);

            if (fromNode == null || toNode == null)
                return;

            AddEdge(fromNode.Id, toNode.Id, weight);
        }
    }
}
