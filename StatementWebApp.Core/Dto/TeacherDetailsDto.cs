using StatementWebApp.Core.Entity;

namespace StatementWebApp.Core.Dto;

public class TeacherDetailsDto
{
    public List<Subject> Subjects { get; set; }
    
    public List<Department> Departments { get; set; }
    
    public List<Grade> Grades { get; set; }
}