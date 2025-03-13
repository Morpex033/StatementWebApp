using MediatR;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Command.Statement;

namespace StatementWebApp.Infrastructure.Handlers.Statement;

public class DeleteStatementCommandHandler : IRequestHandler<DeleteStatementCommand, Unit>
{
    private readonly IStatementRepository _statementRepository;

    public DeleteStatementCommandHandler(IStatementRepository statementRepository)
    {
        _statementRepository = statementRepository;
    }

    public async Task<Unit> Handle(DeleteStatementCommand request, CancellationToken cancellationToken)
    {
        await _statementRepository.DeleteStatementByIdAsync(request.Id, cancellationToken);

        return Unit.Value;
    }
}