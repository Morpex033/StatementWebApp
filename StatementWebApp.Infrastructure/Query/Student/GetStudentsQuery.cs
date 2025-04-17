using MediatR;
using StatementWebApp.Core.Dto;

namespace StatementWebApp.Infrastructure.Query.Student;

public class GetStudentsQuery : IRequest<EntityWithCountDto<Core.Entity.Student>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    
    public string Name { get; set; }
}