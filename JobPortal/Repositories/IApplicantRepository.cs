using JobPortal.Data.Dto;

public interface IApplicantRepository
{
    Task<IEnumerable<Applicant>> GetAll();
    Task Add(Applicant applicant);
    Task Update(Applicant applicant);
    Task<bool> Delete(int applicantId);
    Task<byte[]> Download(int applicantId);
}
