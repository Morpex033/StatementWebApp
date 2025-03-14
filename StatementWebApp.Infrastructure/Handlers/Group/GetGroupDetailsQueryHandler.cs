using MediatR;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Group;

namespace StatementWebApp.Infrastructure.Handlers.Group;

public class GetGroupDetailsQueryHandler : IRequestHandler<GetGroupDetailsQuery, GroupDetailsDto>
{
    private readonly IGroupRepository _groupRepository;

    public GetGroupDetailsQueryHandler(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public Task<GroupDetailsDto> Handle(GetGroupDetailsQuery request, CancellationToken cancellationToken)
    {
        return _groupRepository.GetGroupDetailsAsync(request.Id, request.PageSize, request.PageNumber, cancellationToken);
    }
}