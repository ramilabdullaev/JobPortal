using JobPortal.Data.ViewModel;
using JobPortal.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    public class AdminController : Controller
    {
        private readonly IApplicantService _applicantService;
        private readonly IJobService _jobService;

        public AdminController(IJobService jobService, IApplicantService applicantService)
        {
            _jobService = jobService;
            _applicantService = applicantService;
        }

        public async Task<IActionResult> Index()
        {
            var applicants = await _applicantService.GetAll();

            return View(applicants);
        }

        public async Task<IActionResult> ListOfJobs()
        {
            return View(await _jobService.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            _jobService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Download(int id)
        {
            try
            {
                var file = await _applicantService.Download(id);
                if (file == null)
                {
                    TempData["ErrorMessage"] = "File not found.";
                    return RedirectToAction(nameof(Index));
                }
                return File(file, "application/pdf");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while downloading the file.";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobVM jobVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(jobVM);
                }
                _jobService.Create(jobVM);

                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "An error occurred while creating the job.";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}