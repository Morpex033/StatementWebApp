using StatementWebApp.Core.Entity;

namespace StatementWebApp.Core.Dto;

public class DepartmentDetailsDto
{
    public Institute Institute { get; set; }
    
    public List<Group> Groups { get; set; }
    
    public List<Teacher> Teachers { get; set; }
}