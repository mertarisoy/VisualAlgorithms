using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualAlgorithms.Business.Models
{
    //public class Edge
    //{
    //    public int Source { get; set; }
    //    public int Destination { get; set; }
    //    public double Weight { get; set; }

    //}

    public class Edge<T> : IComparable<Edge<T>> 
    {
        public Node<T> Destination { get; set; }
        public double Weight { get; set; }
        public string Label { get; set; }
        public string Id { get; set; }


        public Edge(Node<T> destination, string label = "",string id = "")
        {
            this.Destination = destination;
            this.Label = label;
            this.Id = id;

        }

        public Edge(Node<T> destination, double weight, string label = "", string id = "") 
            : this(destination,label,id)
        {
            this.Weight = weight;
            this.Label = label;
        }


        public int CompareTo(Edge<T> other)
        {
            return Weight.CompareTo(other.Weight);
        }
    }
}
