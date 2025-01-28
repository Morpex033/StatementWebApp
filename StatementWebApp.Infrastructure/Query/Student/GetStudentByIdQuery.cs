using MediatR;

namespace StatementWebApp.Infrastructure.Query.Student;

public class GetStudentByIdQuery :IRequest<Core.Entity.Student>
{
    public Guid Id { get; set; }
}