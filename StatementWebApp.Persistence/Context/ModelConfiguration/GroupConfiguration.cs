using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StatementWebApp.Core.Entity;

namespace StatementWebApp.Persistence.Context.ModelConfiguration;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder
            .Navigation(g => g.Department)
            .AutoInclude();
        
        builder
            .HasOne(g => g.Department)
            .WithMany()
            .HasForeignKey(g => g.DepartmentId);
    }
}