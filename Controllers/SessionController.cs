using NIC.Data;
using NIC.Models.ViewModel;
using NIC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NIC.Controllers
{
    public class SessionController : Controller
    {
        public SessionController(DhsMagacoursesContext context)
        {

            this.context=context;
        }

        public DhsMagacoursesContext context { get; }

        [HttpGet]
        public IActionResult AddSession()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSession(SessionViewModel addSession)
        {
            var session = new Session()
            {
                SessionCode=addSession.SessionCode,
                StateCode=addSession.StateCode,
                ApplicationType=addSession.ApplicationType,
                AcademicSession=addSession.AcademicSession,
                DateAsOnforAgeCutOff=addSession.DateAsOnforAgeCutOff,
                Advertisement=addSession.Advertisement,
                AdvNo=addSession.AdvNo,
                AdvtDate=addSession.AdvtDate,
                LastDateForApplication=addSession.LastDateForApplication,
            };
            await context.Sessions.AddAsync(session);
            await context.SaveChangesAsync();
            return RedirectToAction("EditSession");
        }
        [HttpGet]
        public async Task<IActionResult> EditSession()
        {
            var session = await context.Sessions.ToListAsync();
            return View(session);
        }

        [HttpGet]
        public async  Task<IActionResult> View(string id)
        {
            var data = await context.Sessions.FirstOrDefaultAsync(x => x.SessionCode==id);

            if (data!=null)
            {
                var viewModel = new SessionViewModel()
                {
                    SessionCode=data.SessionCode,
                    StateCode=data.StateCode,
                    ApplicationType=data.ApplicationType,
                    AcademicSession=data.AcademicSession,
                    DateAsOnforAgeCutOff=data.DateAsOnforAgeCutOff,
                    Advertisement=data.Advertisement,
                    AdvNo=data.AdvNo,
                    AdvtDate=data.AdvtDate,
                    LastDateForApplication=data.LastDateForApplication,
                };
                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("EditSession");
        }

        [HttpPost]
        public async Task<IActionResult> View(SessionViewModel model)
        {
            var session = await context.Sessions.FindAsync(model.SessionCode);
            if (session!=null)
            {
                session.SessionCode=model.SessionCode;
                session.StateCode=model.StateCode;
                session.ApplicationType=model.ApplicationType;
                session.AcademicSession=model.AcademicSession;
                session.DateAsOnforAgeCutOff=model.DateAsOnforAgeCutOff;
                session.Advertisement=model.Advertisement;
                session.AdvNo=model.AdvNo;
                session.AdvtDate=model.AdvtDate;
                session.LastDateForApplication=model.LastDateForApplication;
                await context.SaveChangesAsync();
                return RedirectToAction("EditSession");
            }
            return await View("EditSession");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SessionViewModel model)
        {
            var data = await context.Sessions.FindAsync(model.SessionCode);
            if (data!=null)
            {
                context.Sessions.Remove(data);
                await context.SaveChangesAsync();
                return RedirectToAction("EditSession");
            }
            return RedirectToAction("EditSession");
        }
    }
}
