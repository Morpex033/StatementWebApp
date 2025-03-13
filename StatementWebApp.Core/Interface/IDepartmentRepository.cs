using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Entity;

namespace StatementWebApp.Core.Interface;

public interface IDepartmentRepository
{
    Task<List<Department>> GetDepartmentsAsync(CancellationToken cancellationToken);
    Task<Department> GetDepartmentByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<DepartmentDetailsDto> GetDepartmentDetailsAsync(Guid id, CancellationToken cancellationToken);
}