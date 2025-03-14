using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Entity;

namespace StatementWebApp.Core.Interface;

public interface IDepartmentRepository
{
    Task<EntityWithCountDto<Department>> GetDepartmentsAsync(int pageSize, int pageNumber, CancellationToken cancellationToken);
    Task<Department> GetDepartmentByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<DepartmentDetailsDto> GetDepartmentDetailsAsync(Guid id, int pageSize, int pageNumber, CancellationToken cancellationToken);
}