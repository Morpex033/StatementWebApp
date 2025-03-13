using MediatR;

namespace StatementWebApp.Infrastructure.Query.Statement;

public class GetStatementsQuery : IRequest<List<Core.Entity.Statement>>
{
}