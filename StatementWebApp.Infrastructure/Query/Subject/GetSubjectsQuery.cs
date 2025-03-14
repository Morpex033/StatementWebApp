using MediatR;
using StatementWebApp.Core.Dto;

namespace StatementWebApp.Infrastructure.Query.Subject;

public class GetSubjectsQuery : IRequest<EntityWithCountDto<Core.Entity.Subject>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}