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

    public async Task<EntityWithCountDto<Department>> GetDepartmentsAsync(int pageSize, int pageNumber,
        CancellationToken cancellationToken)
    {
        var totalCount = await _context.Departments.CountAsync(cancellationToken);

        var departments = await _context.Departments.Skip((pageNumber - 1) * pageSize).Take(pageSize)
            .ToListAsync(cancellationToken);
        return new EntityWithCountDto<Department>()
        {
            TotalCount = totalCount,
            Data = departments,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }

    public async Task<Department> GetDepartmentByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var department =
            await _context.Departments
                .SingleOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken) ??
            throw new NotFoundException("Department not found");

        return department;
    }

    public async Task<DepartmentDetailsDto> GetDepartmentDetailsAsync(Guid id, int pageSize, int pageNumber,
        CancellationToken cancellationToken)
    {
        var institute =
            await _context.Institutes
                .SingleOrDefaultAsync(x => x.Departments.Any(d => d.Id == id), cancellationToken) ??
            throw new NotFoundException("Institute not found");

        var groups =
            await _context.Groups
                .Where(g => g.DepartmentId == id)
                .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .ToListAsync(cancellationToken) ??
            throw new NotFoundException("Group not found");

        var teachers =
            await _context.Teachers
                .Where(t => t.Departments.Any(d => d.Id == id))
                .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .ToListAsync(cancellationToken) ??
            throw new NotFoundException("Teacher not found");

        return new DepartmentDetailsDto()
        {
            Institute = institute,
            Groups = new EntityWithCountDto<Group>()
            {
                Data = groups,
                TotalCount = groups.Count,
                PageNumber = pageNumber,
                PageSize = pageSize
            },
            Teachers = new EntityWithCountDto<Teacher>()
            {
                Data = teachers,
                TotalCount = teachers.Count,
                PageNumber = pageNumber,
                PageSize = pageSize
            }
        };
    }
}