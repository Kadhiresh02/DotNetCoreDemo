using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        //public IActionResult Index()
        //{
        //    return View(context.Employee.Include(s => s.Department));
        //}

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(int id, string name)
        {
            string message = $"Welcome to the page Mr. {name} your Employee ID: {id}";
            return View((object)message);
        }

        public IActionResult Create()
        {
            List<SelectListItem> dept = new List<SelectListItem>();
            dept = context.Departments.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

            ViewBag.Department = dept;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee emp)
        {
            //List<SelectListItem> dept = new List<SelectListItem>();
            //dept = context.Department.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

            //ViewBag.Department = dept;

            //var employee = new Employee();

            context.Add(emp);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");


        }



        public async Task<IActionResult> Update(int id)
        {
            Employee emp = await context.Employees.Include(e => e.Department).FirstOrDefaultAsync(e => e.Id == id);
            var Department = await context.Departments.ToListAsync();
            ViewBag.Department = new SelectList(Department, "Id", "Name");
            return View(emp);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Employee emp)
        {
            context.Update(emp);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var emp = new Employee() { Id = id };
            context.Remove(emp);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
