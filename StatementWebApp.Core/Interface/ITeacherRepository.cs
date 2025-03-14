using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Entity;

namespace StatementWebApp.Core.Interface;

public interface ITeacherRepository
{
    Task<EntityWithCountDto<Teacher>> GetTeachersAsync(int pageSize, int pageNumber, CancellationToken cancellationToken);
    Task<Teacher> GetTeacherByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<TeacherDetailsDto> GetTeacherDetailsAsync(Guid id, int pageSize, int pageNumber, CancellationToken cancellationToken);
}