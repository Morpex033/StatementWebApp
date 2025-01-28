using MediatR;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Subject;

namespace StatementWebApp.Infrastructure.Handlers.Subject;

public class GetSubjectsQueryHandler : IRequestHandler<GetSubjectsQuery, List<Core.Entity.Subject>>
{
    private readonly ISubjectRepository _subjectRepository;

    public GetSubjectsQueryHandler(ISubjectRepository subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }

    public Task<List<Core.Entity.Subject>> Handle(GetSubjectsQuery request, CancellationToken cancellationToken)
    {
        return _subjectRepository.GetSubjectsAsync(cancellationToken);
    }
}