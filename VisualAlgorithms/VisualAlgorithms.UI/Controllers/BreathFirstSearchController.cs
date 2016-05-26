using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VisualAlgorithms.Business;
using VisualAlgorithms.Business.Algorithms.Graph;

namespace VisualAlgorithms.UI.Controllers
{
    public class BreathFirstSearchController : Controller
    {
        // GET: BreathFirstSearch
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetRandomGraph(int start = 0)
        {
            GraphGenerator generator = new GraphGenerator();
            var graph = generator.GenerateUndirctedGraph();

            BreathFirstSearch bfs = new BreathFirstSearch(graph);
            var res = bfs.doBFS(start);

            return Json(new { graph = graph.ToJsonString(), path = res }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetExampleGraph(int start = 0)
        {
            GraphGenerator generator = new GraphGenerator();
            var graph = generator.ConstractGraph(Server.MapPath("~/Resources/graph_medium.txt"));

            BreathFirstSearch bfs = new BreathFirstSearch(graph);
            var animationList = bfs.doBFS(start);

            return Json(new { graph = graph.ToJsonString(), path = animationList }, JsonRequestBehavior.AllowGet);

        }
    }
}