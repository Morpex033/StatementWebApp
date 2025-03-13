using Microsoft.EntityFrameworkCore;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Entity;
using StatementWebApp.Core.Exception;
using StatementWebApp.Core.Interface;
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
        try
        {
            var institute =
                await _context.Institutes.Where(i => i.Id == instituteId).FirstOrDefaultAsync(cancellationToken) ??
                throw new BadRequestException("Institute not found");

            var grades = await _context.Grades.Where(g => g.Date.Year == DateTime.Now.Year)
                .ToListAsync(cancellationToken);

            var statementsCount = await _context.Statements.CountAsync(cancellationToken);

            var index = $"{institute.Name}-{DateTime.Now.Year}/{statementsCount + 1}";

            var statement = new Statement(index, grades);

            _context.Statements.Add(statement);

            await _context.SaveChangesAsync(cancellationToken);

            return statement;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            Console.WriteLine($"StackTrace: {ex.StackTrace}");
            throw; // Проброс ошибки для отладки
        }
    }

    public async Task<List<Statement>> GetAllStatementsAsync(CancellationToken cancellationToken)
    {
        return await _context.Statements.ToListAsync(cancellationToken);
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
        var statement = await _context.Statements.Where(s => s.Id == id).FirstOrDefaultAsync(cancellationToken) ??
                        throw new NotFoundException("Statement not found");

        statement.Grades = updateStatementDto.Grades;

        await _context.SaveChangesAsync(cancellationToken);

        return statement;
    }

    public async Task DeleteStatementByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var statement = await _context.Statements.Where(s => s.Id == id).FirstOrDefaultAsync(cancellationToken) ??
                        throw new NotFoundException("Statement not found");

        _context.Statements.Remove(statement);
    }

    public async Task<StatementDetailsDto> GetStatementDetailsAsync(Guid id, CancellationToken cancellationToken)
    {
        var statement = await GetStatementByIdAsync(id, cancellationToken);

        var grades = await _context.Grades.Where(g => g.StatementId == statement.Id).ToListAsync(cancellationToken) ??
                     throw new BadRequestException("Statement not found");

        return new StatementDetailsDto()
        {
            Grades = grades
        };
    }
}