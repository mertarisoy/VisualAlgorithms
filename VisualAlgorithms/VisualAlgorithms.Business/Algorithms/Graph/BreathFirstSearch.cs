using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using VisualAlgorithms.Business.Models;

namespace VisualAlgorithms.Business.Algorithms.Graph
{
    public class BreathFirstSearch
    {
        private Graph<string> graph;
        private bool[] visited;
        public List<AnimationItem> animationList;

        // public List<Tuple<int, int>> edgeList = new List<Tuple<int,int>>();

        public BreathFirstSearch(Graph<string> graph)
        {
            this.graph = graph;
            this.animationList = new List<AnimationItem>();
            this.visited = new bool[graph.CountNodes()];
        }
        public List<AnimationItem> doBFS(int start)
        {
            Queue<int> queue = new Queue<int>(graph.CountNodes());
            Queue<string> queueEdge = new Queue<string>(graph.CountNodes());


            queue.Enqueue(start);
            animationList.Add(new AnimationItem(AnimationItem.QueueAdd, start.ToString()));

            visited[start] = true;
            while (queue.Any())
            {
                animationList.Add(new AnimationItem(AnimationItem.QueueRemove, queue.Peek().ToString()));
                var v = queue.Dequeue();               


                var neigbours = graph.GetNode(v).EdgeList;
                if (queueEdge.Any())
                    animationList.Add(new AnimationItem(AnimationItem.RedHighlight, queueEdge.Dequeue()));
                animationList.Add(new AnimationItem(AnimationItem.RedHighlight, graph.GetNode(v).Id.ToString()));

                foreach (var neigbour in neigbours)
                {
                    if (!visited[neigbour.DestinationId])
                    {
                        visited[neigbour.DestinationId] = true;

                        queueEdge.Enqueue(neigbour.Id);

                        animationList.Add(new AnimationItem(AnimationItem.QueueAdd, neigbour.DestinationId.ToString()));
                        queue.Enqueue(neigbour.DestinationId);
                    }
                }
            }

            return animationList;

        }
    }
}
