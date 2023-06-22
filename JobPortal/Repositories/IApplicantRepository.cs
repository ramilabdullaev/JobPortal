using JobPortal.Data.Model;
using JobPortal.Data.ViewModel;

public interface IApplicantRepository
{
    Task<IEnumerable<Applicant>> GetAll();
    Task Add(Applicant applicant);
    Task Delete(int applicantId);
    Task<byte[]> Download(int applicantId);
    Task<Job> GetById(int id);
}
