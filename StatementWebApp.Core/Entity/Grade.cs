using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StatementWebApp.Core.Dto;

namespace StatementWebApp.Core.Entity;

public class Grade
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public int Value { get; set; }

    public Guid TeacherId { get; set; }

    public Teacher Teacher { get; set; }

    public Guid StudentId { get; set; }

    public Student Student { get; set; }

    public Guid SubjectId { get; set; }

    public Subject Subject { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime Date { get; }

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