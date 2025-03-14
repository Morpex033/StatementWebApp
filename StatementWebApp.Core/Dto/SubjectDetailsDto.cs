using StatementWebApp.Core.Entity;

namespace StatementWebApp.Core.Dto;

public class SubjectDetailsDto
{
    public EntityWithCountDto<Student> Students { get; set; }
    
    public EntityWithCountDto<Teacher> Teachers { get; set; }
    
    public EntityWithCountDto<Grade> Grades { get; set; }
}