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

    public async Task<List<Subject>> GetSubjectsAsync(CancellationToken cancellationToken)
    {
        return await _context.Subjects.ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<Subject> GetSubjectByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var subject =
            await _context.Subjects
                .SingleOrDefaultAsync(s => s.Id == id, cancellationToken: cancellationToken) ??
            throw new NotFoundException("Subject not found");

        return subject;
    }

    public async Task<SubjectDetailsDto> GetSubjectDetailsAsync(Guid id, CancellationToken cancellationToken)
    {
        var subject = await GetSubjectByIdAsync(id, cancellationToken);

        var teachers =
            await _context.Teachers.Where(t => t.Subjects.Contains(subject))
                .ToListAsync(cancellationToken: cancellationToken) ?? throw new NotFoundException("Teacher not found");

        var students =
            await _context.Students.Where(s => s.Subjects.Contains(subject))
                .ToListAsync(cancellationToken: cancellationToken) ?? throw new NotFoundException("Student not found");

        var grades =
            await _context.Grades.Where(g => g.SubjectId == subject.Id)
                .ToListAsync(cancellationToken: cancellationToken) ?? throw new NotFoundException("Grade not found");

        return new SubjectDetailsDto()
        {
            Teachers = teachers,
            Grades = grades,
            Students = students
        };
    }
}