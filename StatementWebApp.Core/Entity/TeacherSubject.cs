using System.ComponentModel.DataAnnotations.Schema;

namespace StatementWebApp.Core.Entity;

public class TeacherSubject
{
    public Teacher Teacher { get; set; }
    
    public Subject Subject { get; set; }
    public Guid TeacherId { get; set; }
    public Guid SubjectId { get; set; }
}