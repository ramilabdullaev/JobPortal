using System.ComponentModel.DataAnnotations;

public class Job
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is requred")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Description is requred")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Category is requred")]
    public Category Category { get; set; }

    [Required(ErrorMessage = "Industry is requred")]
    public Industry Industry { get; set; }
}

