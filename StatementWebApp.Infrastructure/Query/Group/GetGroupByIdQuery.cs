using MediatR;

namespace StatementWebApp.Infrastructure.Query.Group;

public class GetGroupByIdQuery : IRequest<Core.Entity.Group>
{
    public Guid Id { get; set; }
}