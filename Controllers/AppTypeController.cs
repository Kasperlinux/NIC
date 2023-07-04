using NIC.Data;
using NIC.Models.ViewModel;
using NIC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NIC.Controllers
{
    public class AppTypeController : Controller
    {
        public DhsMagacoursesContext Context { get; }
        public AppTypeController(DhsMagacoursesContext context)
        {

            this.Context=context;                                                                             
        }

        [HttpGet]
        public IActionResult AddAppType()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAppType(AppTypeViewModel addAppType)
        {
            var type = new MApplicationType()
            {
                ApplicationType=addAppType.ApplicationType,
                ApplicationDesc=addAppType.ApplicationDesc,
            };
            await Context.MApplicationTypes.AddAsync(type);
            await Context.SaveChangesAsync();
            return RedirectToAction("EditAppType");
        }
        [HttpGet]
        public async Task<IActionResult> EditAppType()
        {
            var appType = await Context.MApplicationTypes.ToListAsync();
            return View(appType);
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var typeData = await Context.MApplicationTypes.FirstOrDefaultAsync(x => x.ApplicationType==id);

            if (typeData!=null)
            {
                var viewModel = new AppTypeViewModel()
                {
                    ApplicationType=typeData.ApplicationType,
                    ApplicationDesc=typeData.ApplicationDesc,
                };
                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("EditAppType");
        }

        [HttpPost]
        public async Task<IActionResult> View(AppTypeViewModel model)
        {
            var type = await Context.MApplicationTypes.FindAsync(model.ApplicationType);
            if (type!=null)
            {
                type.ApplicationType=model.ApplicationType;
                type.ApplicationDesc=model.ApplicationDesc;
                await Context.SaveChangesAsync();
                return RedirectToAction("EditAppType");
            }
            return View("EditAppType");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AppTypeViewModel model)
        {
            var type = await Context.MApplicationTypes.FindAsync(model.ApplicationType);
            if (type!=null)
            {
                Context.MApplicationTypes.Remove(type);
                await Context.SaveChangesAsync();
                return RedirectToAction("EditAppType");
            }
            return RedirectToAction("EditAppType");
        }
    }
}
