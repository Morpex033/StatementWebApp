using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MediatR;
using StatementWebApp.Core.Entity;

namespace StatementWebApp.Infrastructure.Command.Statement;

public class CreateStatementCommand : IRequest<Core.Entity.Statement>
{
    [Required]
    public Guid InstituteId { get; set; }
}