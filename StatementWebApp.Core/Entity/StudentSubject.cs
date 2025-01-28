namespace StatementWebApp.Core.Entity;

public class StudentSubject
{
    public Student Student { get; set; }
    
    public Subject Subject { get; set; }
    public Guid StudentId { get; set; }
    public Guid SubjectId { get; set; }
}