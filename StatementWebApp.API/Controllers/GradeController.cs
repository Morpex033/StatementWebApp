using MediatR;
using Microsoft.AspNetCore.Mvc;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Entity;
using StatementWebApp.Infrastructure.Command.Grade;
using StatementWebApp.Infrastructure.Query.Grade;
using Swashbuckle.AspNetCore.Annotations;

namespace StatementWebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class GradeController : ControllerBase
{
    private readonly IMediator _mediator;

    public GradeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [SwaggerResponse(200, "Success", typeof(List<Grade>))]
    public async Task<IActionResult> GetGrades(CancellationToken cancellationToken)
    {
        var query = new GetGradesQuery();

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    [SwaggerResponse(200, "Success", typeof(Grade))]
    public async Task<IActionResult> GetGrade(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetGradeByIdQuery()
        {
            Id = id
        };

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }

    [HttpPost]
    [SwaggerResponse(200, "Success", typeof(Grade))]
    public async Task<IActionResult> AddGrade(CreateGradeDto grade, CancellationToken cancellationToken)
    {
        var query = new AddGradeCommand()
        {
            StudentId = grade.StudentId,
            SubjectId = grade.SubjectId,
            TeacherId = grade.TeacherId,
            Value = grade.Value
        };

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    [SwaggerResponse(200, "Success", typeof(Grade))]
    public async Task<IActionResult> UpdateGrade(UpdateGradeDto grade, CancellationToken cancellationToken)
    {
        var query = new UpdateGradeCommand()
        {
            Id = grade.Id,
            StudentId = grade.StudentId,
            SubjectId = grade.SubjectId,
            TeacherId = grade.TeacherId,
            Value = grade.Value
        };

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    [SwaggerResponse(200, "Success")]
    public async Task<IActionResult> DeleteGrade(Guid id, CancellationToken cancellationToken)
    {
        var query = new DeleteGradeCommand()
        {
            Id = id
        };

        await _mediator.Send(query, cancellationToken);

        return Ok();
    }
}