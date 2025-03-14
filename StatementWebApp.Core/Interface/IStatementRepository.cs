using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Entity;

namespace StatementWebApp.Core.Interface;

public interface IStatementRepository
{
    Task<Statement> CreateStatementAsync(Guid instituteId, CancellationToken cancellationToken);

    Task<EntityWithCountDto<Statement>> GetAllStatementsAsync(int pageSize, int pageNumber, CancellationToken cancellationToken);

    Task<Statement> GetStatementByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<Statement> UpdateStatementByIdAsync(Guid id, UpdateStatementDto updateStatementDt, CancellationToken cancellationToken);

    Task DeleteStatementByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<StatementDetailsDto> GetStatementDetailsAsync(Guid id, int pageSize, int pageNumber, CancellationToken cancellationToken);
}