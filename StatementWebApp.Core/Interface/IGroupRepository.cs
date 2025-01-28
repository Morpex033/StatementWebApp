using StatementWebApp.Core.Entity;

namespace StatementWebApp.Core.Interface;

public interface IGroupRepository
{
    Task<List<Group>> GetGroupsAsync(CancellationToken cancellationToken);
    Task<Group> GetGroupByIdAsync(Guid id, CancellationToken cancellationToken);
}