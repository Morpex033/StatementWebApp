using MediatR;

namespace StatementWebApp.Infrastructure.Query.Institute;

public class GetInstituteByIdQuery : IRequest<Core.Entity.Institute>
{
    public Guid Id { get; set; }
}