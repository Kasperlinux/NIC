using NIC.Data;
using NIC.Models.ViewModel;
using NIC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NIC.Controllers
{
    public class VillageController : Controller
    {
        public VillageController(DhsMagacoursesContext context)
        {
            this.context=context;
        }

        public DhsMagacoursesContext context { get; }

        [HttpGet]
        public IActionResult AddVillage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBlock(VillageViewModel addVillage)
        {
            var village = new MVillage()
            {
                StateCode=addVillage.StateCode,
                DistrictCode=addVillage.DistrictCode,
                BlockCode=addVillage.BlockCode,
                VillageCode=addVillage.VillageCode,
                VillageName=addVillage.VillageName,
            };
            await context.MVillages.AddAsync(village);
            await context.SaveChangesAsync();
            return RedirectToAction("EditVillage");
        }
        [HttpGet]
        public async Task<IActionResult> EditVillage()
        {
            var village = await context.MVillages.ToListAsync();
            return View(village);
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var villageData = await context.MVillages.FirstOrDefaultAsync(x => x.VillageCode==id);

            if (villageData!=null)
            {
                var viewModel = new VillageViewModel()
                {
                    StateCode=villageData.StateCode,
                    DistrictCode=villageData.DistrictCode,
                    BlockCode=villageData.BlockCode,
                    VillageCode=villageData.VillageCode,
                    VillageName=villageData.VillageName,
                };
                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("EditVillage");
        }

        [HttpPost]
        public async Task<IActionResult> View(VillageViewModel model)
        {
            var village = await context.MVillages.FindAsync(model.VillageCode);
            if (village!=null)
            {
                village.StateCode=model.StateCode;
                village.DistrictCode=model.DistrictCode;
                village.BlockCode=model.BlockCode;
                village.VillageCode=model.VillageCode;
                village.VillageName=model.VillageName;
                await context.SaveChangesAsync();
                return RedirectToAction("EditVillage");
            }
            return View("EditVillage");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(VillageViewModel model)
        {
            var village = await context.MVillages.FindAsync(model.VillageCode);
            if (village!=null)
            {
                context.MVillages.Remove(village);
                await context.SaveChangesAsync();
                return RedirectToAction("EditVillage");
            }
            return RedirectToAction("EditVillage");
        }
    }
}
