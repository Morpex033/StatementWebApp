using MediatR;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Teacher;

namespace StatementWebApp.Infrastructure.Handlers.Teacher;

public class GetTeacherByIdQueryHandler : IRequestHandler<GetTeacherByIdQuery, Core.Entity.Teacher>
{
    private readonly ITeacherRepository _teacherRepository;

    public GetTeacherByIdQueryHandler(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public Task<Core.Entity.Teacher> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
    {
        return _teacherRepository.GetTeacherByIdAsync(request.Id, cancellationToken);
    }
}