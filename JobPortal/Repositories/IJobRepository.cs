public interface IJobRepository
{
    Task<IEnumerable<Job>> GetAll();
    Task Add(Job job);
    Task Update(Job job);
    Task Delete(int jobId);
}
