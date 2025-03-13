using MediatR;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Statement;

namespace StatementWebApp.Infrastructure.Handlers.Statement;

public class GetStatementsQueryHandler : IRequestHandler<GetStatementsQuery, List<Core.Entity.Statement>>
{
    private readonly IStatementRepository _statementRepository;

    public GetStatementsQueryHandler(IStatementRepository statementRepository)
    {
        _statementRepository = statementRepository;
    }

    public Task<List<Core.Entity.Statement>> Handle(GetStatementsQuery request, CancellationToken cancellationToken)
    {
        return _statementRepository.GetAllStatementsAsync(cancellationToken);
    }
}