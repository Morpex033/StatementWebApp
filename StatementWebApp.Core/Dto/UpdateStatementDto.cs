using StatementWebApp.Core.Entity;

namespace StatementWebApp.Core.Dto;

public class UpdateStatementDto
{
    public string Index { get; set; }
    
    public List<Grade> Grades { get; set; }
}