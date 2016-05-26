using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VisualAlgorithms.Business;
using VisualAlgorithms.Business.Algorithms.Graph;

namespace VisualAlgorithms.UI.Controllers
{
    public class TarjanDFSController : Controller
    {
        // GET: TarjanDFS
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tarjan(int start = 0, GraphGenerator.GraphSize graphSize = GraphGenerator.GraphSize.SMALL)
        {
            var graph = GraphGenerator.GetDirectedGraph(start, graphSize);


            TarjanDFS tarjan = new TarjanDFS(graph);
            var animationList = tarjan.doDFS();
            return Json(new { graph = graph.ToJsonString(), path = animationList }, JsonRequestBehavior.AllowGet);

        }
    }
}