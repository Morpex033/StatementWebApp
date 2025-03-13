using Microsoft.EntityFrameworkCore;
using StatementWebApp.Core.Dto;
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
            await _context.Departments
                .SingleOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken) ??
            throw new NotFoundException("Department not found");

        return department;
    }

    public async Task<DepartmentDetailsDto> GetDepartmentDetailsAsync(Guid id, CancellationToken cancellationToken)
    {
        var department = await GetDepartmentByIdAsync(id, cancellationToken);

        var institute =
            await _context.Institutes.SingleOrDefaultAsync(x => x.Departments.Contains(department),
                cancellationToken) ?? throw new NotFoundException("Institute not found");

        var groups =
            await _context.Groups.Where(g => g.Department == department).ToListAsync(cancellationToken) ??
            throw new NotFoundException("Group not found");

        var teachers =
            await _context.Teachers.Where(t => t.Departments.Contains(department)).ToListAsync(cancellationToken) ??
            throw new NotFoundException("Teacher not found");

        return new DepartmentDetailsDto()
        {
            Institute = institute,
            Groups = groups,
            Teachers = teachers
        };
    }
}