using JobPortal.Data;
using JobPortal.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Repositories
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly DataContext _context;
        public ApplicantRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Add(Applicant applicant)
        {
            await _context.Applicants.AddAsync(applicant);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int applicantId)
        {
            var applicant = await _context.Applicants.FirstOrDefaultAsync(applicant => applicant.Id == applicantId);
            if (applicant != null)
            {
                _context.Applicants.Remove(applicant);
                await _context.SaveChangesAsync();
            }
        }

        public Task<byte[]> Download(int applicantId)
        {
            return _context.Applicants
                .Where(x => x.Id == applicantId)
                .Select(x => x.CV)
                .SingleAsync();
        }

        public async Task<IEnumerable<Applicant>> GetAll()
        {
            return  await _context.Applicants.Include(j => j.Job).ToListAsync();
        }

        public async Task<Job> GetById(int id)
        {
            return  await _context.Jobs.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
