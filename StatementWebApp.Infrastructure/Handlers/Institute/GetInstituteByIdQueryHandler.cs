using MediatR;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Institute;

namespace StatementWebApp.Infrastructure.Handlers.Institute;

public class GetInstituteByIdQueryHandler : IRequestHandler<GetInstituteByIdQuery, Core.Entity.Institute>
{
    private readonly IInstituteRepository _instituteRepository;

    public GetInstituteByIdQueryHandler(IInstituteRepository instituteRepository)
    {
        _instituteRepository = instituteRepository;
    }

    public Task<Core.Entity.Institute> Handle(GetInstituteByIdQuery request, CancellationToken cancellationToken)
    {
        return _instituteRepository.GetInstituteByIdAsync(request.Id, cancellationToken);
    }
}