using MediatR;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Department;

namespace StatementWebApp.Infrastructure.Handlers.Department;

public class GetDepartmentsQueryHandler : IRequestHandler<GetDepartmentsQuery, List<Core.Entity.Department>>
{
    private readonly IDepartmentRepository _departmentRepository;

    public GetDepartmentsQueryHandler(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }
    
    public Task<List<Core.Entity.Department>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
    {
        return _departmentRepository.GetDepartmentsAsync(cancellationToken);
    }
}