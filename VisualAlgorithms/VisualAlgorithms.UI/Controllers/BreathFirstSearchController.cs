using System.Web.Mvc;
using VisualAlgorithms.Business;
using VisualAlgorithms.Business.Algorithms.Graph;
using VisualAlgorithms.Business.Models;

namespace VisualAlgorithms.UI.Controllers
{
    public class BreathFirstSearchController : Controller
    {

        // GET: BreathFirstSearch
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Bfs(int start = 0, GraphGenerator.GraphSize graphSize = GraphGenerator.GraphSize.SMALL)
        {
            var graph = GraphGenerator.GetUndirectedGraph(start, graphSize);
           

            BreathFirstSearch bfs = new BreathFirstSearch(graph);
            var animationList = bfs.doBFS(start);
            return Json(new { graph = graph.ToJsonString(), path = animationList }, JsonRequestBehavior.AllowGet);

        }

    }
}