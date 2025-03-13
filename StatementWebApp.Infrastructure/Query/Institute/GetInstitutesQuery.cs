using MediatR;

namespace StatementWebApp.Infrastructure.Query.Institute;

public class GetInstitutesQuery : IRequest<List<Core.Entity.Institute>>
{
}