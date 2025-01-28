using MediatR;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Command.Grade;

namespace StatementWebApp.Infrastructure.Handlers.Grade;

public class DeleteGradeCommandHandler : IRequestHandler<DeleteGradeCommand, Unit>
{
    private readonly IGradeRepository _repository;

    public DeleteGradeCommandHandler(IGradeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteGradeCommand request, CancellationToken cancellationToken)
    { 
        _repository.DeleteGradeAsync(request.Id, cancellationToken);

        return Unit.Value;
    }
}