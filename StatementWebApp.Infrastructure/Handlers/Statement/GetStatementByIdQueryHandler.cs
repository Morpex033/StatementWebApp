using MediatR;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Statement;

namespace StatementWebApp.Infrastructure.Handlers.Statement;

public class GetStatementByIdQueryHandler : IRequestHandler<GetStatementByIdQuery, Core.Entity.Statement>
{
    private readonly IStatementRepository _statementRepository;

    public GetStatementByIdQueryHandler(IStatementRepository statementRepository)
    {
        _statementRepository = statementRepository;
    }

    public Task<Core.Entity.Statement> Handle(GetStatementByIdQuery request, CancellationToken cancellationToken)
    {
        return _statementRepository.GetStatementByIdAsync(request.Id, cancellationToken);
    }
}