using NIC.Data;
using NIC.Models.ViewModel;
using NIC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NIC.Controllers
{
    public class NationalityController : Controller
    {
        public NationalityController(DhsMagacoursesContext context)
        {

            this.context=context;
        }

        public DhsMagacoursesContext context { get; }

        [HttpGet]
        public IActionResult AddNationality()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNationality(NationalityViewModel addNationality)
        {
            var nat = new MNationality()
            {
                Nationality=addNationality.Nationality,
                NationalityName=addNationality.NationalityName,
            };
            await context.MNationalities.AddAsync(nat);
            await context.SaveChangesAsync();
            return RedirectToAction("EditNationality");
        }
        [HttpGet]
        public async Task<IActionResult> EditNationality()
        {
            var data = await context.MNationalities.ToListAsync();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var Data = await context.MNationalities.FirstOrDefaultAsync(x => x.Nationality==id);

            if (Data!=null)
            {
                var viewModel = new NationalityViewModel()
                {
                    Nationality=Data.Nationality,
                    NationalityName=Data.NationalityName,
                };
                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("Editnationality");
        }

        [HttpPost]
        public async Task<IActionResult> View(NationalityViewModel model)
        {
            var data = await context.MNationalities.FindAsync(model.Nationality);
            if (data!=null)
            {
                data.Nationality=model.Nationality;
                data.NationalityName=model.NationalityName;
                await context.SaveChangesAsync();
                return RedirectToAction("EditNationality");
            }
            return View("EditNationality");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(NationalityViewModel model)
        {
            var data = await context.MNationalities.FindAsync(model.Nationality);
            if (data!=null)
            {
                context.MNationalities.Remove(data);
                await context.SaveChangesAsync();
                return RedirectToAction("EditNationality");
            }
            return RedirectToAction("EditNationality");
        }
    }
}
