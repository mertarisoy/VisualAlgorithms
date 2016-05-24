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

        public ActionResult GetRandomGraphForBFS()
        {
            GraphGenerator generator = new GraphGenerator();
            var graph = generator.ConstractGraph(Server.MapPath("~/Resources/mediumG.txt"));

            BreathFirstSearch dfs = new BreathFirstSearch(graph);
            var animationList = dfs.doBFS(0);
            return Json(new { graph = graph.ToJsonString(), path = animationList }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetExampleUndirectedGraph()
        {
            GraphGenerator generator = new GraphGenerator();
            var graph = generator.GetExampleDirectedGraph();


            Dijkstra dijkstra = new Dijkstra(graph);
            var animationList = dijkstra.doDijkstra(0);

            return Json(new { graph = graph.ToJsonString(), path = animationList }, JsonRequestBehavior.AllowGet);
        }
    }
}