using NIC.Data;
using NIC.Models.ViewModel;
using NIC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NIC.Controllers
{
    public class StatusController : Controller
    {
        public StatusController(DhsMagacoursesContext context)
        {

            this.context=context;
        }

        public DhsMagacoursesContext context { get; }

        [HttpGet]
        public IActionResult AddStatus()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddStatus(StatusViewModel addStatus)
        {
            var data = new MApplicationStatus()
            {
                ApplicationStatus=addStatus.ApplicationStatus,
                ApplicationStatusDesc=addStatus.ApplicationStatusDesc,
            };
            await context.MApplicationStatuses.AddAsync(data);
            await context.SaveChangesAsync();
            return RedirectToAction("EditStatus");
        }
        [HttpGet]
        public async Task<IActionResult> EditStatus()
        {
            var data = await context.MApplicationStatuses.ToListAsync();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var statusData = await context.MApplicationStatuses.FirstOrDefaultAsync(x => x.ApplicationStatus==id);

            if (statusData!=null)
            {
                var viewModel = new StatusViewModel()
                {
                    ApplicationStatus=statusData.ApplicationStatus,
                    ApplicationStatusDesc=statusData.ApplicationStatusDesc,
                };
                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("EditStatus");
        }

        [HttpPost]
        public async Task<IActionResult> View(StatusViewModel model)
        {
            var data = await context.MApplicationStatuses.FindAsync(model.ApplicationStatus);
            if (data!=null)
            {
                data.ApplicationStatus=model.ApplicationStatus;
                data.ApplicationStatusDesc=model.ApplicationStatusDesc;
                await context.SaveChangesAsync();
                return RedirectToAction("EditStatus");
            }
            return View("EditStatus");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(StatusViewModel model)
        {
            var data = await context.MApplicationStatuses.FindAsync(model.ApplicationStatus);
            if (data!=null)
            {
                context.MApplicationStatuses.Remove(data);
                await context.SaveChangesAsync();
                return RedirectToAction("EditStatus");
            }
            return RedirectToAction("EditStatus");
        }
    }
}
