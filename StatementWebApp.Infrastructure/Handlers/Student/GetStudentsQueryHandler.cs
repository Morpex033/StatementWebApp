using MediatR;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Student;

namespace StatementWebApp.Infrastructure.Handlers.Student;

public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, EntityWithCountDto<Core.Entity.Student>>
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentsQueryHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public Task<EntityWithCountDto<Core.Entity.Student>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        return _studentRepository.GetStudentsAsync(request.PageSize, request.PageNumber, cancellationToken);
    }
}