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

    public async Task<EntityWithCountDto<Teacher>> GetTeachersAsync(int pageSize, int pageNumber,
        CancellationToken cancellationToken)
    {
        var totalCount = await _context.Teachers.CountAsync(cancellationToken);

        var teachers = await _context.Teachers.Skip((pageNumber - 1) * pageSize).Take(pageSize)
            .ToListAsync(cancellationToken: cancellationToken);

        return new EntityWithCountDto<Teacher>()
        {
            TotalCount = totalCount,
            Data = teachers
        };
    }

    public async Task<Teacher> GetTeacherByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var teacher =
            await _context.Teachers
                .SingleOrDefaultAsync(s => s.Id == id, cancellationToken: cancellationToken) ??
            throw new NotFoundException("Teacher not found");

        return teacher;
    }

    public async Task<TeacherDetailsDto> GetTeacherDetailsAsync(Guid id, int pageSize, int pageNumber,
        CancellationToken cancellationToken)
    {
        var departments =
            await _context.Departments
                .Where(d => d.Teachers.Any(t => t.Id == id))
                .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .ToListAsync(cancellationToken: cancellationToken) ??
            throw new NotFoundException("Department not found");

        var subjects =
            await _context.Subjects
                .Where(s => s.Teachers.Any(t => t.Id == id))
                .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .ToListAsync(cancellationToken: cancellationToken) ?? throw new NotFoundException("Subject not found");

        var grades =
            await _context.Grades
                .Where(g => g.TeacherId == id)
                .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .ToListAsync(cancellationToken: cancellationToken) ?? throw new NotFoundException("Grade not found");

        return new TeacherDetailsDto()
        {
            Departments = new EntityWithCountDto<Department>()
            {
                Data = departments,
                TotalCount = departments.Count
            },
            Subjects = new EntityWithCountDto<Subject>()
            {
                Data = subjects,
                TotalCount = subjects.Count
            },
            Grades = new EntityWithCountDto<Grade>()
            {
                Data = grades,
                TotalCount = grades.Count
            }
        };
    }
}