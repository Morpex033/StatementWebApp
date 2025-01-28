using MediatR;
using Microsoft.AspNetCore.Mvc;
using StatementWebApp.Core.Entity;
using StatementWebApp.Infrastructure;
using StatementWebApp.Infrastructure.Query.Department;
using Swashbuckle.AspNetCore.Annotations;

namespace StatementWebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly IMediator _mediator;

    public DepartmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [SwaggerResponse(200, "Success", typeof(List<Department>))]
    public async Task<IActionResult> GetDepartments(CancellationToken cancellationToken)
    {
        var query = new GetDepartmentsQuery();

        var departments = await _mediator.Send(query, cancellationToken);

        return Ok(departments);
    }

    [HttpGet("{id:guid}")]
    [SwaggerResponse(200, "Success", typeof(Department))]
    public async Task<IActionResult> GetDepartment(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetDepartmentByIdQuery()
        {
            Id = id
        };

        var department = await _mediator.Send(query, cancellationToken);

        return Ok(department);
    }
}