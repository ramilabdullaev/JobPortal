using JobPortal.Data.ViewModel;

namespace JobPortal.Services
{
    public interface IJobService
    {
        Task<IEnumerable<JobVM>> GetAll();
        Task<IEnumerable<JobVM>> GetAll(Category category, Industry industry, string searchString = "");
        Task Create(JobVM jobVM);
        Task Delete(int jobId);
    }
}