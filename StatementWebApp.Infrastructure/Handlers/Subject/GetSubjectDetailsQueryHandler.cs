using MediatR;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Subject;

namespace StatementWebApp.Infrastructure.Handlers.Subject;

public class GetSubjectDetailsQueryHandler : IRequestHandler<GetSubjectDetailsQuery, SubjectDetailsDto>
{
    private readonly ISubjectRepository _subjectRepository;

    public GetSubjectDetailsQueryHandler(ISubjectRepository subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }

    public Task<SubjectDetailsDto> Handle(GetSubjectDetailsQuery request, CancellationToken cancellationToken)
    {
        return _subjectRepository.GetSubjectDetailsAsync(request.Id, request.PageSize, request.PageNumber, cancellationToken);
    }
}