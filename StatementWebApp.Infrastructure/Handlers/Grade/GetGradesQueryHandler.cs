using MediatR;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Grade;

namespace StatementWebApp.Infrastructure.Handlers.Grade;

public class GetGradesQueryHandler : IRequestHandler<GetGradesQuery, EntityWithCountDto<Core.Entity.Grade>>
{
    private readonly IGradeRepository _repository;

    public GetGradesQueryHandler(IGradeRepository repository)
    {
        _repository = repository;
    }

    public Task<EntityWithCountDto<Core.Entity.Grade>> Handle(GetGradesQuery request, CancellationToken cancellationToken)
    {
        return _repository.GetGradesAsync(request.PageSize, request.PageNumber, cancellationToken);
    }
}