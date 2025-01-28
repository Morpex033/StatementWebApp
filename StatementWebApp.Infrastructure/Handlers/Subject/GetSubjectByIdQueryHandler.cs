using MediatR;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Subject;

namespace StatementWebApp.Infrastructure.Handlers.Subject;

public class GetSubjectByIdQueryHandler : IRequestHandler<GetSubjectByIdQuery, Core.Entity.Subject>
{
    private readonly ISubjectRepository _subjectRepository;

    public GetSubjectByIdQueryHandler(ISubjectRepository subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }

    public Task<Core.Entity.Subject> Handle(GetSubjectByIdQuery request, CancellationToken cancellationToken)
    {
        return _subjectRepository.GetSubjectByIdAsync(request.Id, cancellationToken);
    }
}