using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services;
using AUF.EMR.MVC.Models.EditVM;
using AUF.EMR.MVC.Models.IndexVM;
using AUF.EMR.MVC.Models.PrintVM;
using FastReport.Export.PdfSimple;
using FastReport.Utils;
using FastReport;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AUF.EMR.MVC.Models.DetailVM;

namespace AUF.EMR.MVC.Controllers
{
    [Authorize(Policy = "User")]
    public class OralHealthClientController : Controller
    {
        private readonly IOralHealthService _oralHealthService;
        private readonly IBarangayService _brgyService;
        private readonly IHouseholdMemberService _householdMemberService;
        private readonly IHouseholdService _householdService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public OralHealthClientController(IOralHealthService oralHealthService,
            IBarangayService brgyService,
            IHouseholdMemberService householdMemberService,
            IHouseholdService householdService,
            IWebHostEnvironment webHostEnvironment)
        {
            _oralHealthService = oralHealthService;
            _brgyService = brgyService;
            _householdMemberService = householdMemberService;
            _householdService = householdService;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: OralHealthClient/Details
        public async Task<ActionResult> Details(int? id, string requestUrl, string householdNo)
        {
            if (id == null || string.IsNullOrWhiteSpace(householdNo))
            {
                return NotFound();
            }

            var member = await _householdMemberService.GetHouseholdMemberWithDetails(id.Value);

            if (member == null)
            {
                return NotFound();
            }

            int.TryParse(member.Age.Split(" ")[0], out int age);

            var model = new DetailHouseholdMemberVM
            {
                HouseholdMember = member,
                RequestUrl = requestUrl,
                HouseholdNo = householdNo,
            };

            return View(model);
        }

        // GET: MasterlistController/EditOralHealthInfo
        public async Task<ActionResult> EditOralHealthInfo(int? id, string requestUrl, string householdNo)
        {
            if (id == null || string.IsNullOrWhiteSpace(householdNo))
            {
                return NotFound();
            }

            var member = await _householdMemberService.GetHouseholdMemberWithDetails(id.Value);

            if (member == null)
            {
                return NotFound();
            }

            int.TryParse(member.Age.Split(" ")[0], out int age);
            var ageSuffix = member.Age.Split(" ")[1];

            var model = new EditHouseholdMemberVM
            {
                HouseholdMember = member,
                RequestUrl = requestUrl,
                HouseholdNo = householdNo,
                AgePrefix = age,
                AgeSuffix = ageSuffix
            };

            return View(model);
        }

        // POST: MasterlistController/EditOralHealthInfo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditOralHealthInfo(int? id, EditHouseholdMemberVM model)
        {
            if (model == null || id == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var householdMember = model.HouseholdMember;
                householdMember.Age = $"{model.AgePrefix} {model.AgeSuffix}";
                var completed = await _householdMemberService.Update(householdMember);

                return Redirect(model.RequestUrl);
            }
            catch (Exception ex)
            {
                model.ErrorMessage = ex.Message;
                return View(model);
            }
        }

        // GET: OralHealthClientController/Infant
        public async Task<ActionResult> Infant(string householdNo)
        {
            if (string.IsNullOrWhiteSpace(householdNo))
            {
                return NotFound();
            }

            var existing = await _householdService.IsHouseholdNoExisting(householdNo);

            if (!existing)
            {
                return NotFound();
            }

            var members = await _oralHealthService.GetOralClientInfant(householdNo);
            var model = new HouseholdMemberListVM
            {
                HouseholdMembers = members,
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString,
                HouseholdNo = householdNo,
            };
            return View(model);
        }

        // GET: OralHealthClientController/OneToFour
        public async Task<ActionResult> OneToFour(string householdNo)
        {
            if (string.IsNullOrWhiteSpace(householdNo))
            {
                return NotFound();
            }

            var existing = await _householdService.IsHouseholdNoExisting(householdNo);

            if (!existing)
            {
                return NotFound();
            }

            var members = await _oralHealthService.GetOralClient1to4(householdNo);
            var model = new HouseholdMemberListVM
            {
                HouseholdMembers = members,
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString,
                HouseholdNo = householdNo,
            };
            return View(model);
        }

        // GET: OralHealthClientController/FiveToNine
        public async Task<ActionResult> FiveToNine(string householdNo)
        {
            if (string.IsNullOrWhiteSpace(householdNo))
            {
                return NotFound();
            }

            var existing = await _householdService.IsHouseholdNoExisting(householdNo);

            if (!existing)
            {
                return NotFound();
            }

            var members = await _oralHealthService.GetOralClient5to9(householdNo);
            var model = new HouseholdMemberListVM
            {
                HouseholdMembers = members,
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString,
                HouseholdNo = householdNo,
            };
            return View(model);
        }

        // GET: OralHealthClientController/TenToFourteen
        public async Task<ActionResult> TenToFourteen(string householdNo)
        {
            if (string.IsNullOrWhiteSpace(householdNo))
            {
                return NotFound();
            }

            var existing = await _householdService.IsHouseholdNoExisting(householdNo);

            if (!existing)
            {
                return NotFound();
            }

            var members = await _oralHealthService.GetOralClient10to14(householdNo);
            var model = new HouseholdMemberListVM
            {
                HouseholdMembers = members,
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString,
                HouseholdNo = householdNo,
            };
            return View(model);
        }

        // GET: OralHealthClientController/FifteenToNineteen
        public async Task<ActionResult> FifteenToNineteen(string householdNo)
        {
            if (string.IsNullOrWhiteSpace(householdNo))
            {
                return NotFound();
            }

            var existing = await _householdService.IsHouseholdNoExisting(householdNo);

            if (!existing)
            {
                return NotFound();
            }

            var members = await _oralHealthService.GetOralClient15to19(householdNo);
            var model = new HouseholdMemberListVM
            {
                HouseholdMembers = members,
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString,
                HouseholdNo = householdNo,
            };
            return View(model);
        }

        // GET: OralHealthClientController/TwentyToFourtynine
        public async Task<ActionResult> TwentyToFourtynine(string householdNo)
        {
            if (string.IsNullOrWhiteSpace(householdNo))
            {
                return NotFound();
            }

            var existing = await _householdService.IsHouseholdNoExisting(householdNo);

            if (!existing)
            {
                return NotFound();
            }

            var members = await _oralHealthService.GetOralClient20to49(householdNo);
            var model = new HouseholdMemberListVM
            {
                HouseholdMembers = members,
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString,
                HouseholdNo = householdNo,
            };
            return View(model);
        }

        // GET: OralHealthClientController/PregnantFifteenToNineteen
        public async Task<ActionResult> PregnantFifteenToNineteen(string householdNo)
        {
            if (string.IsNullOrWhiteSpace(householdNo))
            {
                return NotFound();
            }

            var existing = await _householdService.IsHouseholdNoExisting(householdNo);

            if (!existing)
            {
                return NotFound();
            }

            var members = await _oralHealthService.GetOralClientPregnant15to19(householdNo);
            var model = new HouseholdMemberListVM
            {
                HouseholdMembers = members,
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString,
                HouseholdNo = householdNo,
            };
            return View(model);
        }

        // GET: OralHealthClientController/PregnantTwentyToFourtynine
        public async Task<ActionResult> PregnantTwentyToFourtynine(string householdNo)
        {
            if (string.IsNullOrWhiteSpace(householdNo))
            {
                return NotFound();
            }

            var existing = await _householdService.IsHouseholdNoExisting(householdNo);

            if (!existing)
            {
                return NotFound();
            }

            var members = await _oralHealthService.GetOralClientPregnant20to49(householdNo);
            var model = new HouseholdMemberListVM
            {
                HouseholdMembers = members,
                RequestUrl = HttpContext.Request.Path + HttpContext.Request.QueryString,
                HouseholdNo = householdNo,
            };
            return View(model);
        }

        public async Task<string> Print(string householdNo)
        {
            if (string.IsNullOrWhiteSpace(householdNo))
            {
                return "Household no. is empty";
            }

            try
            {
                var infants = await _oralHealthService.GetOralClientInfant(householdNo);
                var oneToFour = await _oralHealthService.GetOralClient1to4(householdNo);
                var fiveToNine = await _oralHealthService.GetOralClient5to9(householdNo);
                var tenToFourteen = await _oralHealthService.GetOralClient10to14(householdNo);
                var pregFifteenToNineteen = await _oralHealthService.GetOralClientPregnant15to19(householdNo);
                var pregTwentyToFourtyNine = await _oralHealthService.GetOralClientPregnant20to49(householdNo);

                var address = (await _householdService.GetHouseholdWithDetails(householdNo)).FullAddress;

                Config.WebMode = true;
                var report = new Report();
                var contentRootPath = _webHostEnvironment.ContentRootPath;
                var path = Path.Combine(contentRootPath, "Reports", "OralHealth.frx");

                report.Load(path);
                report.RegisterData(infants, "OralInfants");
                report.RegisterData(oneToFour, "OralOneToFour");
                report.RegisterData(fiveToNine, "OralFiveToNine");
                report.RegisterData(tenToFourteen, "OralTenToFourteen");
                report.RegisterData(pregFifteenToNineteen, "OralPregFifteenToNineteen");
                report.RegisterData(pregTwentyToFourtyNine, "OralPregTwentyToFourtyNine");

                report.SetParameterValue("HouseholdNo", householdNo);
                report.SetParameterValue("Address", address);

                if (report.Report.Prepare())
                {
                    var pdfExport = new PDFSimpleExport();
                    pdfExport.ShowProgress = true;
                    pdfExport.Subject = "Subject Report";
                    pdfExport.Title = "Report Title";
                    var memoryStream = new MemoryStream();
                    report.Report.Export(pdfExport, memoryStream);
                    report.Dispose();
                    pdfExport.Dispose();
                    memoryStream.Position = 0;

                    return Convert.ToBase64String(memoryStream.ToArray());
                    //return File(memoryStream, "application/pdf", "household.pdf");
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
