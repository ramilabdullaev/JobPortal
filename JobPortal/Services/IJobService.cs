using JobPortal.Data.ViewModel;

namespace JobPortal.Services
{
    public interface IJobService
    {
        Task<IEnumerable<JobVM>> GetAll();
        Task Create(JobVM jobVM);
        Task Delete(int jobId);
        Task<IEnumerable<JobVM>> GetFiltered(string category, string industry);
    }
}


