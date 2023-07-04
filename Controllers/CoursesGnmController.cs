using NIC.Data;
using NIC.Models.ViewModel;
using NIC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NIC.Controllers
{
    public class CoursesGnmController : Controller
    {
        public CoursesGnmController(DhsMagacoursesContext context)
        {

            this.context=context;
        }

        public DhsMagacoursesContext context { get; }

        [HttpGet]
        public IActionResult AddCourseGnm()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCourseGnm(CoursesGnmViewModel addCoursesGnm)
        {
            var gnm = new MCoursesGnm()
            {
                GnmCourseCode=addCoursesGnm.GnmCourseCode,
                GmnCouse=addCoursesGnm.GmnCouse,
            };
            await context.MCoursesGnms.AddAsync(gnm);
            await context.SaveChangesAsync();
            return RedirectToAction("EditCoursesGnm");
        }
        [HttpGet]
        public async Task<IActionResult> EditCoursesGnm()
        {
            var data = await context.MCoursesGnms.ToListAsync();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var Data = await context.MCoursesGnms.FirstOrDefaultAsync(x => x.GnmCourseCode==id);

            if (Data!=null)
            {
                var viewModel = new CoursesGnmViewModel()
                {
                    GnmCourseCode=Data.GnmCourseCode,
                    GmnCouse=Data.GmnCouse,
                };
                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("EditCoursesGnm");
        }

        [HttpPost]
        public async Task<IActionResult> View(CoursesGnmViewModel model)
        {
            var data = await context.MCoursesGnms.FindAsync(model.GnmCourseCode);
            if (data!=null)
            {
                data.GnmCourseCode=model.GnmCourseCode;
                data.GmnCouse=model.GmnCouse;
                await context.SaveChangesAsync();
                return RedirectToAction("EditCoursesGnm");
            }
            return View("EditCoursesGnm");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CoursesGnmViewModel model)
        {
            var data = await context.MCoursesGnms.FindAsync(model.GnmCourseCode);
            if (data!=null)
            {
                context.MCoursesGnms.Remove(data);
                await context.SaveChangesAsync();
                return RedirectToAction("EditCoursesGnm");
            }
            return RedirectToAction("EditCoursesGnm");
        }
    }
}
