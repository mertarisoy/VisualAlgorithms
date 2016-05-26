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

        public ActionResult GetExampleGraph(int start = 0)
        {
            GraphGenerator generator = new GraphGenerator();
            var graph = generator.GetExampleDirectedGraph();

            TarjanDFS tdfs = new TarjanDFS(graph);
            var result = tdfs.doDFS();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}