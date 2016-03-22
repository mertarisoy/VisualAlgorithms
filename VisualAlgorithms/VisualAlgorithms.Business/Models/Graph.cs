using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualAlgorithms.Business.Models
{
    public abstract class Graph
    {
        protected static int _maxNodes;
        protected int E;

        protected List<List<Edge>> adjacencyList;
        protected List<Vertex> vertexList;

        public Graph(int v)
        {
            _maxNodes = v;

            vertexList = new List<Vertex>();
            adjacencyList = new List<List<Edge>>(v);
            for (int i = 0; i < v; i++)
            {
                adjacencyList.Add(new List<Edge>());
            }
        }

        public void AddVertex(Vertex v)
        {
            if (vertexList.Count < _maxNodes)
            {
                v.Id = vertexList.Count;
                vertexList.Add(v);
            }
        }

        public Vertex GetVertex(int v)
        {
            if (v < vertexList.Count)
            {
                return vertexList[v];
            }
            return null;
        }

        public int GetId(string vertex)
        {
            var data = vertexList.AsEnumerable().Single(x => x.Name.Equals(vertex));
            return data != null ? data.Id : -1;
        }

        public List<Edge> GetNeighbours(int v)
        {
            if (v < _maxNodes)
            {
                return adjacencyList[v];
            }
            return null;
        }

        public List<Edge> GetNeighbours(string name)
        {
            var vertex = vertexList.AsEnumerable().Single(x => x.Name.Equals(name));
            if (vertex != null)
            {
                return GetNeighbours(vertex.Id);
            }
            return null;
        }

        public void AddEdge(int src, int dst, double? weight)
        {
            if (src < _maxNodes && dst < _maxNodes)
            {
                var edge = new Edge() { Source = src, Destination = dst, Weight = weight ?? 0 };
                var edgeReverse = new Edge() { Source = dst, Destination = src, Weight = weight ?? 0 };

                adjacencyList[src].Add(edge);
                adjacencyList[dst].Add(edgeReverse);
            }
        }

        public void AddEdge(string src, string dst, double? weight)
        {
            var list = vertexList.AsEnumerable();
            var source = list.Single(x => x.Name.Equals(src));
            var destination = list.Single(x => x.Name.Equals(dst));

            if (source != null && destination != null)
            {
                AddEdge(source.Id, destination.Id, weight);
            }
        }

        public int Count()
        {
            return vertexList.Count;
        }
    }
}
