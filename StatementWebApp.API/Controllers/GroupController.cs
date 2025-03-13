using MediatR;
using Microsoft.AspNetCore.Mvc;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Entity;
using StatementWebApp.Infrastructure.Query.Group;
using Swashbuckle.AspNetCore.Annotations;

namespace StatementWebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class GroupController : ControllerBase
{
    private readonly IMediator _mediator;

    public GroupController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [SwaggerResponse(200, "Success", typeof(List<Group>))]
    public async Task<IActionResult> GetGroups(CancellationToken cancellationToken)
    {
        var query = new GetGroupsQuery();
        
        var result = await _mediator.Send(query, cancellationToken);
        
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    [SwaggerResponse(200, "Success", typeof(Group))]
    public async Task<IActionResult> GetGroup(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetGroupByIdQuery()
        {
            Id = id
        };
        
        var result = await _mediator.Send(query, cancellationToken);
        
        return Ok(result);
    }

    [HttpGet("{id:guid}/details")]
    [SwaggerResponse(200, "Success", typeof(List<GroupDetailsDto>))]
    public async Task<IActionResult> GetGroupDetails(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetGroupDetailsQuery()
        {
            Id = id
        };
        
        var result = await _mediator.Send(query, cancellationToken);
        
        return Ok(result);
    }
}