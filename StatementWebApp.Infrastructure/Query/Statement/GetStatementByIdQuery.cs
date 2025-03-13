using MediatR;

namespace StatementWebApp.Infrastructure.Query.Statement;

public class GetStatementByIdQuery : IRequest<Core.Entity.Statement>
{
    public Guid Id { get; set; }
}