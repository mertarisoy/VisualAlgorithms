using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using VisualAlgorithms.Business.Models;

namespace VisualAlgorithms.Business
{
    public static class CytoscapeHelper
    {
        //    public string ToJSONString()
        //    {

        //        var nodes =
        //            vertexList.Select(
        //                x => new {data = new {id = x.Name}, position = new { x = x.Position.X, y = x.Position.Y } });

        //        var list = new List<Edge>();
        //        foreach (var edgeList in adjacencyList)
        //        {
        //            list.AddRange(edgeList);
        //        }

        //        var edges = list.Select(x => new
        //        {
        //            data = new
        //            {
        //                id = x.Source.ToString() + x.Destination,
        //                source = GetVertex(x.Source).Name,
        //                target = GetVertex(x.Destination).Name
        //            }
        //        });

        //        var elements = new {nodes = nodes, edges = edges};
        //        JavaScriptSerializer serializer = new JavaScriptSerializer();
        //        return serializer.Serialize(elements);
        //    }

        public static string ToJsonString<T>(this Graph<T> graph) 
        {
            var nodes = graph.NodeList.Select( x => new {data = new {id = x.Id.ToString()}, position = new { x = 0, y = 0 } });

            var edgeList = (from node in graph.NodeList from edge in node.EdgeList select new Tuple<int, Edge<T>>(node.Id, edge)).ToList();

            var edges = edgeList.Select(x => new
            {
                data = new
                {
                    id = x.Item1.ToString() + x.Item2.DestinationId.ToString(),
                    source = x.Item1.ToString(),
                    target = x.Item2.DestinationId.ToString()
                }
            });

            var elements = new { nodes = nodes, edges = edges };
            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(elements);
        }
    }

}
