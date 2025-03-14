using MediatR;
using StatementWebApp.Core.Dto;

namespace StatementWebApp.Infrastructure.Query.Group;

public class GetGroupsQuery : IRequest<EntityWithCountDto<Core.Entity.Group>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}