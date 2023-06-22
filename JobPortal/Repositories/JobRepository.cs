using JobPortal.Data;
using JobPortal.Data.Model;
using JobPortal.Data.ViewModel;
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

        public async Task<IEnumerable<Job>> GetAll() => await _context.Jobs.ToListAsync();

        public async Task<Job> GetById(int id) => await _context.Jobs.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<JobVM>> GetFiltered(Category category, Industry industry)
        {
            var jobs = _context.Jobs.AsQueryable();

            if (category != Category.none)
            {
                jobs = jobs.Where(j => j.Category == category);
            }

            if (industry != Industry.none)
            {
                jobs = jobs.Where(j => j.Industry == industry);
            }

            return await jobs.Select(j => new JobVM
            {
                Id = j.Id,
                Category = j.Category,
                Description = j.Description,
                Industry = j.Industry,
                Name = j.Name
            }).ToListAsync();
        }
    }
}
