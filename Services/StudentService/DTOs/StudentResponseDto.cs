
namespace StudentService.DTOs;

public class StudentResponseDto
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string? Phone { get; set; }

    public DateTime DateOfBirth { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }
}
