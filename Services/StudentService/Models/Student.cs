using System.ComponentModel.DataAnnotations;

namespace StudentService.Models;

public class Student
{
    public int Id {get;set;}
    [Required]
    [MaxLength(50)]
    public string FirstName {get;set;} = string.Empty;

    [Required]
    [MaxLength(50)]
    public string LastName {get;set;} = string.Empty;


    [Required]
    [MaxLength(150)]
    [EmailAddress]
    public string Email {get;set;} =  string.Empty;

    [MaxLength(20)]
    public string? Phone {get;set;}


    public DateTime DateOfBirth { get;set;}

    public bool IsActive {get;set;} = true;

    public DateTime CreatedAt {get;set;} = DateTime.UtcNow;
    
    public DateTime? UpdatedAt {get;set;}





}