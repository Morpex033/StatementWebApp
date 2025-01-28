using MediatR;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Student;

namespace StatementWebApp.Infrastructure.Handlers.Student;

public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Core.Entity.Student>
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentByIdQueryHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public Task<Core.Entity.Student> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        return _studentRepository.GetStudentByIdAsync(request.Id, cancellationToken);
    }
}