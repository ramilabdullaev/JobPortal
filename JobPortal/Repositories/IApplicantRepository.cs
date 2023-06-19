public interface IApplicantRepository
{
    Task<IEnumerable<Applicant>> GetAll();
    Task Add(Applicant applicant);
    Task Update(Applicant applicant);
    Task Delete(int applicantId);
}
