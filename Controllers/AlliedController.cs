using NIC.Data;
using NIC.Models.ViewModel;
using NIC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NIC.Controllers
{
    public class AlliedController : Controller
    {
        public AlliedController(DhsMagacoursesContext context)
        {

            this.context = context;
        }

        public DhsMagacoursesContext context { get; }

        [HttpGet]
        public IActionResult AddAlliedCourses()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAlliedCourses(AlliedCoursesViewModel addAllied)
        {
            var allied = new MCoursesAlliedCourse()
            {
                AcCourseCode = addAllied.AcCourseCode,
                AcCourseName = addAllied.AcCourseName,
            };
            await context.MCoursesAlliedCourses.AddAsync(allied);
            await context.SaveChangesAsync();
            return RedirectToAction("EditAllied");
        }
        [HttpGet]
        public async Task<IActionResult> EditAllied()
        {
            var allied = await context.MCoursesAlliedCourses.ToListAsync();
            return View(allied);
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var alliedData = await context.MCoursesAlliedCourses.FirstOrDefaultAsync(x => x.AcCourseCode == id);

            if (alliedData != null)
            {
                var viewModel = new AlliedCoursesViewModel()
                {
                    AcCourseCode = alliedData.AcCourseCode,
                    AcCourseName = alliedData.AcCourseName,
                };
                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("EditAllied");
        }

        [HttpPost]
        public async Task<IActionResult> View(AlliedCoursesViewModel model)
        {
            var allied = await context.MCoursesAlliedCourses.FindAsync(model.AcCourseCode);
            if (allied != null)
            {
                allied.AcCourseCode = model.AcCourseCode;
                allied.AcCourseName = model.AcCourseName;
                await context.SaveChangesAsync();
                return RedirectToAction("EditAllied");
            }
            return View("EditAllied");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AlliedCoursesViewModel model)
        {
            var allied = await context.MCoursesAlliedCourses.FindAsync(model.AcCourseCode);
            if (allied != null)
            {
                context.MCoursesAlliedCourses.Remove(allied);
                await context.SaveChangesAsync();
                return RedirectToAction("EditAllied");
            }
            return RedirectToAction("EditAllied");
        }
    }
}
