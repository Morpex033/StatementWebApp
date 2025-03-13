using System.ComponentModel.DataAnnotations.Schema;

namespace StatementWebApp.Core.Entity;

public class Statement
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string Index { get; set; }

    public virtual ICollection<Grade> Grades { get; set; }

    public Statement()
    {
    }

    public Statement(string index, List<Grade> grades)
    {
        Grades = grades;
        Index = index;
    }
}