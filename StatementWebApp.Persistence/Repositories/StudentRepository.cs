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


    public async Task<List<Student>> GetStudentsAsync(CancellationToken cancellationToken)
    {
        return await _context.Students.ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<Student> GetStudentByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var student =
            await _context.Students
                .SingleOrDefaultAsync(s => s.Id == id, cancellationToken: cancellationToken) ??
            throw new NotFoundException("Student not found");

        return student;
    }

    public async Task<StudentDetailsDto> GetStudentDetailsAsync(Guid id, CancellationToken cancellationToken)
    {
        var student = await GetStudentByIdAsync(id, cancellationToken);

        var group = await _context.Groups.SingleOrDefaultAsync(g => g.Students.Contains(student), cancellationToken) ??
                    throw new NotFoundException("Group not found");

        var subjects = await _context.Subjects.Where(s => s.Students.Contains(student))
            .ToListAsync(cancellationToken: cancellationToken);

        var grades = await _context.Grades.Where(g => g.StudentId == student.Id)
            .ToListAsync(cancellationToken: cancellationToken);

        return new StudentDetailsDto()
        {
            Group = group,
            Subjects = subjects,
            Grades = grades,
        };
    }
}