using MediatR;
using StatementWebApp.Core.Dto;

namespace StatementWebApp.Infrastructure.Query.Teacher;

public class GetTeachersQuery : IRequest<EntityWithCountDto<Core.Entity.Teacher>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}