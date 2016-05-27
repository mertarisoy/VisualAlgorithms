using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VisualAlgorithms.Business;
using VisualAlgorithms.Business.Algorithms.Graph;
using VisualAlgorithms.Common;

namespace VisualAlgorithms.UI.Controllers
{
    public class DepthFirstSearchController : Controller
    {
        // GET: DepthFirstSearch
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dfs(int start = 0, int graphSize = 1 )
        {
            var graph = GraphGenerator.GetUndirectedGraph(start, (GraphSize)graphSize);


            DepthFirstSearch dfs = new DepthFirstSearch(graph);
            var animationList = dfs.doDFS(start);
            return Json(new { graph = graph.ToJsonString(), path = animationList }, JsonRequestBehavior.AllowGet);

        }
    }
}