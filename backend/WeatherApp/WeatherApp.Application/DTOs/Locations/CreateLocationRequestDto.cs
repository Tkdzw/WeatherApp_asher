using System.ComponentModel.DataAnnotations;

public class CreateLocationRequest
{
    [Required]
    public string City { get; set; }

    [Required]
    public string Country { get; set; }
}
