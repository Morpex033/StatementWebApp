using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Entity;

namespace StatementWebApp.Core.Interface;

public interface IStudentRepository
{
    Task<EntityWithCountDto<Student>> GetStudentsAsync(int pageSize, int pageNumber, string name, CancellationToken cancellationToken);
    Task<Student> GetStudentByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<StudentDetailsDto> GetStudentDetailsAsync(Guid id, int pageSize, int pageNumber, CancellationToken cancellationToken);
}