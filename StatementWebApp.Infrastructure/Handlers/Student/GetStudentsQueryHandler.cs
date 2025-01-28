using MediatR;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Student;

namespace StatementWebApp.Infrastructure.Handlers.Student;

public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, List<Core.Entity.Student>>
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentsQueryHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public Task<List<Core.Entity.Student>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        return _studentRepository.GetStudentsAsync(cancellationToken);
    }
}