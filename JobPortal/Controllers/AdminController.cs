﻿using JobPortal.Data.ViewModel;
using JobPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IApplicantService _applicantService;
        private readonly IJobService _jobService;

        public AdminController(IJobService jobService, IApplicantService applicantService)
        {
            _jobService = jobService;
            _applicantService = applicantService;
        }

        public async Task<IActionResult> Index(string sortName)
        {
            var applicants = await _applicantService.GetAll();

            ViewBag.SortByJobName = String.IsNullOrEmpty(sortName) ? "desc_JobName" : "";
            ViewBag.SortByFirstName = String.IsNullOrEmpty(sortName) ? "desc_FirstName" : "firstName";

            applicants = sortName switch
            {
                "desc_JobName" => applicants.OrderByDescending(a => a.JobName),
                "desc_FirstName" => applicants.OrderByDescending(a => a.FirstName),
                "firstName" => applicants.OrderBy(a => a.FirstName),
                _ => applicants.OrderBy(_ => _.JobName)
            };

            return View(applicants);
        }

        public async Task<IActionResult> ListOfJobs()
        {
            return View(await _jobService.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> DeleteApplicantById(int id)
        {
            await _applicantService.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteJobById(int id)
        {
            await _jobService.Delete(id);
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
        public async Task<IActionResult> Create(JobVM jobVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(jobVM);
                }
                await _jobService.Create(jobVM);

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