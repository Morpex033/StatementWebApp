using MediatR;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Command.Grade;

namespace StatementWebApp.Infrastructure.Handlers.Grade;

public class AddGradeCommandHandler : IRequestHandler<AddGradeCommand, Core.Entity.Grade>
{
    private readonly IGradeRepository _repository;

    public AddGradeCommandHandler(IGradeRepository repository)
    {
        _repository = repository;
    }
    
    public Task<Core.Entity.Grade> Handle(AddGradeCommand request, CancellationToken cancellationToken)
    {
        var grade = new CreateGradeDto()
        {
            Value = request.Value,
            TeacherId = request.TeacherId,
            StudentId = request.StudentId,
            SubjectId = request.SubjectId
        };
        
        return _repository.AddGradeAsync(grade, cancellationToken);
    }
}