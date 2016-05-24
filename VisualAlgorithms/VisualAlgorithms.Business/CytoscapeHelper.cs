using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Script.Serialization;
using VisualAlgorithms.Business.Algorithms.Graph;
using VisualAlgorithms.Business.Models;

namespace VisualAlgorithms.Business
{
    public static class CytoscapeHelper
    {
        public static string ToJsonString<T> (this Graph<T> graph) where T : IComparable<T>
        {
            var nodes = graph.getNodeList().Select( x => new {data = new {id = x.Id.ToString(), label= x.Id.ToString()}});

            var edgeList = (from node in graph.getNodeList()
                            from edge in node.EdgeList
                            select new Tuple<int, Edge>(node.Id, edge)).ToList();
            
            Debug.WriteLine(new JavaScriptSerializer().Serialize(edgeList));

            var edges = edgeList.Select(x => new
            {
                data = new
                {
                    id = x.Item2.Id,
                    source = x.Item1.ToString(),
                    target = x.Item2.DestinationId.ToString(),
                    label = x.Item2.Weight.Equals(0) ?  "" : x.Item2.Weight.ToString()
                }
            }).GroupBy(x => x.data.id).Select(x => x.First());

           

            var elements = new { nodes = nodes, edges = edges };
            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(elements);
        }

    }

}
