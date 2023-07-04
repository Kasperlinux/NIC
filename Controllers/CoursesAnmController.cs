using NIC.Data;
using NIC.Models.ViewModel;
using NIC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NIC.Controllers
{
    public class CoursesAnmController : Controller
    {
        public CoursesAnmController(DhsMagacoursesContext context)
        {

            this.context=context;
        }

        public DhsMagacoursesContext context { get; }

        [HttpGet]
        public IActionResult AddCourseAnm()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCourseAnm(CoursesAnmViewModel addCoursesAnm)
        {
            var anm = new MCoursesAnm()
            {
                AnmCourseCode=addCoursesAnm.AnmCourseCode,
                AmnCourse=addCoursesAnm.AmnCourse,
            };
            await context.MCoursesAnms.AddAsync(anm);
            await context.SaveChangesAsync();
            return RedirectToAction("EditCoursesAnm");
        }
        [HttpGet]
        public async Task<IActionResult> EditCoursesAnm()
        {
            var data = await context.MCoursesAnms.ToListAsync();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var Data = await context.MCoursesAnms.FirstOrDefaultAsync(x => x.AnmCourseCode==id);

            if (Data!=null)
            {
                var viewModel = new CoursesAnmViewModel()
                {
                    AnmCourseCode=Data.AnmCourseCode,
                    AmnCourse=Data.AmnCourse,
                };
                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("EditCoursesAnm");
        }

        [HttpPost]
        public async Task<IActionResult> View(CoursesAnmViewModel model)
        {
            var data = await context.MCoursesAnms.FindAsync(model.AnmCourseCode);
            if (data!=null)
            {
                data.AnmCourseCode=model.AnmCourseCode;
                data.AmnCourse=model.AmnCourse;
                await context.SaveChangesAsync();
                return RedirectToAction("EditCoursesAnm");
            }
            return View("EditCoursesAnm");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CoursesAnmViewModel model)
        {
            var data = await context.MCoursesAnms.FindAsync(model.AnmCourseCode);
            if (data!=null)
            {
                context.MCoursesAnms.Remove(data);
                await context.SaveChangesAsync();
                return RedirectToAction("EditCoursesAnm");
            }
            return RedirectToAction("EditCoursesAnm");
        }
    }
}
