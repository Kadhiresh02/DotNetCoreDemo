using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DepartmentController : Controller
    {
        private CompanyContext context {  get; set; }
        public DepartmentController(CompanyContext cc)
        {
            context = cc;
        }
        public IActionResult Index()
        {
            return View(context.Departments.AsNoTracking());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Department dept)
        {
            context.Add(dept);
            await context.SaveChangesAsync();
            return  RedirectToAction("Index");
        }
        public IActionResult Create()
        {

            return View();
        }

        public async Task<ActionResult> Update(int id)
        {
            Department dept=await context.Departments.Where(e=>e.Id==id).FirstOrDefaultAsync();
            return View(dept);
        }
        [HttpPost]
        public async Task<ActionResult> Update(Department dept)
        {
            context.Update(dept);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

       

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var dept = new Department() { Id = id };
            context.Remove(dept);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //public String Create()
        //{
        //    var dept = new Department()
        //    {
        //        Name = "Designing"
        //    };
        //    context.Entry(dept).State = Microsoft.EntityFrameworkCore.EntityState.Added;
        //    context.SaveChanges();

        //    return "Department Added dSuccessfully";
        //}

    }
}
