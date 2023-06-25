﻿using JobPortal.Data.Paging;
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

        public async Task<IActionResult> Index(Category category, Industry industry, int? pageNumber)
        {
            if (category != Category.none || industry != Industry.none)
            {
                var jobVMs = await _jobService.GetFiltered(category, industry);
                return View(PaginatedList<JobVM>.Create((IQueryable<JobVM>)jobVMs.AsQueryable(), pageNumber ?? 1, 3));
            }
            var jobs = await _jobService.GetAll();
            return View(PaginatedList<JobVM>.Create((IQueryable<JobVM>)jobs.AsQueryable(), pageNumber ?? 1, 3));
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