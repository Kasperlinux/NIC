using NIC.Data;
using NIC.Models.ViewModel;
using NIC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NIC.Controllers
{
    public class AgeController : Controller
    {
        public AgeController(DhsMagacoursesContext context)
        {

            this.context=context;
        }

        public DhsMagacoursesContext context { get; }

        [HttpGet]
        public IActionResult AddAge()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAge(AgeCriteriaViewModel addAge)
        {
            var age = new AgeEligibilityCriterion()
            {
                SessionCode=addAge.SessionCode,
                Category=addAge.Category,
                AgeLimitLower=addAge.AgeLimitLower,
                AgeLimitUpper=addAge.AgeLimitUpper
            };
            await context.AgeEligibilityCriteria.AddAsync(age);
            await context.SaveChangesAsync();
            return RedirectToAction("EditAge");
        }
        [HttpGet]
        public async Task<IActionResult> EditAge()
        {
            var age = await context.AgeEligibilityCriteria.ToListAsync();
            return View(age);
        }

        [HttpGet]
        public async Task<IActionResult> View(int sid,int cat)
        {
            var ageData = await context.AgeEligibilityCriteria.FirstOrDefaultAsync(x => x.SessionCode==sid && x.Category==cat);

            if (ageData!=null)
            {
                var viewModel = new AgeCriteriaViewModel()
                {
                    SessionCode=ageData.SessionCode,
                    Category=ageData.Category,
                    AgeLimitLower=ageData.AgeLimitLower,
                    AgeLimitUpper=ageData.AgeLimitUpper
                };
                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("EditAge");
        }

        [HttpPost]
        public async Task<IActionResult> View(AgeCriteriaViewModel model)
        {
            var age = await context.AgeEligibilityCriteria.FindAsync(model.SessionCode);
            if (age!=null)
            {
                age.SessionCode=model.SessionCode;
                age.Category=model.Category;
                age.AgeLimitLower=model.AgeLimitLower;
                age.AgeLimitUpper=model.AgeLimitUpper;
                await context.SaveChangesAsync();
                return RedirectToAction("EditAge");
            }
            return View("EditAge");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AgeCriteriaViewModel model)
        {
            var age = await context.AgeEligibilityCriteria.FindAsync(model.SessionCode , model.Category);
            if (age!=null)
            {
                context.AgeEligibilityCriteria.Remove(age);
                await context.SaveChangesAsync();
                return RedirectToAction("EditAge");
            }
            return RedirectToAction("EditAge");
        }

    }
}
