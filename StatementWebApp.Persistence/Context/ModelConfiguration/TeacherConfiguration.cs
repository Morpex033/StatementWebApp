using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StatementWebApp.Core.Entity;

namespace StatementWebApp.Persistence.Context.ModelConfiguration;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder
            .Navigation(t => t.Department)
            .AutoInclude();
        
        builder
            .HasOne(t => t.Department)
            .WithMany()
            .HasForeignKey(t => t.DepartmentId);
    }
}