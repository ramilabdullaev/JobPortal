using JobPortal.Data.Model;
using JobPortal.Data.ViewModel;

namespace JobPortal.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository) => _jobRepository = jobRepository;

        public Task Create(JobVM jobVM) => _jobRepository.Add(new Job
        {
            Name = jobVM.Name,
            Description = jobVM.Description,
            Category = jobVM.Category,
            Industry = jobVM.Industry,
        });

        public Task Delete(int jobId) => _jobRepository.Delete(jobId);

        public async Task<IEnumerable<JobVM>> GetAll(Category category, Industry industry, string searchString)
        {
            var jobs = await  _jobRepository.GetAll(category, industry, searchString);

            return jobs.Select(x => new JobVM
            {
                Id = x.Id,
                Category = x.Category,
                Description = x.Description,
                Industry = x.Industry,
                Name = x.Name,
            });
        }

        public async Task<IEnumerable<JobVM>> GetAll()
        {
            var jobs = await  _jobRepository.GetAll();

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