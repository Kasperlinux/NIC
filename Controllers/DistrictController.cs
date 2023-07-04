using NIC.Data;
using NIC.Models.ViewModel;
using NIC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NIC.Controllers
{
    public class DistrictController : Controller
    {
        public DistrictController(DhsMagacoursesContext context)
        {
            this.context=context;
        }

        public DhsMagacoursesContext context { get; }

        [HttpGet]
        public IActionResult AddDistrict()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddDistrict(DistrictViewModel addDistrict)
        {
            var district = new MDistrict()
            {
                StateCode=addDistrict.StateCode,
                DistrictCode=addDistrict.DistrictCode,
                DistrictName=addDistrict.DistrictName,
            };
            await context.MDistricts.AddAsync(district);
            await context.SaveChangesAsync();
            return RedirectToAction("EditDistrict");
        }
        [HttpGet]
        public async Task<IActionResult> EditDistrict()
        {
            var district = await context.MDistricts.ToListAsync();
            return View(district);
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var districtData = await context.MDistricts.FirstOrDefaultAsync(x => x.DistrictCode==id);

            if (districtData!=null)
            {
                var viewModel = new DistrictViewModel()
                {
                    StateCode=districtData.StateCode,
                    DistrictCode=districtData.DistrictCode,
                    DistrictName=districtData.DistrictName,
                };
                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("EditDistrict");
        }

        [HttpPost]
        public async Task<IActionResult> View(DistrictViewModel model)
        {
            var district = await context.MDistricts.FindAsync(model.DistrictCode);
            if (district!=null)
            {
                district.StateCode=model.StateCode;
                district.DistrictCode=model.DistrictCode;
                district.DistrictName=model.DistrictName;
                await context.SaveChangesAsync();
                return RedirectToAction("EditDistrict");
            }
            return View("EditDistrict");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DistrictViewModel model)
        {
            var district = await context.MDistricts.FindAsync(model.DistrictCode);
            if (district!=null)
            {
                context.MDistricts.Remove(district);
                await context.SaveChangesAsync();
                return RedirectToAction("EditDistrict");
            }
            return RedirectToAction("EditDistrict");
        }

    }
}
