using StatementWebApp.Core.Entity;

namespace StatementWebApp.Core.Dto;

public class InstituteDetailsDto
{
    public EntityWithCountDto<Department> Departments { get; set; }
}