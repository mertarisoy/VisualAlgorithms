using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VisualAlgorithms.Business;
using VisualAlgorithms.Business.Algorithms.Graph;

namespace VisualAlgorithms.UI.Controllers
{
    public class DepthFirstSearchController : Controller
    {
        // GET: DepthFirstSearch
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetRandomGraph(int start = 0)
        {
            GraphGenerator generator = new GraphGenerator();
            var graph = generator.GenerateUndirctedGraph();
            DepthFirstSearch dfs = new DepthFirstSearch(graph);
            var res = dfs.doDFS(start);

            return Json(new { graph = graph.ToJsonString(), path = res }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetExampleGraph(int start = 0)
        {
            GraphGenerator generator = new GraphGenerator();
            var graph = generator.GetExampleGraph();
            DepthFirstSearch dfs = new DepthFirstSearch(graph);
            var res = dfs.doDFS(start);

            return Json(new { graph = graph.ToJsonString(), path = res }, JsonRequestBehavior.AllowGet);
        }


    }
}