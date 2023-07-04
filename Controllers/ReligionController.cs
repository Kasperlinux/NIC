using NIC.Data;
using NIC.Models.ViewModel;
using NIC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NIC.Controllers
{
    public class ReligionController : Controller
    {
        public ReligionController(DhsMagacoursesContext context)
        {

            this.context=context;
        }

        public DhsMagacoursesContext context { get; }

        [HttpGet]
        public IActionResult AddReligion()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddReligion(ReligionViewModel addReligion)
        {
            var rel = new MReligion()
            {
                Religion=addReligion.Religion,
                ReligionDesc=addReligion.ReligionDesc,
            };
            await context.MReligions.AddAsync(rel);
            await context.SaveChangesAsync();
            return RedirectToAction("EditReligion");
        }
        [HttpGet]
        public async Task<IActionResult> EditReligion()
        {
            var data = await context.MReligions.ToListAsync();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var Data = await context.MReligions.FirstOrDefaultAsync(x => x.Religion==id);

            if (Data!=null)
            {
                var viewModel = new ReligionViewModel()
                {
                    Religion=Data.Religion,
                    ReligionDesc=Data.ReligionDesc,
                };
                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("EditReligion");
        }

        [HttpPost]
        public async Task<IActionResult> View(ReligionViewModel model)
        {
            var data = await context.MReligions.FindAsync(model.Religion);
            if (data!=null)
            {
                data.Religion=model.Religion;
                data.ReligionDesc=model.ReligionDesc;
                await context.SaveChangesAsync();
                return RedirectToAction("EditReligion");
            }
            return View("EditReligion");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ReligionViewModel model)
        {
            var data = await context.MReligions.FindAsync(model.Religion);
            if (data!=null)
            {
                context.MReligions.Remove(data);
                await context.SaveChangesAsync();
                return RedirectToAction("EditReligion");
            }
            return RedirectToAction("EditReligion");
        }
    }
}
