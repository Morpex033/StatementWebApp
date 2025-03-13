using Microsoft.EntityFrameworkCore;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Entity;
using StatementWebApp.Core.Exception;
using StatementWebApp.Core.Interface;
using StatementWebApp.Persistence.Context;

namespace StatementWebApp.Persistence.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly CustomDbContext _context;

    public TeacherRepository(CustomDbContext context)
    {
        _context = context;
    }

    public async Task<List<Teacher>> GetTeachersAsync(CancellationToken cancellationToken)
    {
        return await _context.Teachers.ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<Teacher> GetTeacherByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var teacher =
            await _context.Teachers
                .SingleOrDefaultAsync(s => s.Id == id, cancellationToken: cancellationToken) ??
            throw new NotFoundException("Teacher not found");

        return teacher;
    }

    public async Task<TeacherDetailsDto> GetTeacherDetailsAsync(Guid id, CancellationToken cancellationToken)
    {
        var teacher = await GetTeacherByIdAsync(id, cancellationToken);

        var departments =
            await _context.Departments.Where(d => d.Teachers.Contains(teacher))
                .ToListAsync(cancellationToken: cancellationToken) ??
            throw new NotFoundException("Department not found");

        var subjects =
            await _context.Subjects.Where(s => s.Teachers.Contains(teacher))
                .ToListAsync(cancellationToken: cancellationToken) ?? throw new NotFoundException("Subject not found");

        var grades =
            await _context.Grades.Where(g => g.TeacherId == teacher.Id)
                .ToListAsync(cancellationToken: cancellationToken) ?? throw new NotFoundException("Grade not found");

        return new TeacherDetailsDto()
        {
            Departments = departments,
            Subjects = subjects,
            Grades = grades
        };
    }
}