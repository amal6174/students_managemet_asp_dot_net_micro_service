using System.ComponentModel.DataAnnotations;


namespace StudentService.DTOs;

public class StudentCreateDto
{

    [Required]
    [MaxLength(100)]
    public string FirstName {get;set;} = string.Empty;

    [Required]
    [MaxLength(100)]
    public string LastName {get;set;} = string
    
}