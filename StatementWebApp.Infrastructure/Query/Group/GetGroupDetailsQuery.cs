using MediatR;
using StatementWebApp.Core.Dto;

namespace StatementWebApp.Infrastructure.Query.Group;

public class GetGroupDetailsQuery :IRequest<GroupDetailsDto>
{
    public Guid Id { get; set; }
}