using System.ComponentModel.DataAnnotations;
using MediatR;
using StatementWebApp.Core.Dto;

namespace StatementWebApp.Infrastructure.Command.Statement;

public class UpdateStatementCommand: IRequest<Core.Entity.Statement>
{
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    public UpdateStatementDto Data { get; set; }
}