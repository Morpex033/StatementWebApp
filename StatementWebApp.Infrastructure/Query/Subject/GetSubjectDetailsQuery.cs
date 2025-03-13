using MediatR;
using StatementWebApp.Core.Dto;

namespace StatementWebApp.Infrastructure.Query.Subject;

public class GetSubjectDetailsQuery : IRequest<SubjectDetailsDto>
{
    public Guid Id { get; set; }
}