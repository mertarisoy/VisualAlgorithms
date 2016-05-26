using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VisualAlgorithms.Business;
using VisualAlgorithms.Business.Algorithms.Graph;

namespace VisualAlgorithms.UI.Controllers
{
    public class DijkstraController : Controller
    { 
        // GET: Dijkstra
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dijkstra(int start = 0, GraphGenerator.GraphSize graphSize = GraphGenerator.GraphSize.SMALL)
        {
            var graph = GraphGenerator.GetDirectedGraph(start, graphSize);


            Dijkstra dijkstra = new Dijkstra(graph);
            var animationList = dijkstra.doDijkstra(start);
            return Json(new { graph = graph.ToJsonString(), path = animationList }, JsonRequestBehavior.AllowGet);

        }
    }
}