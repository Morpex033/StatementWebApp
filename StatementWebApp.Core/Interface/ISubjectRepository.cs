using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Entity;

namespace StatementWebApp.Core.Interface;

public interface ISubjectRepository
{
    Task<EntityWithCountDto<Subject>> GetSubjectsAsync(int pageSize, int pageNumber, CancellationToken cancellationToken);
    Task<Subject> GetSubjectByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<SubjectDetailsDto> GetSubjectDetailsAsync(Guid id, int pageSize, int pageNumber, CancellationToken cancellationToken);
}