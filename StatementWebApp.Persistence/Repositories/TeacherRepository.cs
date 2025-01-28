using Microsoft.EntityFrameworkCore;
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
            await _context.Teachers.SingleOrDefaultAsync(s => s.Id == id, cancellationToken: cancellationToken) ??
            throw new NotFoundException("Teacher not found");

        return teacher;
    }
}