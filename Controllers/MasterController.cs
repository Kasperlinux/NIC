using NIC.Data;
using NIC.Models;
using NIC.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NIC.Controllers
{
    public class MasterController : Controller
    {
        public MasterController(DhsMagacoursesContext context)
        {

            this.context=context;
        }

        public DhsMagacoursesContext context { get; }

        [HttpGet]
        public IActionResult AddState()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddState(AddStateViewModel addState)
        {
            var state = new MState()
            {
                StateCode=addState.StateCode,
                StateName=addState.StateName,
            };
            await context.MStates.AddAsync(state);
            await context.SaveChangesAsync();
            return RedirectToAction("EditState");
        }
        [HttpGet]
        public async Task<IActionResult> EditState()
        {
            var states = await context.MStates.ToListAsync();
            return View(states);
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var stateData = await context.MStates.FirstOrDefaultAsync(x => x.StateCode==id);

            if (stateData!=null)
            {
                var viewModel = new UpdateStateViewModel()
                {
                    StateCode=stateData.StateCode,
                    StateName=stateData.StateName,
                };
                return await Task.Run(()=>View("View",viewModel));
            }

            return RedirectToAction("EditState");
        }

        [HttpPost]
        public async Task<IActionResult>View(UpdateStateViewModel model)
        {
            var state = await context.MStates.FindAsync(model.StateCode);
            if(state!=null)
            {
                state.StateCode=model.StateCode;
                state.StateName=model.StateName;
                await context.SaveChangesAsync();
                return RedirectToAction("EditState");
            }
            return View("EditState");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateStateViewModel model)
        {
            var state = await context.MStates.FindAsync(model.StateCode);
            if(state !=null)
            {
                context.MStates.Remove(state);
                await context.SaveChangesAsync();
                return RedirectToAction("EditState");
            }
            return RedirectToAction("EditState");
        }


    }
}
