using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Entity;

namespace StatementWebApp.Core.Interface;

public interface ISubjectRepository
{
    Task<List<Subject>> GetSubjectsAsync(CancellationToken cancellationToken);
    Task<Subject> GetSubjectByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<SubjectDetailsDto> GetSubjectDetailsAsync(Guid id, CancellationToken cancellationToken);
}