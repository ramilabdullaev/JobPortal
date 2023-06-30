using JobPortal.Data.Paging;
using JobPortal.Data.ViewModel;
using JobPortal.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    public class UserController : Controller
    {
        private readonly IApplicantService _applicantService;
        private readonly IJobService _jobService;

        public UserController(IApplicantService applicantService, IJobService jobService)
        {
            _applicantService = applicantService;
            _jobService = jobService;
        }

        public async Task<IActionResult> Index(Category category, Industry industry, int? pageNumber,  string sortByName = "", string searchString = "")
        {
            var jobVMs = await _jobService.GetAll(category, industry, searchString);
            ViewBag.NameSortParam = String.IsNullOrEmpty(sortByName) ? "name_desc" : "";

            jobVMs = sortByName switch
            {
                "name_desc" => jobVMs.OrderByDescending(x => x.Name),
                _ => jobVMs.OrderBy(x => x.Name),
            };

            return View(PaginatedList<JobVM>.Create(jobVMs.AsQueryable(), pageNumber ?? 1, 4));
        }

        public async Task<IActionResult> Apply(int jobId)
        {
            var applicant = new CreateApplicantVM { JobId = jobId };
            return View(applicant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Apply(CreateApplicantVM applicantVM)
        {
            if (!ModelState.IsValid)
            {
                return View(applicantVM);
            }
            await _applicantService.Create(applicantVM);

            return RedirectToAction(nameof(Index));
        }
    }
}