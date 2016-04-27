using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VisualAlgorithms.Business;
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

            return Json(graph, JsonRequestBehavior.AllowGet);
        }
    }
}