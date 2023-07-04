using NIC.Data;
using NIC.Models.ViewModel;
using NIC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NIC.Controllers
{
    public class CoursesMbbsController : Controller
    {
        public CoursesMbbsController(DhsMagacoursesContext context)
        {

            this.context=context;
        }

        public DhsMagacoursesContext context { get; }

        [HttpGet]
        public IActionResult AddCourseMbbs()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCourseMbbs(CoursesMbbsViewModel addCoursesMbbs)
        {
            var mbbs = new MCoursesMbb()
            {
                MbbsCourseCode=addCoursesMbbs.MbbsCourseCode,
                MbbsCouseName=addCoursesMbbs.MbbsCouseName,
            };
            await context.MCoursesMbbs.AddAsync(mbbs);
            await context.SaveChangesAsync();
            return RedirectToAction("EditCoursesMbbs");
        }
        [HttpGet]
        public async Task<IActionResult> EditCoursesMbbs()
        {
            var data = await context.MCoursesMbbs.ToListAsync();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var Data = await context.MCoursesMbbs.FirstOrDefaultAsync(x => x.MbbsCourseCode==id);

            if (Data!=null)
            {
                var viewModel = new CoursesMbbsViewModel()
                {
                    MbbsCourseCode=Data.MbbsCourseCode,
                    MbbsCouseName=Data.MbbsCouseName,
                };
                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("EditCoursesMbbs");
        }

        [HttpPost]
        public async Task<IActionResult> View(CoursesMbbsViewModel model)
        {
            var data = await context.MCoursesMbbs.FindAsync(model.MbbsCourseCode);
            if (data!=null)
            {
                data.MbbsCourseCode=model.MbbsCourseCode;
                data.MbbsCouseName=model.MbbsCouseName;
                await context.SaveChangesAsync();
                return RedirectToAction("EditCoursesMbbs");
            }
            return View("EditCoursesMbbs");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CoursesMbbsViewModel model)
        {
            var data = await context.MCoursesMbbs.FindAsync(model.MbbsCourseCode);
            if (data!=null)
            {
                context.MCoursesMbbs.Remove(data);
                await context.SaveChangesAsync();
                return RedirectToAction("EditCoursesMbbs");
            }
            return RedirectToAction("EditCoursesMbbs");
        }
    }
}
