using MediatR;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Institute;
using StatementWebApp.Infrastructure.Query.Statement;

namespace StatementWebApp.Infrastructure.Handlers.Statement;

public class GetStatementDetailsQueryHandler : IRequestHandler<GetStatementDetailsQuery, StatementDetailsDto>
{
    private readonly IStatementRepository _statementRepository;

    public GetStatementDetailsQueryHandler(IStatementRepository statementRepository)
    {
        _statementRepository = statementRepository;
    }

    public Task<StatementDetailsDto> Handle(GetStatementDetailsQuery request, CancellationToken cancellationToken)
    {
        return _statementRepository.GetStatementDetailsAsync(request.Id, cancellationToken);
    }
}