using Microsoft.EntityFrameworkCore;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Entity;
using StatementWebApp.Core.Exception;
using StatementWebApp.Core.Interface;
using StatementWebApp.Persistence.Context;

namespace StatementWebApp.Persistence.Repositories;

public class SubjectRepository : ISubjectRepository
{
    private readonly CustomDbContext _context;

    public SubjectRepository(CustomDbContext context)
    {
        _context = context;
    }

    public async Task<EntityWithCountDto<Subject>> GetSubjectsAsync(int pageSize, int pageNumber, CancellationToken cancellationToken)
    {
        var totalCount = await _context.Subjects.CountAsync(cancellationToken);
        
        var subjects = await _context.Subjects.Skip((pageNumber - 1) * pageSize).Take(pageSize)
            .ToListAsync(cancellationToken: cancellationToken);
        
        return new EntityWithCountDto<Subject>()
        {
            TotalCount = totalCount,
            Data = subjects
        }; 
    }

    public async Task<Subject> GetSubjectByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var subject =
            await _context.Subjects
                .SingleOrDefaultAsync(s => s.Id == id, cancellationToken: cancellationToken) ??
            throw new NotFoundException("Subject not found");

        return subject;
    }

    public async Task<SubjectDetailsDto> GetSubjectDetailsAsync(Guid id, int pageSize, int pageNumber, CancellationToken cancellationToken)
    {
        var teachers =
            await _context.Teachers
                .Where(t => t.Subjects.Any(s => s.Id == id))
                .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .ToListAsync(cancellationToken: cancellationToken) ?? throw new NotFoundException("Teacher not found");

        var students =
            await _context.Students
                .Where(s => s.Subjects.Any(subject => subject.Id == id))
                .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .ToListAsync(cancellationToken: cancellationToken) ?? throw new NotFoundException("Student not found");

        var grades =
            await _context.Grades
                .Where(g => g.SubjectId == id)
                .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .ToListAsync(cancellationToken: cancellationToken) ?? throw new NotFoundException("Grade not found");

        return new SubjectDetailsDto()
        {
            Teachers = new EntityWithCountDto<Teacher>()
            {
                Data = teachers,
                TotalCount = teachers.Count
            },
            Grades = new EntityWithCountDto<Grade>()
            {
                Data = grades,
                TotalCount = grades.Count
            },
            Students = new EntityWithCountDto<Student>()
            {
                Data = students,
                TotalCount = students.Count
            }
        };
    }
}