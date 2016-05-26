using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VisualAlgorithms.Business;
using VisualAlgorithms.Business.Algorithms.Graph;

namespace VisualAlgorithms.UI.Controllers
{
    public class PrimsMSTController : Controller
    {
        // GET: PrimsMST
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Mst(int start = 0, GraphGenerator.GraphSize graphSize = GraphGenerator.GraphSize.SMALL)
        {
            var graph = GraphGenerator.GetUndirectedGraph(start, graphSize);


            PrimsMST primsMst = new PrimsMST(graph);
            var animationList = primsMst.doMST(start);
            return Json(new { graph = graph.ToJsonString(), path = animationList }, JsonRequestBehavior.AllowGet);

        }
    }
}