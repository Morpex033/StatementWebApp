using MediatR;
using StatementWebApp.Core.Dto;

namespace StatementWebApp.Infrastructure.Query.Grade;

public class GetGradeDetailsQuery : IRequest<GradeDetailsDto>
{
    public Guid Id { get; set; }
    
    public int PageSize { get; set; }
    
    public int PageNumber { get; set; }
}