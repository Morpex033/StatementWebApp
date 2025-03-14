using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Entity;

namespace StatementWebApp.Core.Interface;

public interface IInstituteRepository
{
    Task<Institute> GetInstituteByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<EntityWithCountDto<Institute>> GetInstitutesAsync(int pageSize, int pageNumber, CancellationToken cancellationToken);
    
    Task<InstituteDetailsDto> GetInstituteDetailsAsync(Guid id, int pageSize, int pageNumber, CancellationToken cancellationToken);
}