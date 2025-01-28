using Microsoft.EntityFrameworkCore;
using StatementWebApp.Core.Entity;

namespace StatementWebApp.Persistence.Context;

public class CustomDbContext : DbContext
{
    public CustomDbContext(DbContextOptions<CustomDbContext> options)
        : base(options)
    {
    }

    public DbSet<Grade> Grades { get; set; }

    public DbSet<Student> Students { get; set; }

    public DbSet<Subject> Subjects { get; set; }

    public DbSet<Teacher> Teachers { get; set; }

    public DbSet<Group> Groups { get; set; }

    public DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomDbContext).Assembly);
    }
}