using System;

namespace VisualAlgorithms.Business.Models
{

    public class Edge<T> : IComparable<Edge<T>> 
    {
        public int DestinationId { get; set; }
        public double Weight { get; set; }
        public string Label { get; set; }
        public string Id { get; internal set; }


        public Edge(int destinationId,double weight = 0,string label = "",string id = "")
        {
            this.DestinationId = destinationId;
            this.Label = label;
            this.Id = id;
            this.Weight = weight;
        }


        public int CompareTo(Edge<T> other)
        {
            return DestinationId.CompareTo(other.DestinationId);
        }


        public override int GetHashCode()
        {
            return DestinationId;
        }
    }
}
