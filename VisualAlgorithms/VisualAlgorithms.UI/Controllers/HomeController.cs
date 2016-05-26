using System.Web.Mvc;
using VisualAlgorithms.Business;
using VisualAlgorithms.Business.Algorithms.Graph;
using VisualAlgorithms.Business.Models;
using VisualAlgorithms.Common;

namespace VisualAlgorithms.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var c = System.Threading.Thread.CurrentThread.CurrentCulture;
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

        public ActionResult ChangeCulture(string lang)
        {
            var newCulture = new System.Globalization.CultureInfo(lang);
            System.Threading.Thread.CurrentThread.CurrentCulture = newCulture;
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = newCulture;

            var uri = Request.UrlReferrer;
            if (uri == null)
            {
                return RedirectToAction("Index");
            }
            
            return Redirect(uri.AbsolutePath);
        }
    }
}