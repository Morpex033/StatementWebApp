using MediatR;

namespace StatementWebApp.Infrastructure.Query.Department;

public class GetDepartmentByIdQuery : IRequest<Core.Entity.Department>
{
    public Guid Id { get; set; }
}