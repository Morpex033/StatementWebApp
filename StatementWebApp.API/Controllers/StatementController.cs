using MediatR;
using Microsoft.AspNetCore.Mvc;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Entity;
using StatementWebApp.Infrastructure.Command.Statement;
using StatementWebApp.Infrastructure.Query.Statement;
using Swashbuckle.AspNetCore.Annotations;

namespace StatementWebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class StatementController : ControllerBase
{
    private readonly IMediator _mediator;

    public StatementController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [SwaggerResponse(200, "Success", typeof(Statement))]
    public async Task<IActionResult> CreateStatement(Guid instituteId, CancellationToken cancellationToken)
    {
        var query = new CreateStatementCommand()
        {
            InstituteId = instituteId,
        };

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }

    [HttpGet]
    [SwaggerResponse(200, "Success", typeof(List<Statement>))]
    public async Task<IActionResult> GetStatements(CancellationToken cancellationToken)
    {
        var query = new GetStatementsQuery();

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    [SwaggerResponse(200, "Success", typeof(Statement))]
    public async Task<IActionResult> GetStatementById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetStatementByIdQuery()
        {
            Id = id
        };

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    [SwaggerResponse(200, "Success", typeof(Statement))]
    public async Task<IActionResult> UpdateStatement(Guid id, UpdateStatementDto updateStatementDto,
        CancellationToken cancellationToken)
    {
        var command = new UpdateStatementCommand()
        {
            Id = id,
            Data = updateStatementDto
        };

        var result = await _mediator.Send(command, cancellationToken);

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    [SwaggerResponse(200, "Success")]
    public async Task<IActionResult> DeleteStatement(Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteStatementCommand()
        {
            Id = id
        };

        var result = await _mediator.Send(command, cancellationToken);

        return Ok(result);
    }

    [HttpGet("{id:guid}/details")]
    [SwaggerResponse(200, "Success", typeof(StatementDetailsDto))]
    public async Task<IActionResult> GetStatementDetails(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetStatementDetailsQuery()
        {
            Id = id
        };
        
        var result = await _mediator.Send(query, cancellationToken);
        
        return Ok(result);
    }
}