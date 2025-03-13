using MediatR;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Teacher;

namespace StatementWebApp.Infrastructure.Handlers.Teacher;

public class GetTeacherDetailsQueryHandler : IRequestHandler<GetTeacherDetailsQuery, TeacherDetailsDto>
{
    private readonly ITeacherRepository _teacherRepository;

    public GetTeacherDetailsQueryHandler(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public Task<TeacherDetailsDto> Handle(GetTeacherDetailsQuery request, CancellationToken cancellationToken)
    {
        return _teacherRepository.GetTeacherDetailsAsync(request.Id, cancellationToken);
    }
}