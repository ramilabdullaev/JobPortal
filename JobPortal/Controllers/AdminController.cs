using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetAllApplicants()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddJob([FromBody] object jobDto)
        {
            return View();
        }

        [HttpDelete]
        public IActionResult DeleteJob(int id)
        {
            return View();
        }
    }
}