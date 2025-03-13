using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Entity;

namespace StatementWebApp.Core.Interface;

public interface IInstituteRepository
{
    Task<Institute> GetInstituteByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<List<Institute>> GetInstitutesAsync(CancellationToken cancellationToken);
    
    Task<InstituteDetailsDto> GetInstituteDetailsAsync(Guid id, CancellationToken cancellationToken);
}