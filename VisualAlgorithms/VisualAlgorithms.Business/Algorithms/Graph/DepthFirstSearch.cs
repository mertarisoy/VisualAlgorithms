using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualAlgorithms.Business.Models;

namespace VisualAlgorithms.Business.Algorithms.Graph
{
    public class DepthFirstSearch
    {
        private Graph<string> graph; 
        private bool[] visited;
        private List<AnimationItem> animationList;

        public DepthFirstSearch(Graph<string> graph)
        {
            this.graph = graph;
            visited = new bool[graph.CountNodes()];
        } 
        public List<AnimationItem> doDFS(int start)
        {
            Node<string> lastNode;
            animationList = new List<AnimationItem>();

            Stack<Node<string>> stack = new Stack<Node<string>>();
            var startNode = graph.GetNode(start);

            stack.Push(startNode);
            animationList.Add(new AnimationItem(AnimationItem.QueueAdd, startNode.Id.ToString()));
            while (stack.Any())
            {
                var v = stack.Pop();
                lastNode = v;

                animationList.Add(new AnimationItem(AnimationItem.QueueRemove, v.Id.ToString()));

                animationList.Add(new AnimationItem(AnimationItem.RedHighlight, v.Id.ToString()));

                if (!visited[v.Id])
                {
                    visited[v.Id] = true;

                    var neigbours = v.EdgeList;
                    foreach (var neigbour in neigbours)
                    {
                        if (visited[neigbour.DestinationId]) continue;
                        stack.Push(graph.GetNode(neigbour.DestinationId));
                        animationList.Add(new AnimationItem(AnimationItem.QueueAdd, neigbour.DestinationId.ToString()));

                        
                    }
                }
            }

            return animationList;
        }

        
    }
}
