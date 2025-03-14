using Microsoft.EntityFrameworkCore;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Entity;
using StatementWebApp.Core.Exception;
using StatementWebApp.Core.Interface;
using StatementWebApp.Persistence.Context;

namespace StatementWebApp.Persistence.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly CustomDbContext _context;

    public StudentRepository(CustomDbContext context)
    {
        _context = context;
    }


    public async Task<EntityWithCountDto<Student>> GetStudentsAsync(int pageSize, int pageNumber,
        CancellationToken cancellationToken)
    {
        var totalCount = await _context.Students.CountAsync(cancellationToken);

        var students = await _context.Students.Skip((pageNumber - 1) * pageSize).Take(pageSize)
            .ToListAsync(cancellationToken: cancellationToken);

        return new EntityWithCountDto<Student>()
        {
            TotalCount = totalCount,
            Data = students
        };
    }

    public async Task<Student> GetStudentByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var student =
            await _context.Students
                .SingleOrDefaultAsync(s => s.Id == id, cancellationToken: cancellationToken) ??
            throw new NotFoundException("Student not found");

        return student;
    }

    public async Task<StudentDetailsDto> GetStudentDetailsAsync(Guid id, int pageSize, int pageNumber,
        CancellationToken cancellationToken)
    {
        var group = await _context.Groups
                        .Where(g => g.Students.Any(s => s.Id == id))
                        .SingleOrDefaultAsync(cancellationToken) ??
                    throw new NotFoundException("Group not found");

        var subjects = await _context.Subjects
            .Where(s => s.Students.Any(student => student.Id == id))
            .Skip((pageNumber - 1) * pageSize).Take(pageSize)
            .ToListAsync(cancellationToken: cancellationToken);

        await _context.Grades.Where(g => g.StudentId == id)
            .ToListAsync(cancellationToken: cancellationToken);

        return new StudentDetailsDto()
        {
            Group = group,
            Subjects = new EntityWithCountDto<Subject>()
            {
                Data = subjects,
                TotalCount = subjects.Count
            },
        };
    }
}