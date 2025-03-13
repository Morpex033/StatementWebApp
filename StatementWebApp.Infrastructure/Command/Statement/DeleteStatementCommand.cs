using MediatR;

namespace StatementWebApp.Infrastructure.Command.Statement;

public class DeleteStatementCommand: IRequest<Unit>
{
    public Guid Id { get; set; }
}