using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StatementWebApp.Core.Entity;

public class Group
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    [ForeignKey("Department")]
    public Guid DepartmentId { get; set; }
    
    public virtual Department Department { get; set; }
    
    public virtual ICollection<Student> Students { get; set; }
}