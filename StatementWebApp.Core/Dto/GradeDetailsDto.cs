using StatementWebApp.Core.Entity;

namespace StatementWebApp.Core.Dto;

public class GradeDetailsDto
{
    public Student Student { get; set; }
    
    public Teacher Teacher { get; set; }
    
    public Subject Subject { get; set; }
    
    public Statement Statement { get; set; }
}