using MediatR;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Subject;

namespace StatementWebApp.Infrastructure.Handlers.Subject;

public class GetSubjectsQueryHandler : IRequestHandler<GetSubjectsQuery, EntityWithCountDto<Core.Entity.Subject>>
{
    private readonly ISubjectRepository _subjectRepository;

    public GetSubjectsQueryHandler(ISubjectRepository subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }

    public Task<EntityWithCountDto<Core.Entity.Subject>> Handle(GetSubjectsQuery request, CancellationToken cancellationToken)
    {
        return _subjectRepository.GetSubjectsAsync(request.PageSize, request.PageNumber, request.Name, cancellationToken);
    }
}