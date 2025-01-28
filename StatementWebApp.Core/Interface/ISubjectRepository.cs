using StatementWebApp.Core.Entity;

namespace StatementWebApp.Core.Interface;

public interface ISubjectRepository
{
    Task<List<Subject>> GetSubjectsAsync(CancellationToken cancellationToken);
    Task<Subject> GetSubjectByIdAsync(Guid id, CancellationToken cancellationToken);
}