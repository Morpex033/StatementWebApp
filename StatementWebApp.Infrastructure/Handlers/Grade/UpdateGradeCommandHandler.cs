using MediatR;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Command.Grade;

namespace StatementWebApp.Infrastructure.Handlers.Grade;

public class UpdateGradeCommandHandler : IRequestHandler<UpdateGradeCommand, Core.Entity.Grade>
{
    private readonly IGradeRepository _repository;

    public UpdateGradeCommandHandler(IGradeRepository repository)
    {
        _repository = repository;
    }

    public Task<Core.Entity.Grade> Handle(UpdateGradeCommand request, CancellationToken cancellationToken)
    {
        var grade = new UpdateGradeDto()
        {
            Id = request.Id,
            Value = request.Value,
            StudentId = request.StudentId,
            SubjectId = request.SubjectId,
            TeacherId = request.TeacherId
        };
        
        return _repository.UpdateGradeAsync(grade, cancellationToken);
    }
}