using MediatR;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Command.Statement;

namespace StatementWebApp.Infrastructure.Handlers.Statement;

public class CreateStatementCommandHandler : IRequestHandler<CreateStatementCommand, Core.Entity.Statement>
{
    private readonly IStatementRepository _statementRepository;

    public CreateStatementCommandHandler(IStatementRepository statementRepository)
    {
        _statementRepository = statementRepository;
    }

    public Task<Core.Entity.Statement> Handle(CreateStatementCommand request, CancellationToken cancellationToken)
    {
        return _statementRepository.CreateStatementAsync(request.InstituteId, cancellationToken);
    }
}