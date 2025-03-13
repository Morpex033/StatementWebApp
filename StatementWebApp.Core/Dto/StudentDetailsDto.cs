using StatementWebApp.Core.Entity;

namespace StatementWebApp.Core.Dto;

public class StudentDetailsDto
{
    public Group Group { get; set; }
    
    public List<Subject> Subjects { get; set; }
    
    public List<Grade> Grades { get; set; }
}