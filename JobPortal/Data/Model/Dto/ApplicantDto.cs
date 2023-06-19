namespace JobPortal.Data.Model.Dto
{
    public class ApplicantDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Job Job { get; set; }
        public string CVPath { get; set; }
    }
}
