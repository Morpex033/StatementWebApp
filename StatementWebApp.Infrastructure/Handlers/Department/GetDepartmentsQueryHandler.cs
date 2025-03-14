using MediatR;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Department;

namespace StatementWebApp.Infrastructure.Handlers.Department;

public class GetDepartmentsQueryHandler : IRequestHandler<GetDepartmentsQuery, EntityWithCountDto<Core.Entity.Department>>
{
    private readonly IDepartmentRepository _departmentRepository;

    public GetDepartmentsQueryHandler(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public Task<EntityWithCountDto<Core.Entity.Department>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
    {
        return _departmentRepository.GetDepartmentsAsync(request.PageSize, request.PageNumber, cancellationToken);
    }
}