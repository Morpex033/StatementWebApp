using MediatR;
using Microsoft.AspNetCore.Mvc;
using StatementWebApp.Core.Entity;
using StatementWebApp.Infrastructure.Query.Teacher;
using Swashbuckle.AspNetCore.Annotations;

namespace StatementWebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class TeacherController : ControllerBase
{
    private readonly IMediator _mediator;

    public TeacherController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [SwaggerResponse(200, "Success", typeof(List<Teacher>))]
    public async Task<IActionResult> GetTeachers(CancellationToken cancellationToken)
    {
        var query = new GetTeachersQuery();
        
        var result = await _mediator.Send(query, cancellationToken);
        
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    [SwaggerResponse(200, "Success", typeof(Teacher))]
    public async Task<IActionResult> GetTeacher(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetTeacherByIdQuery()
        {
            Id = id
        };
        
        var result = await _mediator.Send(query, cancellationToken);
        
        return Ok(result);
    }
}