using NIC.Data;
using NIC.Models.ViewModel;
using NIC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NIC.Controllers
{
    public class CategoryController : Controller
    {
        public CategoryController(DhsMagacoursesContext context)
        {

            this.context=context;
        }

        public DhsMagacoursesContext context { get; }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryViewModel addCategory)
        {
            var cat = new MCategory()
            {
                Category=addCategory.Category,
                CategoryDesc=addCategory.CategoryDesc,
            };
            await context.MCategories.AddAsync(cat);
            await context.SaveChangesAsync();
            return RedirectToAction("EditCategory");
        }
        [HttpGet]
        public async Task<IActionResult> EditCategory()
        {
            var cat = await context.MCategories.ToListAsync();
            return View(cat);
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var catData = await context.MCategories.FirstOrDefaultAsync(x => x.Category==id);

            if (catData!=null)
            {
                var viewModel = new CategoryViewModel()
                {
                    Category=catData.Category,
                    CategoryDesc=catData.CategoryDesc,
                };
                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("EditCategory");
        }

        [HttpPost]
        public async Task<IActionResult> View(CategoryViewModel model)
        {
            var cat = await context.MCategories.FindAsync(model.Category);
            if (cat!=null)
            {
                cat.Category=model.Category;
                cat.CategoryDesc=model.CategoryDesc;
                await context.SaveChangesAsync();
                return RedirectToAction("EditCategory");
            }
            return View("EditCategory");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CategoryViewModel model)
        {
            var cat = await context.MCategories.FindAsync(model.Category);
            if (cat!=null)
            {
                context.MCategories.Remove(cat);
                await context.SaveChangesAsync();
                return RedirectToAction("EditCategory");
            }
            return RedirectToAction("EditCategory");
        }
    }
}
