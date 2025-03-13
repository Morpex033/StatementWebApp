using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StatementWebApp.Core.Entity;

public class Student
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    [ForeignKey("Group")]
    public Guid GroupId { get; set; }
    
    public virtual Group Group { get; set; }
    
    public virtual ICollection<Subject> Subjects { get; set; }
    
    public virtual ICollection<Grade> Grades { get; set; }
}