using MediatR;

namespace StatementWebApp.Infrastructure.Command.Grade;

public class DeleteGradeCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}