using System.Reflection;
using System.Text.Json.Serialization;
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
            .AddScoped<IGroupRepository, GroupRepository>()
            .AddScoped<IInstituteRepository, InstituteRepository>()
            .AddScoped<IStatementRepository, StatementRepository>();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowOrigin", policy =>
            {
                policy.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        builder.Services.AddControllers(options =>
                options.Filters.Add<GlobalExceptionFilter>())
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });


        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<ErrorHandlingMiddleware>();

        app.UseCors("AllowOrigin");

        app.UseRouting();

        app.MapControllerRoute("default", "/api/{controller}/{action=Index}/{id?}");

        app.MapControllers();

        app.Run();
    }
}