using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using VisualAlgorithms.Business.Models;

namespace VisualAlgorithms.Business.Algorithms.Graph
{
    public class BreathFirstSearch<T>
    {
        private Graph<T> graph;
        private bool[] visited;
        public List<Tuple<bool, string>> animationQueueList;

        public List<AnimationItem> animationList;
        // public List<Tuple<int, int>> edgeList = new List<Tuple<int,int>>();

        public BreathFirstSearch(Graph<T> graph)
        {
            this.graph = graph;
            this.animationList = new List<AnimationItem>();
            this.visited = new bool[graph.CountNodes()];
            this.animationQueueList = new List<Tuple<bool, string>>();
        }
        public List<AnimationItem> doBFS(int start)
        {
            Queue<int> queue = new Queue<int>(graph.CountNodes());
            Queue<string> queueEdge = new Queue<string>(graph.CountNodes());


            List<string> animationNodesList = new List<string>();
            

            queue.Enqueue(start);
            animationList.Add(new AnimationItem(AnimationItem.QueueAdd, start.ToString()));

            visited[start] = true;
            while (queue.Any())
            {
                animationList.Add(new AnimationItem(AnimationItem.QueueRemove, queue.Peek().ToString()));
                var v = queue.Dequeue();               


                var neigbours = graph.GetNode(v).EdgeList;
                if (queueEdge.Any())
                    animationList.Add(new AnimationItem(AnimationItem.EdgeHighlight, queueEdge.Dequeue()));
                animationList.Add(new AnimationItem(AnimationItem.NodeHighlight, graph.GetNode(v).Id.ToString()));

                //Debug.Write("->" + graph.GetNode(v).Data);

                foreach (var neigbour in neigbours)
                {
                    if (!visited[neigbour.DestinationId])
                    {
                        visited[neigbour.DestinationId] = true;

                        queueEdge.Enqueue(neigbour.Id);
                       // edgeList.Add(new Tuple<int, int>(v, neigbour.DestinationId));

                        animationList.Add(new AnimationItem(AnimationItem.QueueAdd, neigbour.DestinationId.ToString()));
                        queue.Enqueue(neigbour.DestinationId);
                    }
                }
            }

            foreach (var VARIABLE in animationQueueList)
            {
                Debug.WriteLine(VARIABLE.Item1.ToString() + "---" + VARIABLE.Item2);
            }

            Dictionary<Node<T>, double> dic = new Dictionary<Node<T>, double>();

            return animationList;

        }
    }
}
