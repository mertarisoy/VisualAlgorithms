using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace VisualAlgorithms.Business.Models
{
    public class Node<T> : IComparable<Node<T>> where T : IComparable<T>
    {
        public int Id { get; internal set; }
        public T Data { get; set; }
        public HashSet<Edge> EdgeList { get; set; }

        public Node()
        {
            this.EdgeList = new HashSet<Edge>();
        }

        public Node(T data) : this()
        {
            this.Data = data;
        }

        public Node(T data, HashSet<Edge> neigbours) : this(data)
        {
            this.EdgeList = neigbours;
        }

        public void AddNeigbour(int destinationId)
        {
            var edge = new Edge (destinationId);
            EdgeList.Add(edge);
        }
        public void AddNeigbour(int destinationId, double weight)
        {
            var edge = new Edge (destinationId, weight);
            AddNeigbour(edge);
        }

        public void AddNeigbour(Edge edge)
        {
            EdgeList.Add(edge);
        }

        //public int GetClosestNeighbor()
        //{
        //    return this.EdgeList.OrderBy(x => x.Weight).FirstOrDefault().DestinationId;
        //}

        public HashSet<Edge> GetNeighbors()
        {
            //List<Tuple<int, double>> listNeighbors = new List<Tuple<int, double>>();
            //foreach (Edge edge in EdgeList)
            //{
            //    Tuple<int, double> oneTuple = new Tuple<int, double>(edge.DestinationId, edge.Weight);
            //    listNeighbors.Add(oneTuple);
            //}
            //return listNeighbors;

            return this.EdgeList;
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
        public int CompareTo(Node<T> other)
        {
            return this.Data.CompareTo(other.Data);
        }
    }
}
