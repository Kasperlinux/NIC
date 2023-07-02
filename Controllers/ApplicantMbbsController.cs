using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NIC.Data;
using NIC.Models;
using System.Data;
using NIC.Models.ViewModel;

namespace NIC.Controllers
{

    public class ApplicantMbbsController : Controller
    {
        private readonly  DhsMagacoursesContext context;
        private readonly IWebHostEnvironment environment;
        private readonly ILogger<ApplicantMbbsController> _logger;

        public ApplicantMbbsController(DhsMagacoursesContext context, IWebHostEnvironment environment, ILogger<ApplicantMbbsController> logger)
        {
            this.context = context;
            this.environment = environment;
            _logger = logger;
        }

        public JsonResult State()
        {
            var cnt = context.MStates.ToList();
            return new JsonResult(cnt);
        }

        public JsonResult District(int id)
        {
            var dt = context.MDistricts.Where(e => e.StateCode == id).ToList();
            return new JsonResult(dt);
        }


        public JsonResult Block(int id)
        {
            var bk = context.MBlocks.Where(e => e.DistrictCode == id).ToList();
            return new JsonResult(bk);
        }

        public JsonResult Village(int id)
        {
            var vg = context.MVillages.Where(e => e.BlockCode == id).ToList();
            return new JsonResult(vg);
        }

        public JsonResult Nationality()
        {
            var data = context.MNationalities.ToList();
            return new JsonResult(data);
        }
        public JsonResult GetNationalityName(int id)
        {
            var dt = context.MNationalities.Where(e => e.Nationality == id);
            return new JsonResult(dt);
        }
        public JsonResult GetReligionName(int id)
        {
            var dt = context.MReligions.Where(e => e.Religion == id);
            return new JsonResult(dt);
        }
        public JsonResult GetCategoryName(int id)
        {
            var dt = context.MCategories.Where(e => e.Category == id);
            return new JsonResult(dt);
        }
        public JsonResult GetStateName(int id)
        {
            var dt = context.MStates.Where(e => e.StateCode == id);
            return new JsonResult(dt);
        }
        public JsonResult GetDistrictName(int id)
        {
            var dt = context.MDistricts.Where(e => e.DistrictCode == id);
            return new JsonResult(dt);
        }
        public JsonResult GetBlockName(int id)
        {
            var dt = context.MBlocks.Where(e => e.BlockCode == id);
            return new JsonResult(dt);
        }
        public JsonResult GetVillageName(int id)
        {
            var dt = context.MVillages.Where(e => e.VillageCode == id);
            return new JsonResult(dt);
        }
        public JsonResult Status()
        {
            var data = context.MApplicationStatuses.ToList();
            return new JsonResult(data);
        }



        public JsonResult Category()
        {
            var data = context.MCategories.ToList();
            return new JsonResult(data);
        }

        public JsonResult Gender()
        {
            var data = context.MGenders.ToList();
            return new JsonResult(data);
        }

        public JsonResult Religion()
        {
            var data = context.MReligions.ToList();
            return new JsonResult(data);
        }


        [HttpGet]
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MbbsViewModel model)
        {

            if (ModelState.IsValid)
            {
                // Calculate age based on date of birth
                int age = 0;
                if (model.Dob != null)
                {
                    var today = DateTime.Today;
                    var dob = (DateTime)model.Dob; // cast to non-nullable DateTime
                    age = today.Year - dob.Year;
                    if (dob > today.AddYears(-age))
                    {
                        age--;
                    }
                }


                var dataBase = new ApplicantsMbb()
                {
                    ScreeningCentre = model.ScreeningCentre,

                    AplicantName = model.AplicantName,
                    Dob = model.Dob,

                    PermanentState = model.PermanentState,
                    PermanentDistrict = model.PermanentDistrict,
                    PermanentBlock = model.PermanentBlock,
                    PermanentVillage = model.PermanentVillage,
                    PermanentAddress = model.PermanentAddress,

                    PresentState = model.PresentState,
                    PresentDistrict = model.PresentDistrict,
                    PresentBlock = model.PresentBlock,
                    PresentVillage = model.PresentVillage,
                    PresentAddress = model.PresentAddress,

                    EMail = model.EMail,
                    Mobile = model.Mobile,

                    Nationality = model.Nationality,
                    Category = model.Category,
                    Gender = model.Gender,
                    Religion = model.Religion,

                    PassportPhoto = ConvertImageToByteArray(model.PassportPhoto),
                    PrCetificate = ConvertImageToByteArray(model.PrCetificate),
                    CategoryCertificate = ConvertImageToByteArray(model.CategoryCertificate),
                    AgeProof = ConvertImageToByteArray(model.AgeProof),
                    Marksheet = ConvertImageToByteArray(model.Marksheet),
                    CharacterCertificate = ConvertImageToByteArray(model.CharacterCertificate),


                    GuardianName = model.GuardianName,
                    GuardianOfficeName = model.GuardianOfficeName,
                    GuardianOfficeAddress = model.GuardianOfficeAddress,
                    GuardianOccupation = model.GuardianOccupation,
                    GuardianEmployerCertificate = ConvertImageToByteArray(model.GuardianEmployerCertificate),

                    MarksPhysicsTheory = model.MarksPhysicsTheory,
                    MarksPhysicsPractical = model.MarksPhysicsPractical,
                    FullmarksPhysics = model.MarksPhysicsTheory + model.MarksPhysicsPractical,


                    MarksChemistryTheory = model.MarksChemistryTheory,
                    MarksChemistryPractical = model.MarksChemistryPractical,
                    FullmarksChemistry = model.MarksChemistryTheory + model.MarksChemistryPractical,


                    MarksBiologyTheory = model.MarksBiologyTheory,
                    MarksBiologyPractical = model.MarksBiologyPractical,
                    FullmarksBiology = model.MarksBiologyTheory + model.MarksBiologyPractical,


                    MarksEnglishTheory = model.MarksEnglishTheory,
                    MarksEnglishPractical = model.MarksEnglishPractical,

                    FullmarksEnglish = model.MarksEnglishTheory + model.MarksEnglishPractical,


                    PercentageXii = model.PercentageXii,
                    PercentagePcbXii = model.PercentagePcbXii,
                    PercentagePcbeXii = model.PercentagePcbeXii,

                    NeetUgCurrentScore = model.NeetUgCurrentScore,
                    NeetUgScoresheet = ConvertImageToByteArray(model.NeetUgScoresheet),

                    ApplicationStatus = 1,



                    DataEntryTimestamp = DateTime.Now,
                    DataEntryIp = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                    AgeAsOnCutOffDate = age,
                };

                context.Add(dataBase);
                context.SaveChanges();
                var latestApplicant = context.ApplicantsMbbs
                                                .OrderByDescending(e => e.ApplicantId)
                                                .FirstOrDefault();

                if (latestApplicant != null)
                {
                    int latestApplicantId = latestApplicant.ApplicantId;

                    var preferences = new PreferenceMbb
                    {
                        ApplicantId = latestApplicantId,
                        MbbsCourseCode = 1,
                        Preference = model.MBBS1
                    };

                    context.PreferenceMbbs.Add(preferences);


                    var preferences3 = new PreferenceMbb
                    {
                        ApplicantId = latestApplicantId,
                        MbbsCourseCode = 2,
                        Preference = model.BDS2
                    };

                    context.PreferenceMbbs.Add(preferences3);

                    var preferences4 = new PreferenceMbb
                    {
                        ApplicantId = latestApplicantId,
                        MbbsCourseCode = 3,
                        Preference = model.BHMS3
                    };

                    context.PreferenceMbbs.Add(preferences4);

                    var preferences5 = new PreferenceMbb
                    {
                        ApplicantId = latestApplicantId,
                        MbbsCourseCode = 4,
                        Preference = model.BAMS4
                    };

                    context.PreferenceMbbs.Add(preferences5);

                    preferences5 = new PreferenceMbb
                    {
                        ApplicantId = latestApplicantId,
                        MbbsCourseCode = 5,
                        Preference = model.BASLP5
                    };

                    context.PreferenceMbbs.Add(preferences5);

                    context.SaveChanges();
                }
                else
                {
                    // Handle the case when no applicants are found in the database
                }

                

               
                return RedirectToAction("Display");
            }
            else
            {
                return View(model);
            }
        }
        public byte[]? ConvertImageToByteArray(IFormFile imageFile)
        {
            if (imageFile != null)
            {
                using var stream = new MemoryStream();
                imageFile.CopyTo(stream);
                return stream.ToArray();
            }
            else
            {
                return null;
            }

        }


        //Original

        public IActionResult Display()
        {
            var applicants = context.ApplicantsMbbs.ToList();
            return View(applicants);
        }

        // GET: ApplicantsMbbs/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || context.ApplicantsMbbs == null)
            {
                return NotFound();
            }

            var applicantsMbb = await context.ApplicantsMbbs
                .FirstOrDefaultAsync(m => m.ApplicantId == id);
            if (applicantsMbb == null)
            {
                return NotFound();
            }

            return View(applicantsMbb);
        }

        [HttpPost]
        public IActionResult Details(int id, int appStatus, string remarks)
        {

            var existingApplicant = context.ApplicantsMbbs.FirstOrDefault(a => a.ApplicantId == id);
            existingApplicant.Remarks = remarks;
            existingApplicant.ApplicationStatus = appStatus;

            //existingApplicant.Remarks = "Via Hard Code";
            //existingApplicant.ApplicationStatus = 1;

            context.Update(existingApplicant);
            context.SaveChanges();
            return RedirectToAction("Display");
        }


        // GET: ApplicantsMbbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || context.ApplicantsMbbs == null)
            {
                return NotFound();
            }

            var applicantsMbb = await context.ApplicantsMbbs.FindAsync(id);
            if (applicantsMbb == null)
            {
                return NotFound();
            }
            return View(applicantsMbb);
        }


        [HttpGet]
        public IActionResult Index()
        {
            var applicants = context.ApplicantsMbbs.ToList();
            return View(applicants);
        }
        private bool ApplicantsMbbExists(int id)
        {
            return (context.ApplicantsMbbs?.Any(e => e.ApplicantId == id)).GetValueOrDefault();
        }

    }
}
