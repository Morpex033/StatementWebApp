using MediatR;

namespace StatementWebApp.Infrastructure.Query.Statement;

public class GetStatementInExelByIdQuery : IRequest<byte[]>
{
    public Guid Id { get; set; }
}