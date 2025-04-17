using Microsoft.EntityFrameworkCore;
using StatementWebApp.Core.Dto;
using StatementWebApp.Core.Entity;
using StatementWebApp.Core.Exception;
using StatementWebApp.Core.Interface;
using StatementWebApp.Persistence.Context;

namespace StatementWebApp.Persistence.Repositories;

public class GroupRepository : IGroupRepository
{
    private readonly CustomDbContext _context;

    public GroupRepository(CustomDbContext context)
    {
        _context = context;
    }

    public async Task<EntityWithCountDto<Group>> GetGroupsAsync(int pageSize, int pageNumber,
        CancellationToken cancellationToken)
    {
        var totalCount = await _context.Groups.CountAsync(cancellationToken: cancellationToken);

        var groups = await _context.Groups.Skip((pageNumber - 1) * pageSize).Take(pageSize)
            .ToListAsync(cancellationToken: cancellationToken);
        return new EntityWithCountDto<Group>()
        {
            TotalCount = totalCount,
            Data = groups,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }

    public async Task<Group> GetGroupByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var group = await _context.Groups
                        .SingleOrDefaultAsync(g => g.Id == id, cancellationToken: cancellationToken) ??
                    throw new NotFoundException("Group not found");

        return group;
    }

    public async Task<GroupDetailsDto> GetGroupDetailsAsync(Guid id, int pageSize, int pageNumber,
        CancellationToken cancellationToken)
    {
        var department = await _context.Departments
                             .Where(d => d.Groups.Any(g => g.Id == id))
                             .SingleOrDefaultAsync(cancellationToken: cancellationToken) ??
                         throw new NotFoundException("Department not found");

        var students =
            await _context.Students
                .Where(s => s.GroupId == id)
                .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .ToListAsync(cancellationToken: cancellationToken) ?? throw new NotFoundException("Student not found");

        return new GroupDetailsDto()
        {
            Department = department,
            Students = new EntityWithCountDto<Student>()
            {
                Data = students,
                TotalCount = students.Count,
                PageNumber = pageNumber,
                PageSize = pageSize
            }
        };
    }
}