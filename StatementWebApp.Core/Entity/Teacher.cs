using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StatementWebApp.Core.Entity;

public class Teacher
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public virtual ICollection<Subject> Subjects { get; set; }
    
    public virtual ICollection<Department> Departments { get; set; }
    
    public virtual ICollection<Grade> Grades { get; set; }
}