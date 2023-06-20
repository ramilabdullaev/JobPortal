using JobPortal.Data.Dto;
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


        public IActionResult ListOfJobs()
        {
            return View(new List<JobDto> { new JobDto { Category = Category.partTime, Description = "descr", Industry = Industry.IT, Name = "name" } });
        }

        public ActionResult Create()
        {

            return View();
        }

        public async Task<IActionResult> Dowload(int applicantId)
        {
            var file = await _applicantService.Download(applicantId);
            return File(file, "application/pdf");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var job = new Job
                {
                    Category = Enum.Parse<Category>(collection[nameof(JobVM.Category)]),
                    Description = collection[nameof(JobVM.Description)],
                    Industry = Enum.Parse<Industry>(collection[nameof(JobVM.Industry)]),
                    Name = collection[nameof(JobVM.Name)]
                };

                //_repository.SaveJob(job);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}