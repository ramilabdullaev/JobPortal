using JobPortal.Data.Model;

public interface IJobRepository
{
    Task<Job> GetById(int id);
    Task<IEnumerable<Job>> GetAll();
    Task Add(Job job);
    Task<bool> Delete(int jobId);
}
