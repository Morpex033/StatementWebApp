using MediatR;

namespace StatementWebApp.Infrastructure.Query.Teacher;

public class GetTeachersQuery : IRequest<List<Core.Entity.Teacher>>
{
    
}