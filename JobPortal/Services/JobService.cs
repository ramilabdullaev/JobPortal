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
    }
}


