using StatementWebApp.Core.Entity;

namespace StatementWebApp.Core.Dto;

public class TeacherDetailsDto
{
    public EntityWithCountDto<Subject> Subjects { get; set; }
    
    public EntityWithCountDto<Department> Departments { get; set; }
    
    public EntityWithCountDto<Grade> Grades { get; set; }
}