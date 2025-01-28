using MediatR;

namespace StatementWebApp.Infrastructure.Query.Grade;

public class GetGradeByIdQuery : IRequest<Core.Entity.Grade>
{
    public Guid Id { get; set; }
}