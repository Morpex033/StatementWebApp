using MediatR;
using Microsoft.AspNetCore.Mvc;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Entity;
using StatementWebApp.Infrastructure.Query.Subject;
using Swashbuckle.AspNetCore.Annotations;

namespace StatementWebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class SubjectController : ControllerBase
{
    private readonly IMediator _mediator;

    public SubjectController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [SwaggerResponse(200, "Success", typeof(List<Subject>))]
    public async Task<IActionResult> GetSubjects(CancellationToken cancellationToken)
    {
        var query = new GetSubjectsQuery();

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    [SwaggerResponse(200, "Success", typeof(Subject))]
    public async Task<IActionResult> GetSubject(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetSubjectByIdQuery()
        {
            Id = id
        };

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }

    [HttpGet("{id:guid}/details")]
    [SwaggerResponse(200, "Success", typeof(SubjectDetailsDto))]
    public async Task<IActionResult> GetSubjectDetails(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetSubjectByIdQuery()
        {
            Id = id
        };

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }
}