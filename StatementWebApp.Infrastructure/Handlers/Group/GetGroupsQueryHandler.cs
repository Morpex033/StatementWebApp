using MediatR;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Query.Group;

namespace StatementWebApp.Infrastructure.Handlers.Group;

public class GetGroupsQueryHandler : IRequestHandler<GetGroupsQuery, List<Core.Entity.Group>>
{
    private readonly IGroupRepository _groupRepository;

    public GetGroupsQueryHandler(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public Task<List<Core.Entity.Group>> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
    {
        return _groupRepository.GetGroupsAsync(cancellationToken);
    }
}