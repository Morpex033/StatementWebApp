using MediatR;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Statement;

namespace StatementWebApp.Infrastructure.Handlers.Statement;

public class GetStatementInExelByIdQueryHandler : IRequestHandler<GetStatementInExelByIdQuery, byte[]>
{
    private readonly IStatementRepository _statementRepository;

    public GetStatementInExelByIdQueryHandler(IStatementRepository statementRepository)
    {
        _statementRepository = statementRepository;
    }

    public Task<byte[]> Handle(GetStatementInExelByIdQuery request, CancellationToken cancellationToken)
    {
        return this._statementRepository.GetStatementInExel(request.Id, cancellationToken);
    }
}