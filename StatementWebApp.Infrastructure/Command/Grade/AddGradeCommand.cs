using System.ComponentModel.DataAnnotations;
using MediatR;
using StatementWebApp.Core.Dto;

namespace StatementWebApp.Infrastructure.Command.Grade;

public class AddGradeCommand : IRequest<Core.Entity.Grade>
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