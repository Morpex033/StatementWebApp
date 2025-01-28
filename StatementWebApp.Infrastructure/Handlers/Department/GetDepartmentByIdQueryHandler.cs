using MediatR;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Department;

namespace StatementWebApp.Infrastructure.Handlers.Department;

public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, Core.Entity.Department>
{
    private readonly IDepartmentRepository _departmentRepository;

    public GetDepartmentByIdQueryHandler(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }
    
    public Task<Core.Entity.Department> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
    {
        return _departmentRepository.GetDepartmentByIdAsync(request.Id, cancellationToken);
    }
}