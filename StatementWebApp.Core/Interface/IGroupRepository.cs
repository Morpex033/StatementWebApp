using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Entity;

namespace StatementWebApp.Core.Interface;

public interface IGroupRepository
{
    Task<EntityWithCountDto<Group>> GetGroupsAsync(int pageSize, int pageNumber, CancellationToken cancellationToken);
    Task<Group> GetGroupByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<GroupDetailsDto> GetGroupDetailsAsync(Guid id, int pageSize, int pageNumber, CancellationToken cancellationToken);
}