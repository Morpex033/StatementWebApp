using System.ComponentModel.DataAnnotations;

namespace StatementWebApp.Core.Dto;

public class CreateGradeDto
{
    [Required]
    [Range(0, 100)]
    public int Value { get; set; }
    
    [Required]
    public Guid TeacherId { get; set; }
    
    [Required]
    public Guid StudentId { get; set; }
    
    [Required]
    public Guid SubjectId { get; set; }
}