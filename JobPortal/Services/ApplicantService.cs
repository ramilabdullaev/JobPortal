using JobPortal.Data.ViewModel;

namespace JobPortal.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IJobRepository _jobRepository;
        public ApplicantService(IApplicantRepository repository, IJobRepository jobRepository)
        {
            _applicantRepository = repository;
            _jobRepository = jobRepository;
        }

        public async Task Create(CreateApplicantVM applicantVM)
        {
            var cv = ReadFully(applicantVM.File.OpenReadStream());
            var job = await _jobRepository.GetById(applicantVM.JobId);

            await _applicantRepository.Add(new Applicant
            {
                FirstName = applicantVM.FirstName,
                LastName = applicantVM.LastName,
                Email = applicantVM.Email,
                JobId = applicantVM.JobId,
                Job = job,
                CV = cv
            });
        }

        private static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public async Task<IEnumerable<ReadApplicantVM>> GetAll()
        {
            var applicants = await _applicantRepository.GetAll();

            return applicants.Select(x => new ReadApplicantVM
            {
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                JobName = x.Job.Name,
                ApplicantId = x.Id,
            });
        }

        public Task<byte[]> Download(int applicantId)
        {
            return  _applicantRepository.Download(applicantId);
        }
    }
}
