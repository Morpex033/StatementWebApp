using MediatR;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Command.Statement;

namespace StatementWebApp.Infrastructure.Handlers.Statement;

public class UpdateStatementCommandHandler : IRequestHandler<UpdateStatementCommand, Core.Entity.Statement>
{
    private readonly IStatementRepository _statementRepository;

    public UpdateStatementCommandHandler(IStatementRepository statementRepository)
    {
        _statementRepository = statementRepository;
    }

    public Task<Core.Entity.Statement> Handle(UpdateStatementCommand request, CancellationToken cancellationToken)
    {
        return _statementRepository.UpdateStatementByIdAsync(request.Id, request.Data, cancellationToken);
    }
}