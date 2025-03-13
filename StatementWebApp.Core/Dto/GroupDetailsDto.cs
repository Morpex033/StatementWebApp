using StatementWebApp.Core.Entity;

namespace StatementWebApp.Core.Dto;

public class GroupDetailsDto
{
    public Department Department { get; set; }
    
    public List<Student> Students { get; set; }
}