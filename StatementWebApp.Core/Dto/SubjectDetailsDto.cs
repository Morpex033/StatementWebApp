using StatementWebApp.Core.Entity;

namespace StatementWebApp.Core.Dto;

public class SubjectDetailsDto
{
    public List<Student> Students { get; set; }
    
    public List<Teacher> Teachers { get; set; }
    
    public List<Grade> Grades { get; set; }
}