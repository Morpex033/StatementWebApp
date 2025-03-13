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

    public async Task<List<Group>> GetGroupsAsync(CancellationToken cancellationToken)
    {
        return await _context.Groups.ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<Group> GetGroupByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var group = await _context.Groups
                        .SingleOrDefaultAsync(g => g.Id == id, cancellationToken: cancellationToken) ??
                    throw new NotFoundException("Group not found");

        return group;
    }

    public async Task<GroupDetailsDto> GetGroupDetailsAsync(Guid id, CancellationToken cancellationToken)
    {
        var group = await GetGroupByIdAsync(id, cancellationToken);

        var department = await _context.Departments.SingleOrDefaultAsync(d => d.Id == group.DepartmentId,
            cancellationToken: cancellationToken) ?? throw new NotFoundException("Department not found");

        var students =
            await _context.Students.Where(s => s.GroupId == group.Id)
                .ToListAsync(cancellationToken: cancellationToken) ?? throw new NotFoundException("Student not found");

        return new GroupDetailsDto()
        {
            Department = department,
            Students = students
        };
    }
}