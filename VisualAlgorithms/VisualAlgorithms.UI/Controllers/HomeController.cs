using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VisualAlgorithms.Business;

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

        public string GetRandomGraph()
        {
            GraphGenerator generator = new GraphGenerator();
            var res = generator.GenerateUndirctedGraph();
            return res.ToJSONString();
        }
    }
}