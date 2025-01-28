using MediatR;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Grade;

namespace StatementWebApp.Infrastructure.Handlers.Grade;

public class GetGradeByIdQueryHandler : IRequestHandler<GetGradeByIdQuery, Core.Entity.Grade>
{
    private readonly IGradeRepository _repository;

    public GetGradeByIdQueryHandler(IGradeRepository repository)
    {
        _repository = repository;
    }


    public Task<Core.Entity.Grade> Handle(GetGradeByIdQuery request, CancellationToken cancellationToken)
    {
        return _repository.GetGradeByIdAsync(request.Id, cancellationToken);
    }
}