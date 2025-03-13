namespace StatementWebApp.Core.Entity;

public class Institute
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public virtual ICollection<Department> Departments { get; set; }
}