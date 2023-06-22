using JobPortal.Data.Model;
using System.ComponentModel.DataAnnotations;

public class Applicant
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "FirstName is requred")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "LastName is requred")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email is requred")]
    public string Email { get; set; }

    public int JobId { get; set; }

    public Job Job{ get; set; }

    public byte[] CV{ get; set; }
}
