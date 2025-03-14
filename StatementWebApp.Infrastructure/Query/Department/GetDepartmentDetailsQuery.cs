using MediatR;
using StatementWebApp.Core.Dto;

namespace StatementWebApp.Infrastructure.Query.Department;

public class GetDepartmentDetailsQuery : IRequest<DepartmentDetailsDto>
{
    public Guid Id { get; set; }
    
    public int PageSize { get; set; }
    
    public int PageNumber { get; set; }
}