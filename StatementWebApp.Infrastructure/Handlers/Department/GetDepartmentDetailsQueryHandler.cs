using MediatR;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Department;

namespace StatementWebApp.Infrastructure.Handlers.Department;

public class GetDepartmentDetailsQueryHandler : IRequestHandler<GetDepartmentDetailsQuery, DepartmentDetailsDto>
{
    private readonly IDepartmentRepository _departmentRepository;

    public GetDepartmentDetailsQueryHandler(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public Task<DepartmentDetailsDto> Handle(GetDepartmentDetailsQuery request, CancellationToken cancellationToken)
    {
        return _departmentRepository.GetDepartmentDetailsAsync(request.Id, request.PageSize, request.PageNumber, cancellationToken);
    }
}