using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class InformationController : Controller
    {
        private CompanyContext context { get; set; }
        public InformationController(CompanyContext cc)
        {
            context = cc;
        }
        public IActionResult Index()
        {
            return View(context.Information.AsNoTracking());
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Information infor)
        {
            context.Add(infor);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        

        public async Task<ActionResult> Update(int id)
        {
            Information cname = await context.Information.Where(e => e.Id == id).FirstOrDefaultAsync();
            return View(cname);
        }
        [HttpPost]
        public async Task<ActionResult> Update(Information infor)
        {
            context.Update(infor);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var cname = new Information() { Id = id };
            context.Remove(cname);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
