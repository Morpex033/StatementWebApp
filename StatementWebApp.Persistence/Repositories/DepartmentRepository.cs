using Microsoft.EntityFrameworkCore;
using StatementWebApp.Core.Entity;
using StatementWebApp.Core.Exception;
using StatementWebApp.Core.Interface;
using StatementWebApp.Persistence.Context;

namespace StatementWebApp.Persistence.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly CustomDbContext _context;

    public DepartmentRepository(CustomDbContext context)
    {
        _context = context;
    }

    public async Task<List<Department>> GetDepartmentsAsync(CancellationToken cancellationToken)
    {
        return await _context.Departments.ToListAsync(cancellationToken);
        
    }

    public async Task<Department> GetDepartmentByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var department =
            await _context.Departments.SingleOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken) ??
            throw new NotFoundException("Department not found");

        return department;
    }
}