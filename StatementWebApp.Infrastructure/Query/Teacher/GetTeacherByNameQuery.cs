using MediatR;

namespace StatementWebApp.Infrastructure.Query.Teacher;

public class GetTeacherByNameQuery : IRequest<List<Core.Entity.Teacher>>
{
    public string Name { get; set; }
}