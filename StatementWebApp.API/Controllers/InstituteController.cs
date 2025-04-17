using MediatR;
using Microsoft.AspNetCore.Mvc;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Entity;
using StatementWebApp.Infrastructure.Query.Institute;
using Swashbuckle.AspNetCore.Annotations;

namespace StatementWebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class InstituteController : ControllerBase
{
    private readonly IMediator _mediator;

    public InstituteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:guid}")]
    [SwaggerResponse(200, "Success", typeof(Institute))]
    public async Task<IActionResult> GetInstituteById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetInstituteByIdQuery() { Id = id };

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }

    [HttpGet]
    [SwaggerResponse(200, "Success", typeof(List<Institute>))]
    public async Task<IActionResult> GetInstitutes(CancellationToken cancellationToken, [FromQuery] int pageSize = 10,
        [FromQuery] int pageNumber = 1, [FromQuery] string name = "")
    {
        var query = new GetInstitutesQuery()
        {
            PageSize = pageSize,
            PageNumber = pageNumber,
            Name = name
        };

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }

    [HttpGet("{id:guid}/details")]
    [SwaggerResponse(200, "Success", typeof(List<InstituteDetailsDto>))]
    public async Task<IActionResult> GetInstituteDetails(Guid id, CancellationToken cancellationToken, [FromQuery] int pageSize = 10,
        [FromQuery] int pageNumber = 1)
    {
        var query = new GetInstituteDetailsQuery()
        {
            Id = id,
            PageSize = pageSize,
            PageNumber = pageNumber
        };

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }
}