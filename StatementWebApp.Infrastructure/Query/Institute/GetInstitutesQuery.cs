using MediatR;
using StatementWebApp.Core.Dto;

namespace StatementWebApp.Infrastructure.Query.Institute;

public class GetInstitutesQuery : IRequest<EntityWithCountDto<Core.Entity.Institute>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}