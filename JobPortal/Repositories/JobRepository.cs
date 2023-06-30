using JobPortal.Data;
using JobPortal.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly DataContext _context;

        public JobRepository(DataContext context) => _context = context;

        public async Task Add(Job job)
        {
            await _context.AddAsync(job);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int jobId)
        {
            var job = await _context.Jobs.FirstOrDefaultAsync(x => x.Id == jobId);
            if (job != null)
            {
                _context.Jobs.Remove(job);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Job>> GetAll(Category category, Industry industry, string searchString)
        {
            searchString = string.IsNullOrEmpty(searchString) ? "" : searchString.ToLower();

            var jobList =  _context.Jobs.Where(x => x.Name.ToLower().StartsWith(searchString));
            if (category != Category.none)
            {
                jobList = jobList.Where(j => j.Category == category);
            }

            if (industry != Industry.none)
            {
                jobList = jobList.Where(j => j.Industry == industry);
            }

            return jobList;
        }
        public async Task<IEnumerable<Job>> GetAll() => await _context.Jobs.ToListAsync();

        public async Task<Job> GetById(int id) 
            => await _context.Jobs.FirstOrDefaultAsync(x => x.Id == id);

    }
}
