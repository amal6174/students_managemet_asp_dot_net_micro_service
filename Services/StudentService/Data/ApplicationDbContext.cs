using Microsoft.EntityFrameworkCore;

using StudentService.Models;

namespace StudentService.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
    {
        
    }

    public DbSet<Student> Students {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

          modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("students");

            entity.HasKey(s => s.Id);

            entity.HasIndex(s => s.Email)
                  .IsUnique();

            entity.Property(s => s.FirstName)
                  .HasMaxLength(100)
                  .IsRequired();

            entity.Property(s => s.LastName)
                  .HasMaxLength(100)
                  .IsRequired();

            entity.Property(s => s.Email)
                  .HasMaxLength(150)
                  .IsRequired();
        });
    }
}