using System.Web.Mvc;
using VisualAlgorithms.Business;
using VisualAlgorithms.Business.Algorithms.Graph;

namespace VisualAlgorithms.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetRandomGraph()
        {
            GraphGenerator generator = new GraphGenerator();
            var graph = generator.GenerateUndirctedGraph();
            DepthFirstSearch<string> bfs = new DepthFirstSearch<string>(graph);
            var res = bfs.doDFS(0);

            return Json(new { graph = graph.UndirectedGraphToJsonString(), path = res }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetExampleGraph()
        {
            GraphGenerator generator = new GraphGenerator();
            var graph = generator.GetExampleGraph();
            DepthFirstSearch<string> bfs = new DepthFirstSearch<string>(graph);
            var res = bfs.doDFS(0);

            return Json(new { graph = graph.ToJsonString(), path = res }, JsonRequestBehavior.AllowGet);
        }

    }
}