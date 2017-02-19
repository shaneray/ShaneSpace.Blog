using System;
using System.Web.Mvc;

namespace ShanesSpot.Controllers
{
    public partial class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            var myBirthDate = DateTime.Parse("1987-06-05");
            var jaylanBirthDate = DateTime.Parse("2007-08-06");
            ViewBag.Age = Math.Floor(DateTime.Now.Subtract(myBirthDate).TotalDays / 365);
            ViewBag.JaylanAge = Math.Floor(DateTime.Now.Subtract(jaylanBirthDate).TotalDays / 365);
            return View();
        }

        public virtual ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public virtual ActionResult Contact()
        {
            return View();
        }
    }
}