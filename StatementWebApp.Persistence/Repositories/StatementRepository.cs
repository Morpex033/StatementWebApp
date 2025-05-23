using Microsoft.EntityFrameworkCore;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Entity;
using StatementWebApp.Core.Exception;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Utilities;
using StatementWebApp.Persistence.Context;

namespace StatementWebApp.Persistence.Repositories;

public class StatementRepository : IStatementRepository
{
    private readonly CustomDbContext _context;

    public StatementRepository(CustomDbContext context)
    {
        _context = context;
    }

    public async Task<Statement> CreateStatementAsync(Guid instituteId, CancellationToken cancellationToken)
    {
        var institute =
            await _context.Institutes
                .Where(i => i.Id == instituteId)
                .FirstOrDefaultAsync(cancellationToken) ??
            throw new BadRequestException("Institute not found");

        var grades = await _context.Grades.Where(g =>
                g.Date.Year == DateTime.Now.Year &&
                g.Teacher.Departments.Any(d => d.InstituteId == institute.Id))
            .ToListAsync(cancellationToken);

        if (grades.Count == 0) throw new BadRequestException("Grades not found");

        var statements = await _context.Statements
            .Where(s => s.Index != null)
            .ToListAsync(cancellationToken);

        var statementsCount = statements
            .Count(s => s.Index.Split('-')
                            .Any(part => part.Equals(institute.Name, StringComparison.OrdinalIgnoreCase)) &&
                        s.Index.Split('-', '/').Any(part => part == DateTime.Now.Year.ToString()));


        var index = $"{institute.Name}-{DateTime.Now.Year}/{statementsCount + 1}";

        var statement = new Statement(index, grades);

        _context.Statements.Add(statement);

        await _context.SaveChangesAsync(cancellationToken);

        return statement;
    }

    public async Task<EntityWithCountDto<Statement>> GetAllStatementsAsync(int pageSize, int pageNumber,
        CancellationToken cancellationToken)
    {
        var totalCount = await _context.Statements.CountAsync(cancellationToken);

        var statements = await _context.Statements.Skip((pageNumber - 1) * pageSize).Take(pageSize)
            .ToListAsync(cancellationToken);

        return new EntityWithCountDto<Statement>()
        {
            TotalCount = totalCount,
            Data = statements,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }

    public async Task<Statement> GetStatementByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var statement = await _context.Statements.Where(s => s.Id == id)
                            .FirstOrDefaultAsync(cancellationToken) ??
                        throw new NotFoundException("Statement not found");

        return statement;
    }

    public async Task<Statement> UpdateStatementByIdAsync(Guid id, UpdateStatementDto updateStatementDto,
        CancellationToken cancellationToken)
    {
        var statement = await _context.Statements
                            .Include(s => s.Grades)
                            .Where(s => s.Id == id)
                            .FirstOrDefaultAsync(cancellationToken) ??
                        throw new NotFoundException("Statement not found");

        foreach (var oldGrade in statement.Grades)
        {
            var grade = updateStatementDto.Grades.FirstOrDefault(g => g.Id == oldGrade.Id);
            if (grade == null) continue;

            oldGrade.Value = grade.Value;
        }

        await _context.SaveChangesAsync(cancellationToken);

        return statement;
    }

    public async Task DeleteStatementByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var statement = await _context.Statements
                            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken) ??
                        throw new NotFoundException("Statement not found");

        var grades = await _context.Grades
            .Where(g => g.StatementId == id)
            .ToListAsync(cancellationToken);

        foreach (var grade in grades)
        {
            grade.StatementId = null;
        }


        _context.Statements.Remove(statement);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<StatementDetailsDto> GetStatementDetailsAsync(Guid id, int pageSize, int pageNumber,
        CancellationToken cancellationToken)
    {
        var grades = await _context.Grades
                         .Where(g => g.StatementId == id)
                         .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                         .ToListAsync(cancellationToken) ??
                     throw new BadRequestException("Statement not found");

        return new StatementDetailsDto()
        {
            Grades = new EntityWithCountDto<Grade>()
            {
                Data = grades,
                TotalCount = grades.Count,
                PageNumber = pageNumber,
                PageSize = pageSize
            }
        };
    }

    public async Task<byte[]> GetStatementInExel(Guid id, CancellationToken cancellationToken)
    {
        var statement = await _context.Statements
                            .Where(s => s.Id == id)
                            .Include(s => s.Grades) // Включаем оценки
                            .ThenInclude(g => g.Student) // Включаем студентов
                            .ThenInclude(s => s.Group) // Включаем группы студентов
                            .Include(s => s.Grades) // Включаем оценки
                            .ThenInclude(g => g.Subject)
                            .FirstOrDefaultAsync(cancellationToken) ??
                        throw new NotFoundException("Statement not found");

        var bytes = ExсelGenerator.GenerateExcel(statement);

        return bytes;
    }
}