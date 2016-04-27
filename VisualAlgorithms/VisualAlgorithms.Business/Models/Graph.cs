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

    //public abstract class Graph
    //{
    //    [JsonProperty] protected static int _maxNodes;
    //    protected int E;
    //    [JsonProperty] protected List<List<Edge>> adjacencyList;
    //    [JsonProperty(PropertyName = "nodes")] protected List<Node> vertexList;

    //    protected Graph(int v)
    //    {
    //        _maxNodes = v;

    //        vertexList = new List<Node>();
    //        adjacencyList = new List<List<Edge>>(v);
    //        for (int i = 0; i < v; i++)
    //        {
    //            adjacencyList.Add(new List<Edge>());
    //        }
    //    }

    //    public void AddVertex(Node v)
    //    {
    //        if (vertexList.Count < _maxNodes)
    //        {
    //            v.Id = vertexList.Count;
    //            vertexList.Add(v);
    //        }
    //    }

    //    public Node GetVertex(int v)
    //    {
    //        if (v < vertexList.Count)
    //        {
    //            return vertexList[v];
    //        }
    //        return null;
    //    }

    //    public int GetId(string vertex)
    //    {
    //        var data = vertexList.AsEnumerable().Single(x => x.Name.Equals(vertex));
    //        return data != null ? data.Id : -1;
    //    }

    //    public List<Edge> GetNeighbours(int v)
    //    {
    //        if (v < _maxNodes)
    //        {
    //            return adjacencyList[v];
    //        }
    //        return null;
    //    }

    //    public List<Edge> GetNeighbours(string name)
    //    {
    //        var vertex = vertexList.AsEnumerable().Single(x => x.Name.Equals(name));
    //        if (vertex != null)
    //        {
    //            return GetNeighbours(vertex.Id);
    //        }
    //        return null;
    //    }

    //    public void AddEdge(int src, int dst, double? weight)
    //    {
    //        if (src < _maxNodes && dst < _maxNodes)
    //        {
    //            var edge = new Edge() {Source = src, Destination = dst, Weight = weight ?? 0};
    //            var edgeReverse = new Edge() {Source = dst, Destination = src, Weight = weight ?? 0};

    //            adjacencyList[src].Add(edge);
    //            adjacencyList[dst].Add(edgeReverse);
    //        }
    //    }

    //    public void AddEdge(string src, string dst, double? weight)
    //    {
    //        var list = vertexList.AsEnumerable();
    //        var source = list.Single(x => x.Name.Equals(src));
    //        var destination = list.Single(x => x.Name.Equals(dst));

    //        if (source != null && destination != null)
    //        {
    //            AddEdge(source.Id, destination.Id, weight);
    //        }
    //    }

    //    public int Count()
    //    {
    //        return vertexList.Count;
    //    }

    //    public string ToJSONString()
    //    {

    //        var nodes =
    //            vertexList.Select(
    //                x => new {data = new {id = x.Name}, position = new { x = x.Position.X, y = x.Position.Y } });

    //        var list = new List<Edge>();
    //        foreach (var edgeList in adjacencyList)
    //        {
    //            list.AddRange(edgeList);
    //        }

    //        var edges = list.Select(x => new
    //        {
    //            data = new
    //            {
    //                id = x.Source.ToString() + x.Destination,
    //                source = GetVertex(x.Source).Name,
    //                target = GetVertex(x.Destination).Name
    //            }
    //        });

    //        var elements = new {nodes = nodes, edges = edges};
    //        JavaScriptSerializer serializer = new JavaScriptSerializer();
    //        return serializer.Serialize(elements);
    //    }
    //}

    public abstract class Graph<T>
    {
        public List<Node<T>> NodeList { get; set; }
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
            NodeList.Add(node);
        }

        public void AddNode(T data)
        {
            var node = new Node<T>(data);
            AddNode(node);
        }

        public void AddEdge(Node<T> from,Node<T> to, double weight = 0)
        {
            AddEdge(from.Id, to.Id, weight);
        }

        public void AddEdge(int from, int to, double weight = 0)
        {
            var fromNode = GetNode(from);
            var toNode = GetNode(to);

            if (fromNode == null || toNode == null)
                return;

            fromNode.AddNeigbour(toNode, weight);
        }

        public void AddEdge(T from, T to, double weight = 0)
        {
            var fromNode = GetNode(from);
            var toNode = GetNode(to);

            if (fromNode == null || toNode == null)
                return;

            fromNode.AddNeigbour(toNode, weight);
        }


        public Node<T> GetNode(int id)
        {
            return NodeList.Find(x => x.Id == id);
        }

        public Node<T> GetNode(T data)
        {
            return NodeList.Find(x => x.Data.Equals(data));
        }

        public string ToJsonString()
        {


            return null;

        }

    }
}
