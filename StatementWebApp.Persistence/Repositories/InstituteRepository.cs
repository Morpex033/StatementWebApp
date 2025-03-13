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

    public async Task<List<Institute>> GetInstitutesAsync(CancellationToken cancellationToken)
    {
        return await _context.Institutes.ToListAsync(cancellationToken);
    }

    public async Task<InstituteDetailsDto> GetInstituteDetailsAsync(Guid id, CancellationToken cancellationToken)
    {
        var institute = await GetInstituteByIdAsync(id, cancellationToken);

        var departments =
            await _context.Departments.Where(d => d.InstituteId == institute.Id).ToListAsync(cancellationToken) ??
            throw new NotFoundException("Department not found");

        return new InstituteDetailsDto()
        {
            Departments = departments
        };
    }
}