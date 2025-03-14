using MediatR;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Institute;

namespace StatementWebApp.Infrastructure.Handlers.Institute;

public class GetInstitutesQueryHandler : IRequestHandler<GetInstitutesQuery, EntityWithCountDto<Core.Entity.Institute>>
{
    private readonly IInstituteRepository _instituteRepository;

    public GetInstitutesQueryHandler(IInstituteRepository repository)
    {
        _instituteRepository = repository;
    }

    public Task<EntityWithCountDto<Core.Entity.Institute>> Handle(GetInstitutesQuery request, CancellationToken cancellationToken)
    {
        return _instituteRepository.GetInstitutesAsync(request.PageSize, request.PageNumber, cancellationToken);
    }
}