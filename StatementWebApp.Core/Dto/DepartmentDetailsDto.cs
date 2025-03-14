using StatementWebApp.Core.Entity;

namespace StatementWebApp.Core.Dto;

public class DepartmentDetailsDto
{
    public Institute Institute { get; set; }
    
    public EntityWithCountDto<Group> Groups { get; set; }
    
    public EntityWithCountDto<Teacher> Teachers { get; set; }
}