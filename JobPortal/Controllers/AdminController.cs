using JobPortal.Data.Model.Dto;
using JobPortal.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Core.Types;

namespace JobPortal.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View(new List<ApplicantDto> { new ApplicantDto { Email = "ba4ioglu", FirstName = "Ivan", LastName = "Ivanov", Job = new Job { Name = "dev" } } });
        }


        public IActionResult ListOfJobs()
        {
            return View(new List<JobDto> { new JobDto { Category = Category.partTime, Description = "descr", Industry = Industry.IT, Name = "name" } });
        }

        public ActionResult Create()
        {

            return View();
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