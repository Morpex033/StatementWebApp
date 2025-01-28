using MediatR;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Grade;

namespace StatementWebApp.Infrastructure.Handlers.Grade;

public class GetGradesQueryHandler : IRequestHandler<GetGradesQuery, List<Core.Entity.Grade>>
{
    private readonly IGradeRepository _repository;

    public GetGradesQueryHandler(IGradeRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Core.Entity.Grade>> Handle(GetGradesQuery request, CancellationToken cancellationToken)
    {
        return _repository.GetGradesAsync(cancellationToken);
    }
}