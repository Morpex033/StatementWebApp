using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StatementWebApp.Core.Entity;

public class Department
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [ForeignKey("Institute")]
    public Guid InstituteId { get; set; }
    
    public virtual Institute Institute { get; set; }
    
    public virtual ICollection<Group> Groups { get; set; }
    
    public virtual ICollection<Teacher> Teachers { get; set; }
    
}