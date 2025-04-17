using MediatR;

namespace StatementWebApp.Infrastructure.Query.Subject;

public class GetSubjectsByNameQuery : IRequest<List<Core.Entity.Subject>>
{
    public string Name { get; set; }
}