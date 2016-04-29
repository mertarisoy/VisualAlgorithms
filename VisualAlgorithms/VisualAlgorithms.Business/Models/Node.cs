using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VisualAlgorithms.Business.Models
{
    public class Node<T>
    {
        public int Id { get; internal set; }
        public T Data { get; set; }
        public LinkedList<Edge<T>> EdgeList { get; set; }

        public Node()
        {
            this.EdgeList = new LinkedList<Edge<T>>();
        }

        public Node(T data) : this()
        {         
            this.Data = data;
        }

        public Node(T data, LinkedList<Edge<T>> neigbours) : this(data)
        {
            this.EdgeList = neigbours;
        }

        public void AddNeigbour(int destinationId)
        {
            var edge = new Edge<T>(destinationId);
            EdgeList.AddLast(edge);
        }
        public void AddNeigbour(int destinationId, double weight)
        {
            var edge = new Edge<T>(destinationId,weight);
            AddNeigbour(edge);
        }

        public void AddNeigbour(Edge<T> edge)
        {
            EdgeList.AddLast(edge);
        }

    }
}
