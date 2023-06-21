using JobPortal.Data;
using JobPortal.Data.Model;
using JobPortal.Data.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly DataContext _context;

        public JobRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Add(Job job)
        {
             _context.Add(job);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int jobId)
        {
            var job = _context.Jobs.FirstOrDefault(x => x.Id == jobId);
            if (job != null) 
            {
                 _context.Jobs.Remove(job);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Job>> GetAll()
        {
            return await _context.Jobs.ToListAsync();
        }

        public async Task<Job> GetById(int id)
        {
           return await _context.Jobs.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
