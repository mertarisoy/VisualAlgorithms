using System.Collections.Generic;

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
            var edge = new Edge<T>(destinationId,weight);
            AddNeigbour(edge);
        }

        public void AddNeigbour(Edge<T> edge)
        {
            EdgeList.Add(edge);
        }


        //TO FIX : priority queue icin compareTo fonksiyonu gerekiyo
        public int GetClosestNeighbor()
        {
            double distance = double.MaxValue;
            int destinationID = -1;
            foreach(Edge<T> edge in EdgeList)
            {
                if(edge.Weight <= distance)
                {
                    distance = edge.Weight;
                    destinationID = edge.DestinationId;
                }   
            }
            return destinationID;
        }

        public double GetWeight(int destId)
        {
            double distance = -1;
            foreach (Edge<T> edge in EdgeList)
            {
                if (edge.DestinationId == destId)
                    distance = edge.Weight;
            }
            return distance;
        }
        /*
        public int CompareTo(Node<T> node)
        {
            
        }*/
    }
}
