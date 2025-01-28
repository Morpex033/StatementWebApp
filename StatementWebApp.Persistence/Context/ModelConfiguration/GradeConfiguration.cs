using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StatementWebApp.Core.Entity;

namespace StatementWebApp.Persistence.Context.ModelConfiguration;

public class GradeConfiguration : IEntityTypeConfiguration<Grade>
{
    public void Configure(EntityTypeBuilder<Grade> builder)
    {
        builder
            .Navigation(g => g.Teacher)
            .AutoInclude();
        
        builder
            .Navigation(g => g.Student)
            .AutoInclude();
        
        builder
            .Navigation(g => g.Subject)
            .AutoInclude();
        
        builder
            .HasOne(g => g.Teacher)
            .WithMany()
            .HasForeignKey(g => g.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(g => g.Student)
            .WithMany()
            .HasForeignKey(g => g.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(g => g.Subject)
            .WithMany()
            .HasForeignKey(g => g.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}