using MediatR;
using StatementWebApp.Core.Dto;

namespace StatementWebApp.Infrastructure.Query.Student;

public class GetStudentDetailsQuery : IRequest<StudentDetailsDto>
{
    public Guid Id { get; set; }
}