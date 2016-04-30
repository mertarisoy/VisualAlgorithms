namespace VisualAlgorithms.Business.Models
{
    public class UndirectedGraph<T> : Graph<T>
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

            Edge<T> edgeTo = new Edge<T>(to, weight);
            edgeTo.Id = from.ToString() + to;

            Edge<T> edgeFrom = new Edge<T>(from, weight);
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
