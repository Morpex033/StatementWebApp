using MediatR;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Group;

namespace StatementWebApp.Infrastructure.Handlers.Group;

public class GetGroupsQueryHandler : IRequestHandler<GetGroupsQuery, EntityWithCountDto<Core.Entity.Group>>
{
    private readonly IGroupRepository _groupRepository;

    public GetGroupsQueryHandler(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public Task<EntityWithCountDto<Core.Entity.Group>> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
    {
        return _groupRepository.GetGroupsAsync(request.PageSize, request.PageNumber, cancellationToken);
    }
}