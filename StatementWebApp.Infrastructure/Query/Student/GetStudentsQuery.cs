using MediatR;

namespace StatementWebApp.Infrastructure.Query.Student;

public class GetStudentsQuery : IRequest<List<Core.Entity.Student>>
{
    
}