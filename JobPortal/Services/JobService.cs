using JobPortal.Data.Model;
using JobPortal.Data.ViewModel;

namespace JobPortal.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task Create(JobVM jobVM)
        {
            await _jobRepository.Add(new Job
            {
                Name = jobVM.Name,
                Description = jobVM.Description,
                Category = jobVM.Category,
                Industry = jobVM.Industry,
            });
        }

        public async Task Delete(int jobId)
        {
            await _jobRepository.Delete(jobId);
        }


        public async Task<IEnumerable<JobVM>> GetAll()
        {
            var jobs = await _jobRepository.GetAll();

            return jobs.Select(x => new JobVM
            {
                Id = x.Id,
                Category = x.Category,
                Description = x.Description,
                Industry = x.Industry,
                Name = x.Name,
            });
        }

        public async Task<IEnumerable<JobVM>> GetFiltered(string category, string industry)
        {
            var jobs = await GetAll();

            if (!string.IsNullOrEmpty(category))
            {
                if (Enum.TryParse(category, ignoreCase: true, out Category categoryEnum))
                {
                    jobs = jobs.Where(j => j.Category == categoryEnum).ToList();
                }
            }

            if (!string.IsNullOrEmpty(industry))
            {
                if (Enum.TryParse(industry, ignoreCase: true, out Industry industryEnum))
                {
                    jobs = jobs.Where(j => j.Industry == industryEnum).ToList();
                }
            }

            return jobs;
        }
    }
}