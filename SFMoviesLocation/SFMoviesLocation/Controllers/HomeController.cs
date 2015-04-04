using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SFMoviesLocation.Controllers
{
    /// <summary>
    /// Home view controller.
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index(string Title)
        {
           ViewBag.CurrentFilter = Title;
           var movies = SODAHelper.GetMoviesByTitle(Title);
            var list = SODAHelper.GetAllMoviesTitle().ToList();
            ViewData["List"] = new JavaScriptSerializer().Serialize(list);
            return View(movies);
        }

        public ActionResult Search(string SearchString)
        {

            ViewBag.CurrentFilter = SearchString;
            if (!string.IsNullOrEmpty(SearchString))
            {
                SearchString = SearchString.ToUpper().Trim();
            }
            var response = SODAHelper.GetMoviesByTitle(SearchString);

            ViewBag.Movies = Json(response, JsonRequestBehavior.AllowGet);

            var t = Json(response, JsonRequestBehavior.AllowGet);
            return t;
        }
    }
}