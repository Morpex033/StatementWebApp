using StatementWebApp.Core.Entity;

namespace StatementWebApp.Core.Dto;

public class GroupDetailsDto
{
    public Department Department { get; set; }
    
    public EntityWithCountDto<Student> Students { get; set; }
}