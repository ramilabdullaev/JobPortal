using JobPortal.Data.Model;
using JobPortal.Data.ViewModel;

public interface IJobRepository
{
    Task<Job> GetById(int id);
    Task<IEnumerable<Job>> GetAll();
    Task Add(Job job);
    Task Delete(int jobId);
    Task<IEnumerable<JobVM>> GetFiltered(Category category, Industry industry);
}
