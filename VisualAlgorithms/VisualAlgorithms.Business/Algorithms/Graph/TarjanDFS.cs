using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualAlgorithms.Business.Models;

namespace VisualAlgorithms.Business.Algorithms.Graph
{
    public class TarjanDFS
    {
        private Graph<string> graph;
        private List<List<Node<string>>> SSCs;
        private bool[] visited;
        private int[] low;
        private int?[] time;
        private bool[] onStack;
        private Stack<int> stack; 

        private int index = 0;
        public TarjanDFS (Graph<string> graph)
        {
            this.graph = graph;
            this.SSCs = new List<List<Node<string>>>(graph.CountNodes());
            this.visited = new bool[graph.CountNodes()];
            this.low = new int[graph.CountNodes()];
            this.time = new int?[graph.CountNodes()];
            this.onStack = new bool[graph.CountNodes()];
            this.stack = new Stack<int>(graph.CountNodes());
        }

        public List<List<Node<string>>> doDFS()
        {
            foreach (var node in graph.getNodeList())
            {
                if (time[node.Id] == null)
                {
                    StrongConnect(node.Id);
                }
            }

            return this.SSCs;
        }

        private void StrongConnect(int v)
        {
            time[v] = index;
            low[v] = index;

            index++;

            stack.Push(v);
            onStack[v] = true;

            foreach (var edge in graph.GetNode(v).EdgeList)
            {
                if (time[edge.DestinationId] == null)
                {
                    StrongConnect(edge.DestinationId);
                    low[v] = Math.Min(low[edge.DestinationId], low[v]);
                }
                else if (onStack[edge.DestinationId])
                {
                    low[v] = Math.Min(low[v], time[edge.DestinationId].Value);
                }
            }

            if (low[v] == time[v])
            {
                var SSC = new List<Node<string>>();

                while (stack.Any())
                {
                    var id = stack.Pop();
                    var node = graph.GetNode(id);
                    SSC.Add(node);
                    onStack[id] = false;

                    if (id == v)
                        break;
                }
                SSCs.Add(SSC);
            }
        }
    }
}
