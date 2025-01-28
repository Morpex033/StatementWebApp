using MediatR;
using StatementWebApp.Core.Interface;
using StatementWebApp.Infrastructure.Handlers.Department;
using StatementWebApp.Infrastructure.Query.Group;

namespace StatementWebApp.Infrastructure.Handlers.Group;

public class GetGroupByIdQueryHandler : IRequestHandler<GetGroupByIdQuery, Core.Entity.Group>
{
    private readonly IGroupRepository _groupRepository;

    public GetGroupByIdQueryHandler(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }
    
    public Task<Core.Entity.Group> Handle(GetGroupByIdQuery request, CancellationToken cancellationToken)
    {
        return _groupRepository.GetGroupByIdAsync(request.Id, cancellationToken);
    }
}