using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StatementWebApp.Core.Entity;

public class Subject
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public virtual ICollection<Student> Students { get; set; }
    
    public virtual ICollection<Teacher> Teachers { get; set; }
    
    public virtual ICollection<Grade> Grades { get; set; }
}