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

        public List<AnimationItem> animationList;
        public TarjanDFS (Graph<string> graph)
        {
            this.graph = graph;
            this.SSCs = new List<List<Node<string>>>(graph.CountNodes());
            this.visited = new bool[graph.CountNodes()];
            this.low = new int[graph.CountNodes()];
            this.time = new int?[graph.CountNodes()];
            this.onStack = new bool[graph.CountNodes()];
            this.stack = new Stack<int>(graph.CountNodes());

            animationList = new List<AnimationItem>();
        }

        public List<AnimationItem> doDFS()
        {
            foreach (var node in graph.getNodeList())
            {
                if (time[node.Id] == null)
                {
                    StrongConnect(node.Id);
                }
            }

            return animationList;
        }

        private void StrongConnect(int v)
        {
            time[v] = index;
            low[v] = index;

            animationList.Add(new AnimationItem(AnimationItem.GreenHighlight, v.ToString()));
            animationList.Add(new AnimationItem(AnimationItem.SetLabel, v.ToString(), "time=" + time[v] + " low=" + low[v]));

            index++;


            stack.Push(v);
            animationList.Add(new AnimationItem(AnimationItem.QueueAdd, v.ToString()));
            onStack[v] = true;

            foreach (var edge in graph.GetNode(v).EdgeList)
            {
                if (time[edge.DestinationId] == null)
                {

                    StrongConnect(edge.DestinationId);
                    low[v] = Math.Min(low[edge.DestinationId], low[v]);
                    animationList.Add(new AnimationItem(AnimationItem.RedHighlight, edge.Id));
                    animationList.Add(new AnimationItem(AnimationItem.SetLabel, v.ToString(), "time=" + time[v] + " low=" + low[v]));

                }
                else if (onStack[edge.DestinationId])
                {
                    low[v] = Math.Min(low[v], time[edge.DestinationId].Value);
                    animationList.Add(new AnimationItem(AnimationItem.RedHighlight, edge.Id));
                    animationList.Add(new AnimationItem(AnimationItem.SetLabel, v.ToString(), "time=" + time[v] + " low=" + low[v]));
                }
                else
                {
                    animationList.Add(new AnimationItem(AnimationItem.RemoveHighlight, edge.Id));
                }
            }

            if (low[v] == time[v])
            {
                var SSC = new List<Node<string>>();

                while (stack.Any())
                {
                    var id = stack.Pop();
                    animationList.Add(new AnimationItem(AnimationItem.RemoveHighlight, id.ToString()));
                    animationList.Add(new AnimationItem(AnimationItem.RedHighlight, id.ToString()));
                    animationList.Add(new AnimationItem(AnimationItem.QueueRemove, id.ToString()));
                    animationList.Add(new AnimationItem(AnimationItem.SetParent, id.ToString(),"p" + SSCs.Count()));


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
