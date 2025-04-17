using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using StatementWebApp.Core.Dto;

namespace StatementWebApp.Core.Entity;

public class Grade
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public int Value { get; set; }

    [ForeignKey("Teacher")]
    public Guid TeacherId { get; set; }

    public virtual Teacher Teacher { get; set; }

    [ForeignKey("Student")]
    public Guid StudentId { get; set; }

    public virtual Student Student { get; set; }

    [ForeignKey("Subject")]
    public Guid SubjectId { get; set; }

    public virtual Subject Subject { get; set; }

    [ForeignKey("Statement")]
    public Guid? StatementId { get; set; }

    public virtual Statement Statement { get; set; }
    public DateTime Date { get; set; }

    public Grade()
    {
    }

    public Grade(CreateGradeDto grade, Teacher teacher, Student student, Subject subject)
    {
        Value = grade.Value;
        TeacherId = grade.TeacherId;
        StudentId = grade.StudentId;
        SubjectId = grade.SubjectId;
        Teacher = teacher;
        Student = student;
        Subject = subject;
    }

    public Grade(UpdateGradeDto grade, Teacher teacher, Student student, Subject subject)
    {
        Value = grade.Value;
        TeacherId = grade.TeacherId;
        StudentId = grade.StudentId;
        SubjectId = grade.SubjectId;
        Teacher = teacher;
        Student = student;
        Subject = subject;
    }
}