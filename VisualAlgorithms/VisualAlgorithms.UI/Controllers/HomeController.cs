using System.Web.Mvc;
using VisualAlgorithms.Business;
using VisualAlgorithms.Business.Algorithms.Graph;
using VisualAlgorithms.Business.Models;

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
            DepthFirstSearch dfs = new DepthFirstSearch(graph);
            var res = dfs.doDFS(0);

            return Json(new { graph = graph.ToJsonString(), path = res }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetExampleGraph()
        {
            GraphGenerator generator = new GraphGenerator();
            var graph = generator.GetExampleGraph();
            DepthFirstSearch dfs = new DepthFirstSearch(graph);
            var res = dfs.doDFS(0);

            return Json(new { graph = graph.ToJsonString(), path = res }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRandomGraphForBFS()
        {
            GraphGenerator generator = new GraphGenerator();
            var graph = generator.ConstractGraph(@"C:\Users\dRk\Source\Repos\VisualAlgorithms\VisualAlgorithms\VisualAlgorithms.UI\Resources\mediumG.txt");

            BreathFirstSearch dfs = new BreathFirstSearch(graph);
            var animationList = dfs.doBFS(0);
            return Json(new { graph = graph.ToJsonString(), path = animationList }, JsonRequestBehavior.AllowGet);}

        public ActionResult GetRandomGraphForDFS()
        {
            GraphGenerator generator = new GraphGenerator();
            var graph = generator.GenerateUndirctedGraph();
            DepthFirstSearch dfs = new DepthFirstSearch(graph);
            var res = dfs.doDFS(0);

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

            TarjanDFS tdfs = new TarjanDFS(graph);
            var result = tdfs.doDFS();

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public ActionResult doDijkstra()
        {
            Graph<string> graph = new UndirectedGraph<string>();



            var node1 = "1";
            var node2 = "2";
            var node3 = "3";
            var node4 = "4";
            var node5 = "5";
            var node6 = "6";


            graph.AddNode(node1);
            graph.AddNode(node2);
            graph.AddNode(node3);
            graph.AddNode(node4);
            graph.AddNode(node5);
            graph.AddNode(node6);

            graph.AddEdge(node1, node3, 9);
            graph.AddEdge(node1, node6, 14);
            graph.AddEdge(node1, node2, 7);
            graph.AddEdge(node2, node3, 10);
            graph.AddEdge(node2, node4, 15);
            graph.AddEdge(node3, node6, 2);
            graph.AddEdge(node3, node4, 11);
            graph.AddEdge(node4, node5, 6);
            graph.AddEdge(node5, node6, 9);

            Dijkstra dijkstra = new Dijkstra(graph);
            dijkstra.doDijkstra(0);

            return Content(dijkstra.writeShortest());
        }
        
    }
}