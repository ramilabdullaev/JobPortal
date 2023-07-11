using JobPortal.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
    }
}
