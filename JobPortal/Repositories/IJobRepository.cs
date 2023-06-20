using JobPortal.Data.Dto;

public interface IJobRepository
{
    Task<Job> GetById(int id);
    Task<IEnumerable<Job>> GetAll();
    Task Add(JobDto job);
    Task Update(JobDto job);
    Task<bool> Delete(int jobId);
}
