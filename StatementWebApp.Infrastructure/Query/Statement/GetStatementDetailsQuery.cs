using MediatR;
using StatementWebApp.Core.Dto;

namespace StatementWebApp.Infrastructure.Query.Statement;

public class GetStatementDetailsQuery : IRequest<StatementDetailsDto>
{
    public Guid Id { get; set; }
    
    public int PageSize { get; set; }
    
    public int PageNumber { get; set; }
}