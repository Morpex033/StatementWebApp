using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StatementWebApp.Core.Entity;
using StatementWebApp.Core.Interface;
using StatementWebApp.Filters;
using StatementWebApp.Infrastructure.Handlers.Department;
using StatementWebApp.Middleware;
using StatementWebApp.Persistence.Context;
using StatementWebApp.Persistence.Repositories;

namespace StatementWebApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<CustomDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(GetDepartmentByIdQueryHandler).Assembly);

        builder.Services
            .AddScoped<IDepartmentRepository, DepartmentRepository>()
            .AddScoped<ISubjectRepository, SubjectRepository>()
            .AddScoped<ITeacherRepository, TeacherRepository>()
            .AddScoped<IStudentRepository, StudentRepository>()
            .AddScoped<IGradeRepository, GradeRepository>()
            .AddScoped<IGroupRepository, GroupRepository>();

        builder.Services.AddControllers(options =>
            options.Filters.Add<GlobalExceptionFilter>());

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<ErrorHandlingMiddleware>();

        app.UseRouting();

        app.MapControllerRoute("default", "/api/{controller}/{action=Index}/{id?}");

        app.Run();
    }
}