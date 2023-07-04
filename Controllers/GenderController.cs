using NIC.Data;
using NIC.Models.ViewModel;
using NIC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NIC.Controllers
{
    public class GenderController : Controller
    {
        public GenderController(DhsMagacoursesContext context)
        {

            this.context=context;
        }

        public DhsMagacoursesContext context { get; }

        [HttpGet]
        public IActionResult AddGender()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGender(GenderViewModel addGender)
        {
            var gen = new MGender()
            {
                Gender=addGender.Gender,
                GenderDesc=addGender.GenderDesc,
            };
            await context.MGenders.AddAsync(gen);
            await context.SaveChangesAsync();
            return RedirectToAction("EditGender");
        }
        [HttpGet]
        public async Task<IActionResult> EditGender()
        {
            var data = await context.MGenders.ToListAsync();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> View(string id)
        {
            var Data = await context.MGenders.FirstOrDefaultAsync(x => x.Gender==id);

            if (Data!=null)
            {
                var viewModel = new GenderViewModel()
                {
                    Gender=Data.Gender,
                    GenderDesc=Data.GenderDesc,
                };
                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("EditGender");
        }

        [HttpPost]
        public async Task<IActionResult> View(GenderViewModel model)
        {
            var data = await context.MGenders.FindAsync(model.Gender);
            if (data!=null)
            {
                data.Gender=model.Gender;
                data.GenderDesc=model.GenderDesc;
                await context.SaveChangesAsync();
                return RedirectToAction("EditGender");
            }
            return await View("EditGender");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(GenderViewModel model)
        {
            var data = await context.MGenders.FindAsync(model.Gender);
            if (data!=null)
            {
                context.MGenders.Remove(data);
                await context.SaveChangesAsync();
                return RedirectToAction("EditGender");
            }
            return RedirectToAction("EditGender");
        }
    }
}
