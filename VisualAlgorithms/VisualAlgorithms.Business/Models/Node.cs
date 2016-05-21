using System;
using System.Collections.Generic;
using System.Linq;

namespace VisualAlgorithms.Business.Models
{
    public class Node<T>
    {
        public int Id { get; internal set; }
        public T Data { get; set; }
        public SortedSet<Edge<T>> EdgeList { get; set; }

        public Node()
        {
            this.EdgeList = new SortedSet<Edge<T>>();
        }

        public Node(T data) : this()
        {
            this.Data = data;
        }

        public Node(T data, SortedSet<Edge<T>> neigbours) : this(data)
        {
            this.EdgeList = neigbours;
        }

        public void AddNeigbour(int destinationId)
        {
            var edge = new Edge<T>(destinationId);
            EdgeList.Add(edge);
        }
        public void AddNeigbour(int destinationId, double weight)
        {
            var edge = new Edge<T>(destinationId, weight);
            AddNeigbour(edge);
        }

        public void AddNeigbour(Edge<T> edge)
        {
            EdgeList.Add(edge);
        }

        public int GetClosestNeighbor()
        {
            return this.EdgeList.OrderBy(x => x.Weight).FirstOrDefault().DestinationId;
        }

        public List<Tuple<int, double>> GetNeighbors()
        {
            List<Tuple<int, double>> listNeighbors = new List<Tuple<int, double>>();
            foreach (Edge<T> edge in EdgeList)
            {
                Tuple<int, double> oneTuple = new Tuple<int, double>(edge.DestinationId, edge.Weight);
                listNeighbors.Add(oneTuple);
            }
            return listNeighbors;
        }

        //public double GetWeight(int destId)
        //{
        //    double distance = -1;
        //    foreach (Edge<T> edge in EdgeList)
        //    {
        //        if (edge.DestinationId == destId)
        //            distance = edge.Weight;
        //    }
        //    return distance;
        //}

        //public int CompareTo(Node<T> node)
        //{

        //}
    }
}
