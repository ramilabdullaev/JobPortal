
namespace JobPortal.Data.ViewModel
{
    public class CreateApplicantVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int JobId { get; set; } 
        public IFormFile File { get; set; } 
    }

    public class ReadApplicantVM
    {
        public int ApplicantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string JobName { get; set; }
    }
}
