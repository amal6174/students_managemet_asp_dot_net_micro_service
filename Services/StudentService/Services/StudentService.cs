
using StudentService.DTOs;
using StudentService.Models;
using StudentService.Repositories;

namespace StudentService.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repository;

    public StudentService(IStudentRepository repository)
    {
        _repository = repository;
    }

    // Get all students
    public async Task<IEnumerable<StudentResponseDto>> GetAllAsync()
    {
        var students = await _repository.GetAllAsync();

        return students.Select(student => MapToResponseDto(student));
    }

    // Get student by ID
    public async Task<StudentResponseDto?> GetByIdAsync(int id)
    {
        var student = await _repository.GetByIdAsync(id);

        if (student == null)
        {
            return null;
        }

        return MapToResponseDto(student);
    }

    // Create student
    public async Task<StudentResponseDto> CreateAsync(StudentCreateDto dto)
    {
        bool emailExists = await _repository.EmailExistsAsync(dto.Email);

        if (emailExists)
        {
            throw new InvalidOperationException("Email already exists.");
        }

        var student = new Student
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Phone = dto.Phone,
            DateOfBirth = dto.DateOfBirth,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        var createdStudent = await _repository.CreateAsync(student);

        return MapToResponseDto(createdStudent);
    }

    // Update student
    public async Task<StudentResponseDto?> UpdateAsync(
        int id,
        StudentUpdateDto dto)
    {
        var student = await _repository.GetByIdAsync(id);

        if (student == null)
        {
            return null;
        }

        bool emailExists = await _repository.EmailExistsAsync(dto.Email);

        if (emailExists && student.Email != dto.Email)
        {
            throw new InvalidOperationException("Email already exists.");
        }

        student.FirstName = dto.FirstName;
        student.LastName = dto.LastName;
        student.Email = dto.Email;
        student.Phone = dto.Phone;
        student.DateOfBirth = dto.DateOfBirth;
        student.IsActive = dto.IsActive;
        student.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateAsync(student);

        return MapToResponseDto(student);
    }

    // Delete student
    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

    // Map Student Model to Response DTO
    private static StudentResponseDto MapToResponseDto(Student student)
    {
        return new StudentResponseDto
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Email = student.Email,
            Phone = student.Phone,
            DateOfBirth = student.DateOfBirth,
            IsActive = student.IsActive,
            CreatedAt = student.CreatedAt
        };
    }
}
