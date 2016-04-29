using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace VisualAlgorithms.Business.Models
{

    public abstract class Graph<T>
    {
        //public List<Node<T>> NodeList { get; set; }
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

        public void AddEdge(int from, int to, double weight = 0)
        {
            var fromNode = GetNode(from);
            var toNode = GetNode(to);

            if (fromNode == null || toNode == null)
                return;

            fromNode.AddNeigbour(toNode.Id, weight);
        }

        public void AddEdge(T from, T to, double weight = 0)
        {
            var fromNode = GetNode(from);
            var toNode = GetNode(to);

            if (fromNode == null || toNode == null)
                return;

            fromNode.AddNeigbour(toNode.Id, weight);
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
