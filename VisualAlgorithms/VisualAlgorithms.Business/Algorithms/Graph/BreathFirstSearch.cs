using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualAlgorithms.Business.Models;

namespace VisualAlgorithms.Business.Algorithms.Graph
{
    public class BreathFirstSearch<T>
    {
        private Graph<T> graph;
        private bool[] visited; 

        public BreathFirstSearch(Graph<T> graph)
        {
            this.graph = graph;
            this.visited = new bool[graph.CountNodes()];
        }
        public void doBFS(int start)
        {
            Queue<int> queue = new Queue<int>(graph.CountNodes());

            visited[start] = true;

            queue.Enqueue(start);
            while (queue.Any())
            {
                var v = queue.Dequeue();
                //var neigbours = graph.NodeList.

                if (visited[v])
                    continue;

                //for(int i = 0; i < neigbours.EdgeList.c)
            }



        }
    }
}
