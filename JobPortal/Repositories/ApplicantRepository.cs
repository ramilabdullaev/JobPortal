using JobPortal.Data.Dto;
using static System.Reflection.Metadata.BlobBuilder;

namespace JobPortal.Repositories
{
    public class ApplicantRepository : IApplicantRepository
    {
        List<Applicant> _applicants = new();

        public Task Add(Applicant applicant)
        {
            _applicants.Add(applicant);
            return Task.CompletedTask;
        }

        public Task<bool> Delete(int applicantId)
        {
            var applicant = _applicants.FirstOrDefault(applicant => applicant.Id == applicantId);
            if (applicant == null)
            {
                return Task.FromResult(false);
            }

            _applicants.Remove(applicant);
            return Task.FromResult(true);
        }

        public Task<byte[]> Download(int applicantId)
        {
            var applicant = _applicants.First(x => x.Id == applicantId);

            return Task.FromResult(applicant.CV);
        }

        public Task<IEnumerable<Applicant>> GetAll()
        {
            return Task.FromResult(_applicants.AsEnumerable());
        }

        public Task Update(Applicant applicant)
        {
            throw new NotImplementedException();
        }
    }
}
