using MediatR;
using Microsoft.AspNetCore.Mvc;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Entity;
using StatementWebApp.Infrastructure.Query.Student;
using Swashbuckle.AspNetCore.Annotations;

namespace StatementWebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [SwaggerResponse(200, "Success", typeof(List<Student>))]
    public async Task<IActionResult> GetStudents(CancellationToken cancellationToken)
    {
        var query = new GetStudentsQuery();
        
        var result = await _mediator.Send(query, cancellationToken);
        
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    [SwaggerResponse(200, "Success", typeof(Student))]
    public async Task<IActionResult> GetStudent(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetStudentByIdQuery()
        {
            Id = id
        };
        
        var result = await _mediator.Send(query, cancellationToken);
        
        return Ok(result);
    }

    [HttpGet("{id:guid}/details")]
    [SwaggerResponse(200, "Success", typeof(StudentDetailsDto))]
    public async Task<IActionResult> GetStudentDetails(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetStudentDetailsQuery()
        {
            Id = id
        };
        
        var result = await _mediator.Send(query, cancellationToken);
        
        return Ok(result);
    }
}