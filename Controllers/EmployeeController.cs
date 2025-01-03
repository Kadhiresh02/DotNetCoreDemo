using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private CompanyContext context;
        public EmployeeController(CompanyContext cc)
        {
            context = cc;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            List<SelectListItem> dept=new List<SelectListItem>();   
            dept=context.Departments.Select(x=>new SelectListItem { Text = x.Name, Value = x.Id.ToString()}).ToList();
            ViewBag.Department = dept;
            return View();
        }
    }
}
