using StatementWebApp.Core.Entity;

namespace StatementWebApp.Core.Dto;

public class StudentDetailsDto
{
    public Group Group { get; set; }
    
    public EntityWithCountDto<Subject> Subjects { get; set; }
}