using MediatR;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Student;

namespace StatementWebApp.Infrastructure.Handlers.Student;

public class GetStudentsDetailsQueryHandler : IRequestHandler<GetStudentDetailsQuery, StudentDetailsDto>
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentsDetailsQueryHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public Task<StudentDetailsDto> Handle(GetStudentDetailsQuery request, CancellationToken cancellationToken)
    {
        return _studentRepository.GetStudentDetailsAsync(request.Id, request.PageSize, request.PageNumber, cancellationToken);
    }
}