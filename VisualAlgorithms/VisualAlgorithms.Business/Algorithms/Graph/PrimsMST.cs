using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;
using VisualAlgorithms.Business.Models;

namespace VisualAlgorithms.Business.Algorithms.Graph
{
    public class PrimsMST
    {

        private Graph<string> graph { get; set; }
        private bool[] visited;

        public List<AnimationItem> AnimationList { get; set; }

        public PrimsMST(Graph<string> graph)
        {
            this.graph = graph;
            visited = new bool[graph.CountNodes()];
            AnimationList = new List<AnimationItem>();
        }


        public List<AnimationItem> doMST(int start)
        {

            List<Edge> resultSet = new List<Edge>();
            IPriorityQueue<Edge> queue = new SimplePriorityQueue<Edge>();
            
            var startNode = graph.GetNode(start);

            AnimationList.Add(new AnimationItem(AnimationItem.RedHighlight, startNode.Id.ToString()));

            foreach (var edge in startNode.EdgeList)
            {
                queue.Enqueue(edge, edge.Weight);
                AnimationList.Add(new AnimationItem(AnimationItem.QueueAdd, edge.Id));

            }

            while (resultSet.Count != graph.CountNodes())
            {
                var minEdge = queue.Dequeue();
                AnimationList.Add(new AnimationItem(AnimationItem.QueueRemove, minEdge.Id.ToString()));
                AnimationList.Add(new AnimationItem(AnimationItem.RedHighlight, minEdge.Id.ToString()));
                AnimationList.Add(new AnimationItem(AnimationItem.RedHighlight, minEdge.DestinationId.ToString()));

                resultSet.Add(minEdge);
                var neigbour = graph.GetNode(minEdge.DestinationId);

                foreach (var edge in neigbour.EdgeList)
                {
                    queue.Enqueue(edge, edge.Weight);
                    AnimationList.Add(new AnimationItem(AnimationItem.QueueAdd, edge.Id));
                }
            }

            return AnimationList;

        }
    }
}
