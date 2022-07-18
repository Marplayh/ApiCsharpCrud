using System.ComponentModel.DataAnnotations;

namespace mySQLAPI.Model;

public class User
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public int Age { get; set; }

}
