using JobPortal.Data.Model.Dto;
using JobPortal.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View(new List<JobDto> { new JobDto {  Category = Category.partTime, Description ="descr", Industry = "indus",Name= "name"} });
        }

        public IActionResult Apply(string jobName)
        {
            var applicant = new ApplicantVM { JobName = jobName };
            return View(applicant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Apply(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}