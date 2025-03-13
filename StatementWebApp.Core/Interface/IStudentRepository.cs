using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Entity;

namespace StatementWebApp.Core.Interface;

public interface IStudentRepository
{
    Task<List<Student>> GetStudentsAsync(CancellationToken cancellationToken);
    Task<Student> GetStudentByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<StudentDetailsDto> GetStudentDetailsAsync(Guid id, CancellationToken cancellationToken);
}