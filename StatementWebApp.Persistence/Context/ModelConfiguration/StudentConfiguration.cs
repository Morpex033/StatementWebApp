using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StatementWebApp.Core.Entity;

namespace StatementWebApp.Persistence.Context.ModelConfiguration;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder
            .Navigation(s => s.Group)
            .AutoInclude();
        
        builder
            .HasOne(s => s.Group)
            .WithMany()
            .HasForeignKey(s => s.GroupId);
    }
}