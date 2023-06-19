public interface IJobPostingRepository
{
    Task<IEnumerable<Job>> GetAll();
    Task Add(Job jobPosting);
    Task Update(Job jobPosting);
    Task Delete(int jobId);
}
