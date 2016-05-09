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
            DepthFirstSearch<string> dfs = new DepthFirstSearch<string>(graph);
            var res = dfs.doDFS(0);

            return Json(new { graph = graph.ToJsonString(), path = res }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetExampleGraph()
        {
            GraphGenerator generator = new GraphGenerator();
            var graph = generator.GetExampleGraph();
            DepthFirstSearch<string> dfs = new DepthFirstSearch<string>(graph);
            var res = dfs.doDFS(0);

            return Json(new { graph = graph.ToJsonString(), path = res }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRandomGraphForBFS()
        {
            GraphGenerator generator = new GraphGenerator();
            var graph = generator.GenerateUndirctedGraph();
            BreathFirstSearch<string> dfs = new BreathFirstSearch<string>(graph);
            var res = dfs.doBFS(0);

            return Json(new { graph = graph.ToJsonString(), path = res }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BFS()
        {

            return View();
        }

        public ActionResult DFS()
        {
            return View();
        }

        public ActionResult ApplyTarjanDFS()
        {
            GraphGenerator generator = new GraphGenerator();
            var graph = generator.GetExampleDirectedGraph();

            TarjanDFS<string> tdfs = new TarjanDFS<string>(graph);
            var result = tdfs.doDFS();

            return Json(result, JsonRequestBehavior.AllowGet);

        }

    }
}