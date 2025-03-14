using MediatR;
using StatementWebApp.Core.Dto;

namespace StatementWebApp.Infrastructure.Query.Statement;

public class GetStatementsQuery : IRequest<EntityWithCountDto<Core.Entity.Statement>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}