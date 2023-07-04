using NIC.Data;
using NIC.Models.ViewModel;
using NIC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NIC.Controllers
{
    public class ScreeningCenterController : Controller
    {
        public ScreeningCenterController(DhsMagacoursesContext context)
        {

            this.context=context;
        }

        public DhsMagacoursesContext context { get; }

        [HttpGet]
        public IActionResult AddCenter()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCenter(ScreeningCenterViewModel addCenter)
        {
            var center = new MScreeningCentre()
            {
                ScreeningCentre=addCenter.ScreeningCentre,
                ScreeningCentreName=addCenter.ScreeningCentreName,
                ApplicationType=addCenter.ApplicationType,
            };
            await context.MScreeningCentres.AddAsync(center);
            await context.SaveChangesAsync();
            return RedirectToAction("EditCenter");
        }
        [HttpGet]
        public async Task<IActionResult> EditCenter()
        {
            var center = await context.MScreeningCentres.ToListAsync();
            return View(center);
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var centerData = await context.MScreeningCentres.FirstOrDefaultAsync(x => x.ScreeningCentre==id);

            if (centerData!=null)
            {
                var viewModel = new ScreeningCenterViewModel()
                {
                    ScreeningCentre=centerData.ScreeningCentre,
                    ScreeningCentreName=centerData.ScreeningCentreName,
                    ApplicationType=centerData.ApplicationType,
                };
                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("EditCenter");
        }

        [HttpPost]
        public async Task<IActionResult> View(ScreeningCenterViewModel model)
        {
            var center = await context.MScreeningCentres.FindAsync(model.ScreeningCentre);
            if (center!=null)
            {
                center.ScreeningCentre=model.ScreeningCentre;
                center.ScreeningCentreName=model.ScreeningCentreName;
                center.ApplicationType=model.ApplicationType;
                await context.SaveChangesAsync();
                return RedirectToAction("EditCenter");
            }
            return View("EditCenter");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ScreeningCenterViewModel model)
        {
            var center = await context.MScreeningCentres.FindAsync(model.ScreeningCentre);
            if (center!=null)
            {
                context.MScreeningCentres.Remove(center);
                await context.SaveChangesAsync();
                return RedirectToAction("EditCenter");
            }
            return RedirectToAction("EditCenter");
        }

    }
}
