using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private CompanyContext context;
        public HomeController(ILogger<HomeController> logger,CompanyContext cc)
        {
            _logger = logger;
            context =cc;
        }
        public IActionResult ViewBagExaple()
        {
            ViewBag.CurrentDateTime = DateTime.Now;
            ViewBag.CurrentYear = DateTime.Now.Year;
            ViewBag.CurrentUser = "Guest";
            return RedirectToAction("Index");
        }

        public IActionResult TempDataExample()
        {
            TempData["CurrentDateTime"]=DateTime.Now;
            TempData["CurrentYear"] = DateTime.Now.Year;
            TempData["CurrentUser"] = "Guest";
            return RedirectToAction("Index");



        }
        public IActionResult SessionExample()
        {

            HttpContext.Session.SetString("CurrentDateTime", DateTime.Now.ToString());
            HttpContext.Session.SetInt32("CurrentYear", DateTime.Now.Year);
            HttpContext.Session.SetString("CurrentUser","Guest");
            return RedirectToAction("Index");


        }
        //public string CreateInformation()
        //{
        //    var info = new Information()
        //    {
        //        Name = "Hematite Infotech",
        //        License = "27AAECH1657D1ZS",
        //        Revenue = 100000,
        //        Established = Convert.ToDateTime("2017/04/28")
        //    };
        //    context.Entry(info).State=Microsoft.EntityFrameworkCore.EntityState.Added;
        //    context.SaveChanges();
        //    return "record created successfully";
        //}
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
