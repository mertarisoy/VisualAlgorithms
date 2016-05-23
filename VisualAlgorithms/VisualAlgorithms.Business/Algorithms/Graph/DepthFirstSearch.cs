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
        private UndirectedGraph<string> graph; 
        private bool[] visited;

        public DepthFirstSearch(UndirectedGraph<string> graph)
        {
            this.graph = graph;
            visited = new bool[graph.CountNodes()];
        } 
        public List<string> doDFS(int start)
        {

            Stack<int> stack = new Stack<int>();
            Stack<string> stackEdge = new Stack<string>();
            List<string> res = new List<string>();

            stack.Push(start);
            while (stack.Any())
            {
                var v = stack.Pop();

               

                if (!visited[v])
                {
                    visited[v] = true;
                    Debug.Write("->" + graph.GetNode(v).Id);

                    if (stackEdge.Any())
                        res.Add(stackEdge.Pop());

                    res.Add(graph.GetNode(v).Id.ToString());

                    var neigbours = graph.GetNode(v).EdgeList;
                    foreach (var neigbour in neigbours)
                    {
                        if (visited[neigbour.DestinationId]) continue;
                        stack.Push(neigbour.DestinationId);
                        
                        stackEdge.Push(neigbour.Id);
                        
                    }
                }
            }

            Debug.WriteLine("");
            return res;
        }

        
    }
}
