using System;
using System.Collections.Generic;
using System.Linq;

namespace VisualAlgorithms.Business.Models
{

    public abstract class Graph<T> where T : IComparable<T>
    {
        private readonly Dictionary<int, Node<T>> _nodeList; // Get nodes in O time with id
        private int _nextNodeId;

        protected Graph()
        {
            this._nodeList = new Dictionary<int, Node<T>>();
        }

        protected Graph(List<Node<T>> nodesList)
        {
            setNodeList(nodesList);
        }

        public List<Node<T>> getNodeList()
        {
            var returnList = _nodeList.Select(pair => pair.Value).ToList();

            return returnList;
        }

        private void setNodeList(List<Node<T>> gettedList)
        {
            foreach (var node in gettedList)
            {
                node.Id = _nextNodeId++;
                _nodeList.Add(node.Id, node);
            }
        }
        

        public void AddNode(Node<T> node)
        {
            node.Id = _nextNodeId++;
            this._nodeList.Add(node.Id, node);
        }

        public void AddNode(T data)
        {
            var node = new Node<T>(data);
            AddNode(node);
        }

        public virtual void AddEdge(Node<T> from,Node<T> to, double weight = 0)
        {

            AddEdge(from.Id, to.Id, weight);
        }

        public virtual void AddEdge(int from, int to, double weight = 0)
        {
            var fromNode = GetNode(from);
            var toNode = GetNode(to);

            if (fromNode == null || toNode == null)
                return;

            Edge edge = new Edge(to, weight);
            edge.Id = from.ToString() + to;

            fromNode.AddNeigbour(edge);
        }

        public virtual void AddEdge(T from, T to, double weight = 0)
        {
            var fromNode = GetNode(from);
            var toNode = GetNode(to);

            if (fromNode == null || toNode == null)
                return;

            AddEdge(fromNode.Id, toNode.Id, weight);
        }


        public Node<T> GetNode(int id)
        {
            return _nodeList[id];
        }

        public Node<T> GetNode(T data)
        {
            return _nodeList.FirstOrDefault(x => x.Value.Data.Equals(data)).Value;
        }

        public int CountNodes()
        {
            return _nodeList.Count();
        }




    

    }
}
