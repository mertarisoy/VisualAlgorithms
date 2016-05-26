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

        public ActionResult GetExampleGraph(int start = 0)
        {
            GraphGenerator generator = new GraphGenerator();
            var graph = generator.GetExampleGraph();
            PrimsMST mst = new PrimsMST(graph);
            var animationList = mst.doMST(0);

            return Json(new { graph = graph.ToJsonString(), path = animationList }, JsonRequestBehavior.AllowGet);
        }
    }
}