using MediatR;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Institute;

namespace StatementWebApp.Infrastructure.Handlers.Institute;

public class GetInstituteDetailsQueryHandler : IRequestHandler<GetInstituteDetailsQuery, InstituteDetailsDto>
{
    private readonly IInstituteRepository _instituteRepository;

    public GetInstituteDetailsQueryHandler(IInstituteRepository instituteRepository)
    {
        _instituteRepository = instituteRepository;
    }

    public Task<InstituteDetailsDto> Handle(GetInstituteDetailsQuery request, CancellationToken cancellationToken)
    {
        return _instituteRepository.GetInstituteDetailsAsync(request.Id, request.PageSize, request.PageNumber, cancellationToken);
    }
}