using JobPortal.Data.Dto;

namespace JobPortal.Repositories
{
    public class JobRepository : IJobRepository
    {
        List<Job> _jobs = new List<Job>
        {
            new Job
            {
                Category = Category.partTime,
                Description = "descr",
                Industry = Industry.IT,
                Name = "name" ,
                Id = 1
            }
        };

        public Task Add(JobDto job)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int jobId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Job>> GetAll()
        {
            return Task.FromResult(_jobs.AsEnumerable());
        }

        public Task<Job> GetById(int id)
        {
           var job = _jobs.First(x => x.Id == id);

            return Task.FromResult(job);
        }

        public Task Update(JobDto job)
        {
            throw new NotImplementedException();
        }
    }
}
