using MediatR;

namespace StatementWebApp.Infrastructure.Query.Subject;

public class GetSubjectByIdQuery :IRequest<Core.Entity.Subject>
{
    public Guid Id { get; set; }
}