using JobPortal.Data.Model;
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

        public  async Task<ActionResult> Update(int id)
        {
            var jobVM = await _applicantService.GetById(id);
            return View(jobVM);
        }


        public ActionResult Delete(int id)
        {
            _jobService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Download(int id)
        {
            var file = await _applicantService.Download(id);
            return File(file, "application/pdf");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobVM jobVM)
        {
            if (!ModelState.IsValid)
            {
                return View(jobVM);
            }
            _jobService.Create(jobVM);

            return RedirectToAction(nameof(Index));
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Update(JobVM jobVM)
        //{
        //    _jobService.Update(jobVM);

        //    return RedirectToAction(nameof(Index));
        //}
    }
}