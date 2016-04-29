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
        public List<Node<T>> NodeList { get; set; }
        //public Dictionary<int,Node<T>> NodeList { get; set; } // Get nodes in O time with id
        private int _nextNodeId = 0;

        protected Graph()
        {
            this.NodeList = new List<Node<T>>();
        }

        protected Graph(List<Node<T>> nodesList)
        {
            NodeList = nodesList;
            foreach (var node in nodesList)
            {
                node.Id = _nextNodeId++;
            }
        }

        public void AddNode(Node<T> node)
        {
            node.Id = _nextNodeId++;
            this.NodeList.Add(node);
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
            return NodeList.Find(x => x.Id == id);
        }

        public Node<T> GetNode(T data)
        {
            return NodeList.Find(x => x.Data.Equals(data));
        }

        public int CountNodes()
        {
            return NodeList.Count();
        }



    

    }
}
