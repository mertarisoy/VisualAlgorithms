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
        public List<Tuple<int, int>> edgeList = new List<Tuple<int,int>>();

        public BreathFirstSearch(Graph<T> graph)
        {
            this.graph = graph;
            this.visited = new bool[graph.CountNodes()];
        }
        public List<string> doBFS(int start)
        {
            Queue<int> queue = new Queue<int>(graph.CountNodes());
            Queue<string> queueEdge = new Queue<string>(graph.CountNodes());
            


            List<string> res = new List<string>();
            queue.Enqueue(start);
            visited[start] = true;
            while (queue.Any())
            {
                var v = queue.Dequeue();               


                var neigbours = graph.GetNode(v).EdgeList;
                if(queueEdge.Any())
                res.Add(queueEdge.Dequeue());
                res.Add(graph.GetNode(v).Id.ToString());
                


                Debug.Write("->" + graph.GetNode(v).Data);

                foreach (var neigbour in neigbours)
                {
                    if (!visited[neigbour.DestinationId])
                    {
                        visited[neigbour.DestinationId] = true;

                        queueEdge.Enqueue(v.ToString() + neigbour.DestinationId);
                        edgeList.Add(new Tuple<int, int>(v, neigbour.DestinationId));
                        queue.Enqueue(neigbour.DestinationId);
                    }
                }
            }
            return res;

        }
    }
}
