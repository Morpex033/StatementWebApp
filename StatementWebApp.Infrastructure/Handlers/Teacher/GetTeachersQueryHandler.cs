using MediatR;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Teacher;

namespace StatementWebApp.Infrastructure.Handlers.Teacher;

public class GetTeachersQueryHandler : IRequestHandler<GetTeachersQuery, EntityWithCountDto<Core.Entity.Teacher>>
{
    private readonly ITeacherRepository _teacherRepository;

    public GetTeachersQueryHandler(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public Task<EntityWithCountDto<Core.Entity.Teacher>> Handle(GetTeachersQuery request, CancellationToken cancellationToken)
    {
        return _teacherRepository.GetTeachersAsync(request.PageSize, request.PageNumber, cancellationToken);
    }
}