using StatementWebApp.Core.Entity;

namespace StatementWebApp.Core.Dto;

public class StatementDetailsDto
{
    public EntityWithCountDto<Grade> Grades { get; set; }
}