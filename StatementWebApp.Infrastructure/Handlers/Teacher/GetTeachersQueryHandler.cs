using MediatR;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Teacher;

namespace StatementWebApp.Infrastructure.Handlers.Teacher;

public class GetTeachersQueryHandler : IRequestHandler<GetTeachersQuery, List<Core.Entity.Teacher>>
{
    private readonly ITeacherRepository _teacherRepository;

    public GetTeachersQueryHandler(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public Task<List<Core.Entity.Teacher>> Handle(GetTeachersQuery request, CancellationToken cancellationToken)
    {
        return _teacherRepository.GetTeachersAsync(cancellationToken);
    }
}