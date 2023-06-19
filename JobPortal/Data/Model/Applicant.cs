public class Applicant
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int JobId { get; set; }

    public Job Job{ get; set; }
    public string CVPath { get; set; }

    public Stream GetCV => new FileStream(CVPath, FileMode.Open);

}
