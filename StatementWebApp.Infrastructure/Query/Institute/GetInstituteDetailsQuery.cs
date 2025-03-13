using MediatR;
using StatementWebApp.Core.Dto;

namespace StatementWebApp.Infrastructure.Query.Institute;

public class GetInstituteDetailsQuery : IRequest<InstituteDetailsDto>
{
    public Guid Id { get; set; }
}