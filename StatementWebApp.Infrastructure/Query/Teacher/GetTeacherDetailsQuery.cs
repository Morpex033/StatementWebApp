using MediatR;
using StatementWebApp.Core.Dto;

namespace StatementWebApp.Infrastructure.Query.Teacher;

public class GetTeacherDetailsQuery : IRequest<TeacherDetailsDto>
{
    public Guid Id { get; set; }
}