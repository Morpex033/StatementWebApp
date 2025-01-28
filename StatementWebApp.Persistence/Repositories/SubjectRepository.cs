using Microsoft.EntityFrameworkCore;
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
            await _context.Subjects.SingleOrDefaultAsync(s => s.Id == id, cancellationToken: cancellationToken) ??
            throw new NotFoundException("Subject not found");

        return subject;
    }
}