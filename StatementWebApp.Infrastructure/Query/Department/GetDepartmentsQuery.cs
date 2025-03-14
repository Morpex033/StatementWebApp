using MediatR;
using StatementWebApp.Core.Dto;

namespace StatementWebApp.Infrastructure.Query.Department;

public class GetDepartmentsQuery : IRequest<EntityWithCountDto<Core.Entity.Department>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}