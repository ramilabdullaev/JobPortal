using JobPortal.Data.ViewModel;

namespace JobPortal.Services
{
    public interface IApplicantService
    {
        Task Create(CreateApplicantVM applicantVM);
        Task <IEnumerable<ReadApplicantVM>> GetAll();
        Task<byte[]> Download(int applicantId);
        Task<JobVM> GetById(int id);
        Task DeleteById(int id);
    }
}