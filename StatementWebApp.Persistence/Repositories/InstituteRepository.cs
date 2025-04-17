using Microsoft.EntityFrameworkCore;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Entity;
using StatementWebApp.Core.Exception;
using StatementWebApp.Core.Interface;
using StatementWebApp.Persistence.Context;

namespace StatementWebApp.Persistence.Repositories;

public class InstituteRepository : IInstituteRepository
{
    private readonly CustomDbContext _context;

    public InstituteRepository(CustomDbContext context)
    {
        _context = context;
    }

    public async Task<Institute> GetInstituteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var institute = await _context.Institutes
                            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken) ??
                        throw new NotFoundException("Institute not found");
        return institute;
    }

    public async Task<EntityWithCountDto<Institute>> GetInstitutesAsync(int pageSize, int pageNumber, string name,
        CancellationToken cancellationToken)
    {
        var totalCount = await _context.Institutes.CountAsync(cancellationToken);

        var institutes = await _context.Institutes
            .Where(i => EF.Functions.ILike(i.Name, $"%{name}%"))
            .Skip((pageNumber - 1) * pageSize).Take(pageSize)
            .ToListAsync(cancellationToken);
        return new EntityWithCountDto<Institute>()
        {
            TotalCount = totalCount,
            Data = institutes,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }

    public async Task<InstituteDetailsDto> GetInstituteDetailsAsync(Guid id, int pageSize, int pageNumber,
        CancellationToken cancellationToken)
    {
        var departments =
            await _context.Departments
                .Where(d => d.InstituteId == id)
                .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .ToListAsync(cancellationToken) ??
            throw new NotFoundException("Department not found");

        return new InstituteDetailsDto()
        {
            Departments = new EntityWithCountDto<Department>()
            {
                Data = departments,
                TotalCount = departments.Count,
                PageNumber = pageNumber,
                PageSize = pageSize
            }
        };
    }
}