using StatementWebApp.Core.Entity;

namespace StatementWebApp.Core.Interface;

public interface ITeacherRepository
{
    Task<List<Teacher>> GetTeachersAsync(CancellationToken cancellationToken);
    Task<Teacher> GetTeacherByIdAsync(Guid id, CancellationToken cancellationToken);
}