using MediatR;

namespace StatementWebApp.Infrastructure.Query.Teacher;

public class GetTeacherByIdQuery :IRequest<Core.Entity.Teacher>
{
    public Guid Id { get; set; }
}