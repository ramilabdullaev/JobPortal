using JobPortal.Data.Model;

public interface IJobRepository
{
    Task<Job> GetById(int id);
    Task<IEnumerable<Job>> GetAll(Category category, Industry industry, string searchString = "");
    Task<IEnumerable<Job>> GetAll();
    Task Add(Job job);
    Task Delete(int jobId);
}
