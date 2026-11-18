
using Microsoft.EntityFrameworkCore;
using StudentService.Data;
using StudentService.Models;

namespace StudentService.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly ApplicationDbContext _context;

    public StudentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await _context.Students
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _context.Students
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Student> CreateAsync(Student student)
    {
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();

        return student;
    }

    public async Task<bool> UpdateAsync(Student student)
    {
        _context.Students.Update(student);

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var student = await _context.Students.FindAsync(id);

        if (student == null)
        {
            return false;
        }

        _context.Students.Remove(student);

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _context.Students
            .AnyAsync(s => s.Email == email);
    }
}
