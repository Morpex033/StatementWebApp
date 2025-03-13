using MediatR;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Grade;

namespace StatementWebApp.Infrastructure.Handlers.Grade;

public class GetGradeDetailsQueryHandler : IRequestHandler<GetGradeDetailsQuery, GradeDetailsDto>
{
    private readonly IGradeRepository _gradeRepository;

    public GetGradeDetailsQueryHandler(IGradeRepository gradeRepository)
    {
        _gradeRepository = gradeRepository;
    }

    public Task<GradeDetailsDto> Handle(GetGradeDetailsQuery request, CancellationToken cancellationToken)
    {
        return _gradeRepository.GetGradeDetailsAsync(request.Id, cancellationToken);
    }
}