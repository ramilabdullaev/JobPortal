using JobPortal.Data.Model;

public interface IApplicantRepository
{
    Task<IEnumerable<Applicant>> GetAll();
    Task Add(Applicant applicant);
    Task Update(Applicant applicant);
    Task Delete(int applicantId);
    Task<byte[]> Download(int applicantId);
    Task<Job> GetById(int id);
}
