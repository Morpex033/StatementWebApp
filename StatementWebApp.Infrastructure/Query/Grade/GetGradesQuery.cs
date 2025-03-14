using MediatR;
using StatementWebApp.Core.Dto;

namespace StatementWebApp.Infrastructure.Query.Grade;

public class GetGradesQuery : IRequest<EntityWithCountDto<Core.Entity.Grade>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}