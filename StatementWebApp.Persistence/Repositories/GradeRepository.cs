using Microsoft.EntityFrameworkCore;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Entity;
using StatementWebApp.Core.Exception;
using StatementWebApp.Core.Interface;
using StatementWebApp.Persistence.Context;

namespace StatementWebApp.Persistence.Repositories;

public class GradeRepository : IGradeRepository
{
    private readonly CustomDbContext _context;

    public GradeRepository(CustomDbContext context)
    {
        _context = context;
    }

    public async Task<EntityWithCountDto<Grade>> GetGradesAsync(int pageSize, int pageNumber,
        CancellationToken cancellationToken)
    {
        var totalCount = await _context.Grades.CountAsync(cancellationToken);

        var grades = await _context.Grades.Skip((pageNumber - 1) * pageSize).Take(pageSize)
            .ToListAsync(cancellationToken: cancellationToken);
        return new EntityWithCountDto<Grade>()
        {
            TotalCount = totalCount,
            Data = grades,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }

    public async Task<Grade> GetGradeByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var grade = await _context.Grades
                        .SingleOrDefaultAsync(g => g.Id == id, cancellationToken: cancellationToken) ??
                    throw new NotFoundException("Grade not found");

        return grade;
    }

    public async Task<Grade> AddGradeAsync(CreateGradeDto grade, CancellationToken cancellationToken)
    {
        var teacher =
            await _context.Teachers.SingleOrDefaultAsync(teacher => teacher.Id == grade.TeacherId,
                cancellationToken: cancellationToken) ?? throw new NotFoundException("Teacher not found");

        var student =
            await _context.Students.SingleOrDefaultAsync(student => student.Id == grade.StudentId,
                cancellationToken: cancellationToken) ?? throw new NotFoundException("Student not found");

        var subject =
            await _context.Subjects.SingleOrDefaultAsync(subject => subject.Id == grade.SubjectId,
                cancellationToken: cancellationToken) ?? throw new NotFoundException("Subject not found");

        var newGrade = new Grade(grade, teacher, student, subject);

        _context.Grades.Add(newGrade);

        await _context.SaveChangesAsync(cancellationToken);

        return newGrade;
    }

    public async Task<Grade> UpdateGradeAsync(UpdateGradeDto grade, CancellationToken cancellationToken)
    {
        var existingGrade =
            await _context.Grades.SingleOrDefaultAsync(g => g.Id == grade.Id, cancellationToken: cancellationToken) ??
            throw new NotFoundException("Grade not found");

        var teacher =
            await _context.Teachers.SingleOrDefaultAsync(teacher => teacher.Id == grade.TeacherId,
                cancellationToken: cancellationToken) ?? throw new NotFoundException("Teacher not found");

        var student =
            await _context.Students.SingleOrDefaultAsync(student => student.Id == grade.StudentId,
                cancellationToken: cancellationToken) ?? throw new NotFoundException("Student not found");

        var subject =
            await _context.Subjects.SingleOrDefaultAsync(subject => subject.Id == grade.SubjectId,
                cancellationToken: cancellationToken) ?? throw new NotFoundException("Subject not found");

        var updatedGrade = new Grade(grade, teacher, student, subject);

        _context.Entry(existingGrade).CurrentValues.SetValues(grade);

        await _context.SaveChangesAsync(cancellationToken);

        return existingGrade;
    }

    public async Task DeleteGradeAsync(Guid id, CancellationToken cancellationToken)
    {
        var grade = await _context.Grades.SingleOrDefaultAsync(g => g.Id == id, cancellationToken);
        if (grade == null)
        {
            throw new NotFoundException("Grade not found");
        }

        _context.Grades.Remove(grade);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<GradeDetailsDto> GetGradeDetailsAsync(Guid id, int pageSize, int pageNumber,
        CancellationToken cancellationToken)
    {
        var gradeDetails = await _context.Grades
            .Where(g => g.Id == id)
            .Select(g => new GradeDetailsDto
            {
                Student = g.Student,
                Teacher = g.Teacher,
                Subject = g.Subject,
                Statement = g.Statement
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (gradeDetails == null)
        {
            throw new NotFoundException("Grade not found");
        }

        return gradeDetails;
    }
}